namespace DSA_Group1_Final_Project.Windows.Pop_ups
{
    partial class UpdateProgram
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblProgram = new Guna.UI2.WinForms.Guna2HtmlLabel();
            name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cmbProgram = new Guna.UI2.WinForms.Guna2ComboBox();
            btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Location = new Point(75, 55);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 22);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // lblProgram
            // 
            lblProgram.BackColor = Color.Transparent;
            lblProgram.Location = new Point(75, 104);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(63, 22);
            lblProgram.TabIndex = 1;
            lblProgram.Text = "Program: ";
            // 
            // name
            // 
            name.BackColor = Color.Transparent;
            name.Location = new Point(171, 55);
            name.Name = "name";
            name.Size = new Size(121, 22);
            name.TabIndex = 2;
            name.Text = "guna2HtmlLabel1";
            // 
            // cmbProgram
            // 
            cmbProgram.BackColor = Color.Transparent;
            cmbProgram.CustomizableEdges = customizableEdges1;
            cmbProgram.DrawMode = DrawMode.OwnerDrawFixed;
            cmbProgram.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProgram.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbProgram.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbProgram.Font = new Font("Segoe UI", 10F);
            cmbProgram.ForeColor = Color.FromArgb(68, 88, 112);
            cmbProgram.ItemHeight = 30;
            cmbProgram.Location = new Point(171, 104);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbProgram.Size = new Size(544, 36);
            cmbProgram.TabIndex = 3;
            cmbProgram.SelectedIndexChanged += cmbProgram_SelectedIndexChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.CustomizableEdges = customizableEdges3;
            btnUpdate.DisabledState.BorderColor = Color.DarkGray;
            btnUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdate.Font = new Font("Segoe UI", 9F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(92, 216);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnUpdate.Size = new Size(623, 56);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // UpdateProgram
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUpdate);
            Controls.Add(cmbProgram);
            Controls.Add(name);
            Controls.Add(lblProgram);
            Controls.Add(lblName);
            Name = "UpdateProgram";
            Size = new Size(800, 413);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProgram;
        private Guna.UI2.WinForms.Guna2HtmlLabel name;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProgram;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
    }
}
