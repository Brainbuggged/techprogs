namespace TechProg6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputTxtBox = new System.Windows.Forms.RichTextBox();
            this.task1Btn = new System.Windows.Forms.Button();
            this.outputTxtBox = new System.Windows.Forms.TextBox();
            this.task2Btn = new System.Windows.Forms.Button();
            this.task3Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputTxtBox
            // 
            this.inputTxtBox.Location = new System.Drawing.Point(29, 40);
            this.inputTxtBox.Name = "inputTxtBox";
            this.inputTxtBox.Size = new System.Drawing.Size(291, 58);
            this.inputTxtBox.TabIndex = 0;
            this.inputTxtBox.Text = "";
            // 
            // task1Btn
            // 
            this.task1Btn.Location = new System.Drawing.Point(29, 246);
            this.task1Btn.Name = "task1Btn";
            this.task1Btn.Size = new System.Drawing.Size(75, 23);
            this.task1Btn.TabIndex = 1;
            this.task1Btn.Text = "Check1";
            this.task1Btn.UseVisualStyleBackColor = true;
            this.task1Btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // outputTxtBox
            // 
            this.outputTxtBox.Location = new System.Drawing.Point(29, 117);
            this.outputTxtBox.Multiline = true;
            this.outputTxtBox.Name = "outputTxtBox";
            this.outputTxtBox.Size = new System.Drawing.Size(291, 123);
            this.outputTxtBox.TabIndex = 2;
            // 
            // task2Btn
            // 
            this.task2Btn.Location = new System.Drawing.Point(139, 246);
            this.task2Btn.Name = "task2Btn";
            this.task2Btn.Size = new System.Drawing.Size(75, 23);
            this.task2Btn.TabIndex = 3;
            this.task2Btn.Text = "Check2";
            this.task2Btn.UseVisualStyleBackColor = true;
            this.task2Btn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // task3Btn
            // 
            this.task3Btn.Location = new System.Drawing.Point(245, 246);
            this.task3Btn.Name = "task3Btn";
            this.task3Btn.Size = new System.Drawing.Size(75, 23);
            this.task3Btn.TabIndex = 4;
            this.task3Btn.Text = "Check3";
            this.task3Btn.UseVisualStyleBackColor = true;
            this.task3Btn.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 311);
            this.Controls.Add(this.task3Btn);
            this.Controls.Add(this.task2Btn);
            this.Controls.Add(this.outputTxtBox);
            this.Controls.Add(this.task1Btn);
            this.Controls.Add(this.inputTxtBox);
            this.Name = "Form1";
            this.Text = "Regex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox inputTxtBox;
        private System.Windows.Forms.Button task1Btn;
        private System.Windows.Forms.TextBox outputTxtBox;
        private System.Windows.Forms.Button task2Btn;
        private System.Windows.Forms.Button task3Btn;
    }
}

