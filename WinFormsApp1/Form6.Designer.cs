namespace WinFormsApp1
{
    partial class Form6
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            button5 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            button2 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label4.Location = new Point(170, 62);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(1201, 106);
            label4.TabIndex = 22;
            label4.Text = "Welcome to the Event Planner!";
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14F);
            button5.Location = new Point(297, 543);
            button5.Margin = new Padding(6);
            button5.Name = "button5";
            button5.Size = new Size(298, 78);
            button5.TabIndex = 21;
            button5.Text = "Login";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14F);
            textBox2.Location = new Point(468, 330);
            textBox2.Margin = new Padding(6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(723, 70);
            textBox2.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(170, 330);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(169, 72);
            label3.TabIndex = 19;
            label3.Text = "Email:";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Font = new Font("Segoe UI", 14F);
            maskedTextBox1.Location = new Point(468, 420);
            maskedTextBox1.Margin = new Padding(6);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.PasswordChar = '*';
            maskedTextBox1.Size = new Size(723, 70);
            maskedTextBox1.TabIndex = 18;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(682, 543);
            button2.Margin = new Padding(6);
            button2.Name = "button2";
            button2.Size = new Size(298, 78);
            button2.TabIndex = 17;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(468, 246);
            textBox1.Margin = new Padding(6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(723, 70);
            textBox1.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(170, 420);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(265, 72);
            label2.TabIndex = 15;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(170, 246);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(282, 72);
            label1.TabIndex = 14;
            label1.Text = "Username:";
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1497, 718);
            Controls.Add(label4);
            Controls.Add(button5);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(maskedTextBox1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(6);
            Name = "Form6";
            Text = "Event Planner - Register";
            Load += Form6_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Button button5;
        private TextBox textBox2;
        private Label label3;
        private MaskedTextBox maskedTextBox1;
        private Button button2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
    }
}
