using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace LuaDebuggerStarter
{
    partial class frmLDStarter
    {
        private System.ComponentModel.IContainer components = null;
        private Label label4;
        private Label label3;
        private Button btnStartAekHE;
        private Button btnStartRdoHE;
        private Button btnFindHE;
        private Panel panel2;
        private Label label1;
        private Panel panel1;
        private Button btnFindOV;
        private Button btnStartRdoOV;
        private Button btnStartAekOV;
        private Label label5;
        private Label label6;
        private Label label2;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartAekHE = new System.Windows.Forms.Button();
            this.btnStartRdoHE = new System.Windows.Forms.Button();
            this.btnFindHE = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindOV = new System.Windows.Forms.Button();
            this.btnStartRdoOV = new System.Windows.Forms.Button();
            this.btnStartAekOV = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Rise of an Empire";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "The Settlers";
            // 
            // btnStartAekHE
            // 
            this.btnStartAekHE.Enabled = false;
            this.btnStartAekHE.Location = new System.Drawing.Point(293, 3);
            this.btnStartAekHE.Name = "btnStartAekHE";
            this.btnStartAekHE.Size = new System.Drawing.Size(89, 32);
            this.btnStartAekHE.TabIndex = 2;
            this.btnStartAekHE.Text = "AeK";
            this.btnStartAekHE.UseVisualStyleBackColor = true;
            this.btnStartAekHE.Click += new System.EventHandler(this.btnStartAekHE_Click);
            // 
            // btnStartRdoHE
            // 
            this.btnStartRdoHE.Enabled = false;
            this.btnStartRdoHE.Location = new System.Drawing.Point(293, 42);
            this.btnStartRdoHE.Name = "btnStartRdoHE";
            this.btnStartRdoHE.Size = new System.Drawing.Size(89, 32);
            this.btnStartRdoHE.TabIndex = 3;
            this.btnStartRdoHE.Text = "RdO";
            this.btnStartRdoHE.UseVisualStyleBackColor = true;
            this.btnStartRdoHE.Click += new System.EventHandler(this.btnStartRdoHE_Click);
            // 
            // btnFindHE
            // 
            this.btnFindHE.Location = new System.Drawing.Point(166, 16);
            this.btnFindHE.Name = "btnFindHE";
            this.btnFindHE.Size = new System.Drawing.Size(89, 52);
            this.btnFindHE.TabIndex = 8;
            this.btnFindHE.Text = "Installation Found!";
            this.btnFindHE.UseVisualStyleBackColor = true;
            this.btnFindHE.Click += new System.EventHandler(this.btnFindHE_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.btnFindHE);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnStartRdoHE);
            this.panel2.Controls.Add(this.btnStartAekHE);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(10, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 77);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "History Edition";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnFindOV);
            this.panel1.Controls.Add(this.btnStartRdoOV);
            this.panel1.Controls.Add(this.btnStartAekOV);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.ForeColor = System.Drawing.Color.Blue;
            this.panel1.Location = new System.Drawing.Point(10, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 77);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Original Game";
            // 
            // btnFindOV
            // 
            this.btnFindOV.Location = new System.Drawing.Point(166, 16);
            this.btnFindOV.Name = "btnFindOV";
            this.btnFindOV.Size = new System.Drawing.Size(89, 52);
            this.btnFindOV.TabIndex = 8;
            this.btnFindOV.Text = "Installation Found!";
            this.btnFindOV.UseVisualStyleBackColor = true;
            this.btnFindOV.Click += new System.EventHandler(this.btnFindOV_Click);
            // 
            // btnStartRdoOV
            // 
            this.btnStartRdoOV.Enabled = false;
            this.btnStartRdoOV.Location = new System.Drawing.Point(293, 42);
            this.btnStartRdoOV.Name = "btnStartRdoOV";
            this.btnStartRdoOV.Size = new System.Drawing.Size(89, 32);
            this.btnStartRdoOV.TabIndex = 3;
            this.btnStartRdoOV.Text = "RdO";
            this.btnStartRdoOV.UseVisualStyleBackColor = true;
            this.btnStartRdoOV.Click += new System.EventHandler(this.btnStartRdoOV_Click);
            // 
            // btnStartAekOV
            // 
            this.btnStartAekOV.Enabled = false;
            this.btnStartAekOV.Location = new System.Drawing.Point(293, 3);
            this.btnStartAekOV.Name = "btnStartAekOV";
            this.btnStartAekOV.Size = new System.Drawing.Size(89, 32);
            this.btnStartAekOV.TabIndex = 2;
            this.btnStartAekOV.Text = "AeK";
            this.btnStartAekOV.UseVisualStyleBackColor = true;
            this.btnStartAekOV.Click += new System.EventHandler(this.btnStartAekOV_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "The Settlers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Rise of an Empire";
            // 
            // frmLDStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 187);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(426, 226);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(426, 226);
            this.Name = "frmLDStarter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LuaDebugger - Settlers 6";
            this.Load += new System.EventHandler(this.frmLDStarter_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}