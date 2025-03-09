namespace DSA_Group1_Final_Project.Windows.AuthScreens
{
    partial class ChooseCurriculumForm : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            nameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            curriculumComboBox = new ComboBox();
            saveButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(140, 35);
            nameTextBox.Margin = new Padding(4, 3, 4, 3);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(233, 23);
            nameTextBox.TabIndex = 3;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(140, 81);
            lastNameTextBox.Margin = new Padding(4, 3, 4, 3);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(233, 23);
            lastNameTextBox.TabIndex = 4;
            // 
            // curriculumComboBox
            // 
            curriculumComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            curriculumComboBox.FormattingEnabled = true;
            curriculumComboBox.Location = new Point(140, 127);
            curriculumComboBox.Margin = new Padding(4, 3, 4, 3);
            curriculumComboBox.Name = "curriculumComboBox";
            curriculumComboBox.Size = new Size(233, 23);
            curriculumComboBox.TabIndex = 5;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(256, 174);
            saveButton.Margin = new Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 35);
            saveButton.TabIndex = 6;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 35);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 81);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 127);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Curriculum:";
            // 
            // ChooseCurriculumForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 231);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(nameTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(curriculumComboBox);
            Controls.Add(saveButton);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChooseCurriculumForm";
            Text = "Choose Curriculum";
            Load += ChooseCurriculumForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.ComboBox curriculumComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
