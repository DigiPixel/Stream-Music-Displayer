namespace SMD
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.title = new System.Windows.Forms.Label();
            this.logobox = new System.Windows.Forms.PictureBox();
            this.verlib = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.logobox)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(12, 195);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(336, 17);
            this.title.TabIndex = 0;
            this.title.Text = "Stream Music Displayer";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // logobox
            // 
            this.logobox.Image = global::SMD.Properties.Resources.Logo;
            this.logobox.Location = new System.Drawing.Point(12, 12);
            this.logobox.Name = "logobox";
            this.logobox.Size = new System.Drawing.Size(336, 175);
            this.logobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logobox.TabIndex = 1;
            this.logobox.TabStop = false;
            // 
            // verlib
            // 
            this.verlib.AutoSize = true;
            this.verlib.Location = new System.Drawing.Point(12, 217);
            this.verlib.Name = "verlib";
            this.verlib.Size = new System.Drawing.Size(44, 13);
            this.verlib.TabIndex = 2;
            this.verlib.Text = "Ver 1.0 ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(284, 167);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(47, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "twitch.tv";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 238);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.verlib);
            this.Controls.Add(this.logobox);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logobox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox logobox;
        private System.Windows.Forms.Label verlib;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}