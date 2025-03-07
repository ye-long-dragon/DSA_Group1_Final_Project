using System.Windows.Forms;

namespace DSA_Group1_Final_Project.Windows.Pop_ups
{
    partial class MainPopUpWindow
    {
        private System.Windows.Forms.Panel pnlMain;

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPopUpWindow));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Panel();
            pnlTopBar = new Guna.UI2.WinForms.Guna2Panel();
            guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            pnlTopBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlMain.ForeColor = Color.White;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(800, 413);
            pnlMain.TabIndex = 0;
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(0, 0, 64);
            pnlTopBar.Controls.Add(guna2ImageButton1);
            pnlTopBar.Controls.Add(guna2Panel3);
            pnlTopBar.CustomizableEdges = customizableEdges4;
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Margin = new Padding(3, 4, 3, 4);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.ShadowDecoration.CustomizableEdges = customizableEdges5;
            pnlTopBar.Size = new Size(800, 37);
            pnlTopBar.TabIndex = 41;
            // 
            // guna2ImageButton1
            // 
            guna2ImageButton1.CheckedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.HoverState.ImageSize = new Size(64, 64);
            guna2ImageButton1.Image = (Image)resources.GetObject("guna2ImageButton1.Image");
            guna2ImageButton1.ImageOffset = new Point(0, 0);
            guna2ImageButton1.ImageRotate = 0F;
            guna2ImageButton1.Location = new Point(717, 3);
            guna2ImageButton1.Name = "guna2ImageButton1";
            guna2ImageButton1.PressedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2ImageButton1.Size = new Size(71, 31);
            guna2ImageButton1.TabIndex = 0;
            guna2ImageButton1.Click += guna2ImageButton1_Click;
            // 
            // guna2Panel3
            // 
            guna2Panel3.BackColor = Color.WhiteSmoke;
            guna2Panel3.CustomizableEdges = customizableEdges2;
            guna2Panel3.Location = new Point(3, 45);
            guna2Panel3.Margin = new Padding(3, 4, 3, 4);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2Panel3.Size = new Size(229, 133);
            guna2Panel3.TabIndex = 41;
            // 
            // MainPopUpWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 413);
            Controls.Add(pnlTopBar);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainPopUpWindow";
            Text = "MainPopUpWindow";
            pnlTopBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlTopBar;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
    }
}
