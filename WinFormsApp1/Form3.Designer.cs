namespace WinFormsApp1
{
    partial class Form3
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            maskedTextBox1 = new MaskedTextBox();
            errorProvider1 = new ErrorProvider(components);
            label3 = new Label();
            textBox2 = new TextBox();
            button5 = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 153);
            label1.Name = "label1";
            label1.Size = new Size(152, 41);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 312);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(143, 41);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(275, 153);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 47);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(680, 233);
            button2.Name = "button2";
            button2.Size = new Size(272, 58);
            button2.TabIndex = 5;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(275, 309);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.PasswordChar = '*';
            maskedTextBox1.Size = new Size(311, 47);
            maskedTextBox1.TabIndex = 9;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 233);
            label3.Name = "label3";
            label3.Size = new Size(88, 41);
            label3.TabIndex = 10;
            label3.Text = "Email";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(275, 233);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(311, 47);
            textBox2.TabIndex = 11;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button5
            // 
            button5.Location = new Point(680, 153);
            button5.Name = "button5";
            button5.Size = new Size(272, 58);
            button5.TabIndex = 12;
            button5.Text = "Login";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(42, 51);
            label4.Name = "label4";
            label4.Size = new Size(989, 54);
            label4.TabIndex = 13;
            label4.Text = "Welcome to the Event Planner. Please login or register.";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1093, 533);
            Controls.Add(label4);
            Controls.Add(button5);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(maskedTextBox1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button2;
        private MaskedTextBox maskedTextBox1;
        private ErrorProvider errorProvider1;
        private TextBox textBox2;
        private Label label3;
        private Button button5;
        private Label label4;
    }
}