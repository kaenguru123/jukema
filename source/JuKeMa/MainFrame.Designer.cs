
using System.Windows.Forms;

namespace JuKeMa
{
    partial class MainFrame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveJson = new System.Windows.Forms.Button();
            this.JsonView = new System.Windows.Forms.TextBox();
            this.ListBox = new System.Windows.Forms.CheckedListBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveJson
            // 
            this.SaveJson.Location = new System.Drawing.Point(876, 571);
            this.SaveJson.Name = "SaveJson";
            this.SaveJson.Size = new System.Drawing.Size(121, 23);
            this.SaveJson.TabIndex = 0;
            this.SaveJson.Text = "Save Json";
            this.SaveJson.UseVisualStyleBackColor = true;
            this.SaveJson.Click += new System.EventHandler(this.SaveJson_Click);
            // 
            // JsonView
            // 
            this.JsonView.Location = new System.Drawing.Point(35, 258);
            this.JsonView.MaximumSize = new System.Drawing.Size(950, 280);
            this.JsonView.MinimumSize = new System.Drawing.Size(950, 280);
            this.JsonView.Multiline = true;
            this.JsonView.Name = "JsonView";
            this.JsonView.ReadOnly = true;
            this.JsonView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.JsonView.Size = new System.Drawing.Size(950, 280);
            this.JsonView.TabIndex = 2;
            // 
            // ListBox
            // 
            this.ListBox.FormattingEnabled = true;
            this.employees = data.getDataForCheckList();
            this.ListBox.Items.Add("select all");
            foreach (var employee in this.employees)
            {
                this.ListBox.Items.Add($"{employee.NTUser}\t  {employee.Name}\t({employee.Department})");
            }
            this.ListBox.Location = new System.Drawing.Point(35, 33);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(426, 202);
            this.ListBox.TabIndex = 3;
            this.ListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // Logo
            // 
            this.Logo.Image = global::JuKeMa.Properties.Resources.Logo1;
            this.Logo.Location = new System.Drawing.Point(490, 33);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(495, 202);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 4;
            this.Logo.TabStop = false;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 620);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.JsonView);
            this.Controls.Add(this.SaveJson);
            this.Name = "MainFrame";
            this.Text = "JuKeMa - Employee to JSON";
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveJson;
        private System.Windows.Forms.TextBox JsonView;
        private System.Windows.Forms.CheckedListBox ListBox;
        private System.Windows.Forms.PictureBox Logo;
    }
}

