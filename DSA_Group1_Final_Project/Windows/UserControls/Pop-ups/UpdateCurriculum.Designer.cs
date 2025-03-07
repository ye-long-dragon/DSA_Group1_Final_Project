﻿namespace DSA_Group1_Final_Project.Windows.UserControls.Pop_ups
{
    partial class UpdateCurriculum
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
            btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            cmbCurriculum = new Guna.UI2.WinForms.Guna2ComboBox();
            name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblProgram = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.CustomizableEdges = customizableEdges1;
            btnUpdate.DisabledState.BorderColor = Color.DarkGray;
            btnUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdate.Font = new Font("Segoe UI", 9F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(97, 259);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnUpdate.Size = new Size(623, 56);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cmbCurriculum
            // 
            cmbCurriculum.BackColor = Color.Transparent;
            cmbCurriculum.CustomizableEdges = customizableEdges3;
            cmbCurriculum.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCurriculum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCurriculum.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCurriculum.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCurriculum.Font = new Font("Segoe UI", 10F);
            cmbCurriculum.ForeColor = Color.FromArgb(68, 88, 112);
            cmbCurriculum.ItemHeight = 30;
            cmbCurriculum.Location = new Point(176, 147);
            cmbCurriculum.Name = "cmbCurriculum";
            cmbCurriculum.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbCurriculum.Size = new Size(544, 36);
            cmbCurriculum.TabIndex = 8;
            cmbCurriculum.SelectedIndexChanged += cmbCurriculum_SelectedIndexChanged;
            // 
            // name
            // 
            name.BackColor = Color.Transparent;
            name.Location = new Point(176, 98);
            name.Name = "name";
            name.Size = new Size(121, 22);
            name.TabIndex = 7;
            name.Text = "guna2HtmlLabel1";
            // 
            // lblProgram
            // 
            lblProgram.BackColor = Color.Transparent;
            lblProgram.Location = new Point(80, 147);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(63, 22);
            lblProgram.TabIndex = 6;
            lblProgram.Text = "Program: ";
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Location = new Point(80, 98);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 22);
            lblName.TabIndex = 5;
            lblName.Text = "Name:";
            // 
            // UpdateCurriculum
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUpdate);
            Controls.Add(cmbCurriculum);
            Controls.Add(name);
            Controls.Add(lblProgram);
            Controls.Add(lblName);
            Name = "UpdateCurriculum";
            Size = new Size(800, 413);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCurriculum;
        private Guna.UI2.WinForms.Guna2HtmlLabel name;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProgram;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
    }
}
