namespace WinFormsApp1
{
    partial class Form5
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
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanelDetails = new FlowLayoutPanel();
            panel1 = new Panel();
            picturePanel = new Panel();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(98, 57);
            label1.Name = "label1";
            label1.Size = new Size(607, 106);
            label1.TabIndex = 0;
            label1.Text = "Viewing Group";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(903, 240);
            label2.Name = "label2";
            label2.Size = new Size(443, 60);
            label2.TabIndex = 4;
            label2.Text = "Add another member";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1355, 253);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(390, 47);
            textBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(1774, 240);
            button1.Name = "button1";
            button1.Size = new Size(205, 79);
            button1.TabIndex = 6;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(912, 354);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1067, 732);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // flowLayoutPanelDetails
            // 
            flowLayoutPanelDetails.Location = new Point(98, 276);
            flowLayoutPanelDetails.Name = "flowLayoutPanelDetails";
            flowLayoutPanelDetails.Size = new Size(585, 375);
            flowLayoutPanelDetails.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Location = new Point(1915, 1054);
            panel1.Name = "panel1";
            panel1.Size = new Size(8, 8);
            panel1.TabIndex = 9;
            // 
            // picturePanel
            // 
            picturePanel.Location = new Point(98, 762);
            picturePanel.Name = "picturePanel";
            picturePanel.Size = new Size(701, 685);
            picturePanel.TabIndex = 10;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13F);
            button2.Location = new Point(1762, 1132);
            button2.Name = "button2";
            button2.Size = new Size(217, 113);
            button2.TabIndex = 11;
            button2.Text = "Export";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13F);
            button3.Location = new Point(1468, 1132);
            button3.Name = "button3";
            button3.Size = new Size(240, 113);
            button3.TabIndex = 12;
            button3.Text = "Join";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(2171, 1524);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(picturePanel);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanelDetails);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form5";
            Text = "Viewing Group";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanelDetails;
        private Panel panel1;
        private Panel picturePanel;
        private Button button2;
        private Button button3;
    }
}