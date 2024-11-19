using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace LuaDebuggerStarter
{
    public partial class frmLDStarter : Form
	{
		protected string tmpPath = string.Empty;
		protected string s6Path = string.Empty;
		protected string s6HEPath = string.Empty;
		protected string savedExecutableName = "LuaDebuggerBinaryPaths.txt";
		protected const string WrongExecutable = "Error: Invalid executable file!\n\nRequirements for LuaDebugger to work:\n- Settlers6R.exe patched with S6Patcher!\n";
		public frmLDStarter()
		{
			InitializeComponent();
			UnpackEnvironment();
			SetPathToExecutable();
		}

		public void SetPathToExecutable()
		{
			btnStartRdoHE.Enabled = false;
			btnStartAekHE.Enabled = false;
            btnStartAekOV.Enabled = false;
            btnStartRdoOV.Enabled = false;
            btnFindHE.Text = "Choose Settlers6R.exe ...";
			btnFindOV.Text = "Choose Settlers6.exe ...";

			string SavedPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), savedExecutableName);
			if (File.Exists(SavedPath))
			{
				string[] FilePaths;
				try
				{
                    FilePaths = File.ReadAllLines(SavedPath);
				}
				catch
				{
					return;
				}
				if (FilePaths.Length < 2)
				{
					return;
				}
				if (File.Exists(FilePaths[0]))
				{
					s6HEPath = FilePaths[0];
					btnStartRdoHE.Enabled = true;
					btnStartAekHE.Enabled = true;
					btnFindHE.Text = "Installation Found!";
				}
				if (File.Exists(FilePaths[1]))
				{
					s6Path = FilePaths[1];
					btnStartAekOV.Enabled = true;
					btnStartRdoOV.Enabled = true;
					btnFindOV.Text = "Installation Found!";
				}
			}
		}

		public void UnpackEnvironment()
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string str = "LuaDebuggerStarter.Unpack.";
			tmpPath = Path.GetTempPath() + "luaDebugger-yoq/";

			try
			{
				string finalPath = tmpPath + "/base/_dbg/bin/release/";
				Directory.CreateDirectory(tmpPath);
				Directory.CreateDirectory(finalPath);

				string[] Filenames = {"ICSharpCode.TextEditor.dll", "EasyHook.dll", "EasyHook32.dll"};
				foreach (string Element in Filenames)
				{
                    using (FileStream Stream = new FileStream(tmpPath + Element, FileMode.Create))
                    {
                        Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(str + Element);
                        HelperFuncs.CopyToStream(ref manifestResourceStream, Stream);
                    }
                }

				using (FileStream Stream = new FileStream(finalPath + "BBLuaDebugger.dll", FileMode.Create))
				{
					Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(str + "BBLuaDebugger.dll");
					HelperFuncs.CopyToStream(ref manifestResourceStream, Stream);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("A problem occured creating Debugger files!\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void StartGameWithDebugger(string Path, string Arguments)
		{
			ProcessStartInfo Info = new ProcessStartInfo(Path, Arguments);
			StringDictionary environmentVariables = Info.EnvironmentVariables;
			environmentVariables["Path"] = environmentVariables["Path"] + ";" + tmpPath;
            Info.UseShellExecute = false;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs.Length > 1)
			{
                Info.Arguments = Info.Arguments + " " + string.Join(" ", commandLineArgs, 1, commandLineArgs.Length - 1);
			}
			Process.Start(Info);
		}

		private void ChooseGameExecutableFile(bool IsHistoryEdition)
		{
			OpenFileDialog Dialog = new OpenFileDialog
			{
				CheckFileExists = true,
				ShowHelp = false,
				Multiselect = false,
				Title = "Choose game executable ..."
			};
			
			if (Dialog.ShowDialog() == DialogResult.OK && File.Exists(Dialog.FileName))
			{
				string SavedPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), savedExecutableName);
				string[] Filepaths = new string[]
				{
					string.Empty,
					string.Empty
				};

				try
				{
					if (!File.Exists(SavedPath))
					{
						File.CreateText(SavedPath).Close();
					}
					else
					{
                        Filepaths = File.ReadAllLines(SavedPath);
						if (Filepaths.Length == 0)
						{
                            Filepaths[0] = "-";
                            Filepaths[1] = "-";
						}
					}
					if (IsHistoryEdition)
					{
						Filepaths[0] = Dialog.FileName;
					}
					else
					{
						Filepaths[1] = Dialog.FileName;
					}
					File.WriteAllLines(SavedPath, Filepaths);
				}
				catch (Exception ex)
				{
					MessageBox.Show("A problem occured when saving the file path!\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}

				if (IsHistoryEdition)
				{
					s6HEPath = Dialog.FileName;
					btnStartRdoHE.Enabled = true;
					btnStartAekHE.Enabled = true;
				}
				else
				{
					s6Path = Dialog.FileName;
					btnStartAekOV.Enabled = true;
					btnStartRdoOV.Enabled = true;
				}
			}
			else
			{
				MessageBox.Show("Error: No file chosen or file does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}

            Dialog.Dispose();
		}

		private void frmLDStarter_Load(object sender, EventArgs e)
		{
			this.Text = this.Text + " - " + HelperFuncs.GetVersion();
		}
		private void btnStartAekOV_Click(object sender, EventArgs e)
		{
			StartGameWithDebugger(s6Path, "-DISPLAYSCRIPTERRORS -DevM");
		}
		private void btnStartRdoOV_Click(object sender, EventArgs e)
		{
			StartGameWithDebugger(s6Path, "-EXTRA1 -DISPLAYSCRIPTERRORS -DevM");
		}
        private void btnStartRdoHE_Click(object sender, EventArgs e)
        {
            StartGameWithDebugger(s6HEPath, "-EXTRA1 -DISPLAYSCRIPTERRORS");
        }
        private void btnStartAekHE_Click(object sender, EventArgs e)
        {
            StartGameWithDebugger(s6HEPath, "-DISPLAYSCRIPTERRORS");
        }
        private void btnFindOV_Click(object sender, EventArgs e)
		{
			ChooseGameExecutableFile(false);
		}
        private void btnFindHE_Click(object sender, EventArgs e)
        {
            ChooseGameExecutableFile(true);
        }
    }
}
