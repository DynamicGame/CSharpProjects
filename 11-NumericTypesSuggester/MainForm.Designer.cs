namespace _11_NumericTypesSuggester
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            minValueTextBox = new TextBox();
            maxValueTextBox = new TextBox();
            label3 = new Label();
            integralCheckbox = new CheckBox();
            label4 = new Label();
            typeData = new Label();
            precisionChecker = new CheckBox();
            MustbePrecise = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(78, 57);
            label1.Name = "label1";
            label1.Size = new Size(129, 35);
            label1.TabIndex = 0;
            label1.Text = "Min Value:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(78, 111);
            label2.Name = "label2";
            label2.Size = new Size(133, 35);
            label2.TabIndex = 1;
            label2.Text = "Max Value:";
            // 
            // minValueTextBox
            // 
            minValueTextBox.Location = new Point(213, 66);
            minValueTextBox.Name = "minValueTextBox";
            minValueTextBox.Size = new Size(483, 27);
            minValueTextBox.TabIndex = 2;
            minValueTextBox.KeyPress += minValueTextBox_KeyPress;
            minValueTextBox.KeyUp += MinValueTextBox_KeyUp;
            // 
            // maxValueTextBox
            // 
            maxValueTextBox.Location = new Point(213, 119);
            maxValueTextBox.Name = "maxValueTextBox";
            maxValueTextBox.Size = new Size(483, 27);
            maxValueTextBox.TabIndex = 3;
            maxValueTextBox.KeyPress += maxValueTextBox_KeyPress;
            maxValueTextBox.KeyUp += this.maxValueTextBox_KeyUp;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(78, 172);
            label3.Name = "label3";
            label3.Size = new Size(165, 35);
            label3.TabIndex = 4;
            label3.Text = "Integral only?";
            // 
            // integralCheckbox
            // 
            integralCheckbox.AutoSize = true;
            integralCheckbox.Location = new Point(249, 183);
            integralCheckbox.Name = "integralCheckbox";
            integralCheckbox.Size = new Size(18, 17);
            integralCheckbox.TabIndex = 5;
            integralCheckbox.UseVisualStyleBackColor = true;
            integralCheckbox.CheckedChanged += IntegralOnly_CheckStateChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(46, 271);
            label4.Name = "label4";
            label4.Size = new Size(192, 35);
            label4.TabIndex = 6;
            label4.Text = "Suggested type:";
            // 
            // typeData
            // 
            typeData.AutoSize = true;
            typeData.Font = new Font("Segoe UI", 15F);
            typeData.Location = new Point(249, 271);
            typeData.Name = "typeData";
            typeData.Size = new Size(200, 35);
            typeData.TabIndex = 7;
            typeData.Text = "not enough data";
            // 
            // precisionChecker
            // 
            precisionChecker.AutoSize = true;
            precisionChecker.Location = new Point(286, 237);
            precisionChecker.Name = "precisionChecker";
            precisionChecker.Size = new Size(18, 17);
            precisionChecker.TabIndex = 9;
            precisionChecker.UseVisualStyleBackColor = true;
            precisionChecker.CheckedChanged += precisionChecker_CheckedChanged;
            // 
            // MustbePrecise
            // 
            MustbePrecise.AutoSize = true;
            MustbePrecise.Font = new Font("Segoe UI", 15F);
            MustbePrecise.Location = new Point(78, 222);
            MustbePrecise.Name = "MustbePrecise";
            MustbePrecise.Size = new Size(202, 35);
            MustbePrecise.TabIndex = 8;
            MustbePrecise.Text = "Must be precise?";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(precisionChecker);
            Controls.Add(MustbePrecise);
            Controls.Add(typeData);
            Controls.Add(label4);
            Controls.Add(integralCheckbox);
            Controls.Add(label3);
            Controls.Add(maxValueTextBox);
            Controls.Add(minValueTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Numeric Type Suggester app";
            ResumeLayout(false);
            PerformLayout();
        }

       








        #endregion

        private Label label1;
        private Label label2;
        private TextBox minValueTextBox;
        private TextBox maxValueTextBox;
        private Label label3;
        private CheckBox integralCheckbox;
        private Label label4;
        private Label typeData;
        private CheckBox precisionChecker;
        private Label MustbePrecise;
    }
}
