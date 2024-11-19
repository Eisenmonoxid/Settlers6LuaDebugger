using System;
using System.IO;
using System.Reflection;

public static class HelperFuncs
{
	public static string GetVersion()
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		Version version = executingAssembly.GetName().Version;
		string versionString = string.Concat(new string[]
		{
			version.Major.ToString(),
			".",
			version.Minor.ToString(),
			".",
			version.Build.ToString()
		});
		string configuration = (executingAssembly.GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false)[0] as AssemblyConfigurationAttribute).Configuration;
		return versionString + ((configuration == "") ? "" : (" " + configuration));
	}

	public static void CopyToStream(ref Stream input, Stream output)
	{
		byte[] array = new byte[16384];
		int count;
		while ((count = input.Read(array, 0, array.Length)) > 0)
		{
			output.Write(array, 0, count);
		}
	}
}
