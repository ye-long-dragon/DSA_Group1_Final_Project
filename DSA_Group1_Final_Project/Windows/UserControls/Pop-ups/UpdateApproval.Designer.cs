namespace DSA_Group1_Final_Project.Windows.UserControls.Pop_ups
{
    partial class UpdateApproval
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
            btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            rbtnApproved = new RadioButton();
            rbtnPending = new RadioButton();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.BorderRadius = 15;
            btnUpdate.CustomizableEdges = customizableEdges1;
            btnUpdate.DisabledState.BorderColor = Color.DarkGray;
            btnUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdate.Font = new Font("Segoe UI", 9F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(89, 206);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnUpdate.Size = new Size(545, 42);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // name
            // 
            name.BackColor = Color.Transparent;
            name.Location = new Point(158, 86);
            name.Margin = new Padding(3, 2, 3, 2);
            name.Name = "name";
            name.Size = new Size(97, 17);
            name.TabIndex = 7;
            name.Text = "guna2HtmlLabel1";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Location = new Point(74, 122);
            lblStatus.Margin = new Padding(3, 2, 3, 2);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 17);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Program: ";
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Location = new Point(74, 86);
            lblName.Margin = new Padding(3, 2, 3, 2);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 17);
            lblName.TabIndex = 5;
            lblName.Text = "Name:";
            // 
            // rbtnApproved
            // 
            rbtnApproved.AutoSize = true;
            rbtnApproved.Location = new Point(191, 122);
            rbtnApproved.Margin = new Padding(3, 2, 3, 2);
            rbtnApproved.Name = "rbtnApproved";
            rbtnApproved.Size = new Size(77, 19);
            rbtnApproved.TabIndex = 10;
            rbtnApproved.TabStop = true;
            rbtnApproved.Text = "Approved";
            rbtnApproved.UseVisualStyleBackColor = true;
            rbtnApproved.CheckedChanged += rbtnApproved_CheckedChanged;
            // 
            // rbtnPending
            // 
            rbtnPending.AutoSize = true;
            rbtnPending.Location = new Point(380, 122);
            rbtnPending.Margin = new Padding(3, 2, 3, 2);
            rbtnPending.Name = "rbtnPending";
            rbtnPending.Size = new Size(69, 19);
            rbtnPending.TabIndex = 11;
            rbtnPending.TabStop = true;
            rbtnPending.Text = "Pending";
            rbtnPending.UseVisualStyleBackColor = true;
            rbtnPending.CheckedChanged += rbtnPending_CheckedChanged;
            // 
            // UpdateApproval
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rbtnPending);
            Controls.Add(rbtnApproved);
            Controls.Add(btnUpdate);
            Controls.Add(name);
            Controls.Add(lblStatus);
            Controls.Add(lblName);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UpdateApproval";
            Size = new Size(700, 310);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        
        private Guna.UI2.WinForms.Guna2HtmlLabel name;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private RadioButton rbtnApproved;
        private RadioButton rbtnPending;
    }
}
