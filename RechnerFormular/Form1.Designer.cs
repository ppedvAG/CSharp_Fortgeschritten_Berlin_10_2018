namespace RechnerFormular
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
            this.tbZahl1 = new System.Windows.Forms.TextBox();
            this.tbZahl2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbAufgabe = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbZahl1
            // 
            this.tbZahl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbZahl1.Location = new System.Drawing.Point(102, 119);
            this.tbZahl1.Name = "tbZahl1";
            this.tbZahl1.Size = new System.Drawing.Size(105, 44);
            this.tbZahl1.TabIndex = 0;
            // 
            // tbZahl2
            // 
            this.tbZahl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbZahl2.Location = new System.Drawing.Point(271, 119);
            this.tbZahl2.Name = "tbZahl2";
            this.tbZahl2.Size = new System.Drawing.Size(119, 44);
            this.tbZahl2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Berechnungs_Button_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(114, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 57);
            this.button2.TabIndex = 3;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Berechnungs_Button_Click);
            // 
            // tbAufgabe
            // 
            this.tbAufgabe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAufgabe.Location = new System.Drawing.Point(657, 119);
            this.tbAufgabe.Name = "tbAufgabe";
            this.tbAufgabe.Size = new System.Drawing.Size(248, 44);
            this.tbAufgabe.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(677, 234);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(201, 56);
            this.button3.TabIndex = 5;
            this.button3.Text = "Berechne";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1295, 33);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginLadenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // pluginLadenToolStripMenuItem
            // 
            this.pluginLadenToolStripMenuItem.Name = "pluginLadenToolStripMenuItem";
            this.pluginLadenToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.pluginLadenToolStripMenuItem.Text = "Plugin Laden";
            this.pluginLadenToolStripMenuItem.Click += new System.EventHandler(this.pluginLadenToolStripMenuItem_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.button1);
            this.panelButtons.Controls.Add(this.button2);
            this.panelButtons.Location = new System.Drawing.Point(53, 381);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(520, 178);
            this.panelButtons.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 615);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbAufgabe);
            this.Controls.Add(this.tbZahl2);
            this.Controls.Add(this.tbZahl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbZahl1;
        private System.Windows.Forms.TextBox tbZahl2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbAufgabe;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginLadenToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
    }
}

