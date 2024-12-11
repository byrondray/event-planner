namespace WinFormsApp1
{
    partial class Form8
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            textBox1 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(52, 68);
            label1.Name = "label1";
            label1.Size = new Size(496, 106);
            label1.TabIndex = 0;
            label1.Text = "Add Friends";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(69, 216);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1170, 409);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(523, 765);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(274, 47);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 768);
            label2.Name = "label2";
            label2.Size = new Size(337, 41);
            label2.TabIndex = 3;
            label2.Text = "Add friend by username";
            // 
            // button1
            // 
            button1.Location = new Point(818, 745);
            button1.Name = "button1";
            button1.Size = new Size(281, 86);
            button1.TabIndex = 4;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(69, 871);
            button2.Name = "button2";
            button2.Size = new Size(252, 95);
            button2.TabIndex = 5;
            button2.Text = "Home";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1378, 1013);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Name = "Form8";
            Text = "Add Friends";
            Load += Form8_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBox1;
        private Label label2;
        private Button button1;
        private Button button2;
    }
}