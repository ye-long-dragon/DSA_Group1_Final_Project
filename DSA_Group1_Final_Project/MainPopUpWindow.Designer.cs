using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.Pop_ups
{
    partial class MainPopUpWindow
    {
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 450);
            this.pnlMain.TabIndex = 0;

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(10, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // MainPopUpWindow
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnClose);
            this.Name = "MainPopUpWindow";
            this.Text = "MainPopUpWindow";
            this.ResumeLayout(false);
        }
    }
}
