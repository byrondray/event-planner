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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
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
            button5 = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(170, 246);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(282, 72);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(170, 369);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(265, 72);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(468, 246);
            textBox1.Margin = new Padding(6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(590, 70);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(680, 512);
            button2.Margin = new Padding(6);
            button2.Name = "button2";
            button2.Size = new Size(298, 78);
            button2.TabIndex = 5;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Font = new Font("Segoe UI", 14F);
            maskedTextBox1.Location = new Point(468, 369);
            maskedTextBox1.Margin = new Padding(6);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.PasswordChar = '*';
            maskedTextBox1.Size = new Size(590, 70);
            maskedTextBox1.TabIndex = 9;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14F);
            button5.Location = new Point(298, 512);
            button5.Margin = new Padding(6);
            button5.Name = "button5";
            button5.Size = new Size(298, 78);
            button5.TabIndex = 12;
            button5.Text = "Login";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label4.Location = new Point(170, 62);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(1201, 106);
            label4.TabIndex = 13;
            label4.Text = "Welcome to the Event Planner!";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1497, 718);
            Controls.Add(label4);
            Controls.Add(button5);
            Controls.Add(maskedTextBox1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(6);
            Name = "Form3";
            Text = "Event Planner";
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
        private Button button5;
        private Label label4;
    }
}
