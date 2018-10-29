namespace WebsiteChecker
{
    partial class Form1
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
            this.listBoxUrls = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxUrls
            // 
            this.listBoxUrls.FormattingEnabled = true;
            this.listBoxUrls.ItemHeight = 20;
            this.listBoxUrls.Location = new System.Drawing.Point(53, 155);
            this.listBoxUrls.Name = "listBoxUrls";
            this.listBoxUrls.Size = new System.Drawing.Size(590, 324);
            this.listBoxUrls.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 531);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxUrls);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxUrls;
        private System.Windows.Forms.Button button1;
    }
}

