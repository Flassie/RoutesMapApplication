namespace RoutesMapApplication
{
    partial class SelectDatabaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DBSelectButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.DBSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // DBSelectButton
            // 
            this.DBSelectButton.Location = new System.Drawing.Point(13, 13);
            this.DBSelectButton.Name = "DBSelectButton";
            this.DBSelectButton.Size = new System.Drawing.Size(385, 35);
            this.DBSelectButton.TabIndex = 0;
            this.DBSelectButton.Text = "Select Database with koordinates table and start";
            this.DBSelectButton.UseVisualStyleBackColor = true;
            this.DBSelectButton.Click += new System.EventHandler(this.DBSelectButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Location = new System.Drawing.Point(13, 51);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(385, 34);
            this.ErrorLabel.TabIndex = 1;
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DBSelectDialog
            // 
            this.DBSelectDialog.FileName = "harita.mdb";
            this.DBSelectDialog.Filter = "Microsoft Access DB File|*.mdb";
            // 
            // SelectDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 94);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.DBSelectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SelectDatabaseForm";
            this.Text = "Map";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DBSelectButton;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.OpenFileDialog DBSelectDialog;
    }
}

