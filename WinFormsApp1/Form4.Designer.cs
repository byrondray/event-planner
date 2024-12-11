namespace WinFormsApp1
{
    partial class Form4
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
            label1 = new Label();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(107, 55);
            label1.Name = "label1";
            label1.Size = new Size(685, 106);
            label1.TabIndex = 0;
            label1.Text = "View Your Events";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(122, 1066);
            button1.Name = "button1";
            button1.Size = new Size(455, 107);
            button1.TabIndex = 2;
            button1.Text = "Create a new event";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(122, 343);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1790, 682);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(122, 227);
            label2.Name = "label2";
            label2.Size = new Size(290, 60);
            label2.TabIndex = 5;
            label2.Text = "Search Events";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(418, 238);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(342, 47);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(825, 227);
            label3.Name = "label3";
            label3.Size = new Size(258, 60);
            label3.TabIndex = 7;
            label3.Text = "Filter Events";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1103, 236);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(302, 49);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Location = new Point(1453, 232);
            button3.Name = "button3";
            button3.Size = new Size(188, 58);
            button3.TabIndex = 9;
            button3.Text = "Reset Filters";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 13F);
            button4.Location = new Point(1176, 1065);
            button4.Name = "button4";
            button4.Size = new Size(349, 108);
            button4.TabIndex = 10;
            button4.Text = "Add Friends";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ButtonHighlight;
            button5.Font = new Font("Segoe UI", 13F);
            button5.Location = new Point(635, 1065);
            button5.Name = "button5";
            button5.Size = new Size(475, 107);
            button5.TabIndex = 11;
            button5.Text = "Find Public Events";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(2069, 1277);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form4";
            Text = "View your events";
            Load += Form4_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private ComboBox comboBox1;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}