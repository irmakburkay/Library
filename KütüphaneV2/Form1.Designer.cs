
namespace KütüphaneV2
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
            this.ana_Panel = new System.Windows.Forms.Panel();
            this.kullanici_Panel = new System.Windows.Forms.Panel();
            this.gorevli_Panel = new System.Windows.Forms.Panel();
            this.gorevli_Menu = new System.Windows.Forms.MenuStrip();
            this.kullanici_Menu = new System.Windows.Forms.MenuStrip();
            this.kullanici_Panel.SuspendLayout();
            this.gorevli_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ana_Panel
            // 
            this.ana_Panel.BackColor = System.Drawing.SystemColors.Control;
            this.ana_Panel.Location = new System.Drawing.Point(12, 12);
            this.ana_Panel.Name = "ana_Panel";
            this.ana_Panel.Size = new System.Drawing.Size(1324, 697);
            this.ana_Panel.TabIndex = 0;
            this.ana_Panel.Visible = false;
            // 
            // kullanici_Panel
            // 
            this.kullanici_Panel.BackColor = System.Drawing.SystemColors.Control;
            this.kullanici_Panel.Controls.Add(this.kullanici_Menu);
            this.kullanici_Panel.Location = new System.Drawing.Point(12, 12);
            this.kullanici_Panel.Name = "kullanici_Panel";
            this.kullanici_Panel.Size = new System.Drawing.Size(1324, 697);
            this.kullanici_Panel.TabIndex = 1;
            this.kullanici_Panel.Visible = false;
            // 
            // gorevli_Panel
            // 
            this.gorevli_Panel.BackColor = System.Drawing.SystemColors.Control;
            this.gorevli_Panel.Controls.Add(this.gorevli_Menu);
            this.gorevli_Panel.Location = new System.Drawing.Point(12, 12);
            this.gorevli_Panel.Name = "gorevli_Panel";
            this.gorevli_Panel.Size = new System.Drawing.Size(1324, 697);
            this.gorevli_Panel.TabIndex = 2;
            this.gorevli_Panel.Visible = false;
            // 
            // gorevli_Menu
            // 
            this.gorevli_Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gorevli_Menu.Location = new System.Drawing.Point(0, 0);
            this.gorevli_Menu.Name = "gorevli_Menu";
            this.gorevli_Menu.Size = new System.Drawing.Size(1324, 30);
            this.gorevli_Menu.TabIndex = 0;
            this.gorevli_Menu.Text = "menuStrip1";
            // 
            // kullanici_Menu
            // 
            this.kullanici_Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.kullanici_Menu.Location = new System.Drawing.Point(0, 0);
            this.kullanici_Menu.Name = "kullanici_Menu";
            this.kullanici_Menu.Size = new System.Drawing.Size(1324, 24);
            this.kullanici_Menu.TabIndex = 0;
            this.kullanici_Menu.Text = "menuStrip2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.ana_Panel);
            this.Controls.Add(this.gorevli_Panel);
            this.Controls.Add(this.kullanici_Panel);
            this.MainMenuStrip = this.gorevli_Menu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.kullanici_Panel.ResumeLayout(false);
            this.kullanici_Panel.PerformLayout();
            this.gorevli_Panel.ResumeLayout(false);
            this.gorevli_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ana_Panel;
        private System.Windows.Forms.Panel kullanici_Panel;
        private System.Windows.Forms.Panel gorevli_Panel;
        private System.Windows.Forms.MenuStrip gorevli_Menu;
        private System.Windows.Forms.MenuStrip kullanici_Menu;
    }
}

