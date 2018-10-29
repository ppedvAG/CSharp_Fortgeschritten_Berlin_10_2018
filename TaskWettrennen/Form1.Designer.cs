namespace TaskWettrennen
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
            this.pictureBoxMichael = new System.Windows.Forms.PictureBox();
            this.pictureBoxVettel = new System.Windows.Forms.PictureBox();
            this.pictureBoxZiel = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMichael)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVettel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZiel)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMichael
            // 
            this.pictureBoxMichael.ImageLocation = "https://cdn.images.dailystar.co.uk/dynamic/204/photos/642000/620x/michael-schumac" +
    "her-rubens-barrichello-697444.jpg";
            this.pictureBoxMichael.Location = new System.Drawing.Point(134, 153);
            this.pictureBoxMichael.Name = "pictureBoxMichael";
            this.pictureBoxMichael.Size = new System.Drawing.Size(147, 114);
            this.pictureBoxMichael.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMichael.TabIndex = 0;
            this.pictureBoxMichael.TabStop = false;
            // 
            // pictureBoxVettel
            // 
            this.pictureBoxVettel.ImageLocation = "https://bilder1.n-tv.de/img/incoming/crop20689176/0644992504-cImg_16_9-w680/2e6c5" +
    "2000689c2b438e81f80b81e20d7.jpg";
            this.pictureBoxVettel.Location = new System.Drawing.Point(134, 307);
            this.pictureBoxVettel.Name = "pictureBoxVettel";
            this.pictureBoxVettel.Size = new System.Drawing.Size(147, 114);
            this.pictureBoxVettel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxVettel.TabIndex = 1;
            this.pictureBoxVettel.TabStop = false;
            // 
            // pictureBoxZiel
            // 
            this.pictureBoxZiel.ImageLocation = "https://picture.yatego.com/images/53e9e6bdab5a55.4/big_be106d1ddbf1cfdd23ce48be99" +
    "56d21d-kqh/deko-fahne---start-ziel---gr--ca--150x90cm---24469---neutrale-flagge-" +
    "-trendfahne.jpg";
            this.pictureBoxZiel.Location = new System.Drawing.Point(681, 134);
            this.pictureBoxZiel.Name = "pictureBoxZiel";
            this.pictureBoxZiel.Size = new System.Drawing.Size(177, 318);
            this.pictureBoxZiel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxZiel.TabIndex = 2;
            this.pictureBoxZiel.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 56);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start Parallel.ForEach";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(517, 509);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 56);
            this.button2.TabIndex = 4;
            this.button2.Text = "Start WaitAny";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 637);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxVettel);
            this.Controls.Add(this.pictureBoxMichael);
            this.Controls.Add(this.pictureBoxZiel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMichael)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVettel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZiel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMichael;
        private System.Windows.Forms.PictureBox pictureBoxVettel;
        private System.Windows.Forms.PictureBox pictureBoxZiel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

