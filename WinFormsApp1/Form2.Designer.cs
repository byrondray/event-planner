namespace WinFormsApp1
{
    partial class Form2
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
            textBox1 = new TextBox();
            checkedListBox1 = new CheckedListBox();
            checkBox1 = new CheckBox();
            label2 = new Label();
            button1 = new Button();
            listBox1 = new ListBox();
            button2 = new Button();
            label3 = new Label();
            checkedListBox2 = new CheckedListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(166, 269);
            label1.Name = "label1";
            label1.Size = new Size(372, 41);
            label1.TabIndex = 0;
            label1.Text = "Add member by username";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(568, 269);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(356, 47);
            textBox1.TabIndex = 1;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(166, 875);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(300, 400);
            checkedListBox1.TabIndex = 2;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(482, 875);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(172, 45);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Select all";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(166, 775);
            label2.Name = "label2";
            label2.Size = new Size(990, 97);
            label2.TabIndex = 4;
            label2.Text = "Select which members you want to be admin. Admins will be able to invite other members to the event";
            // 
            // button1
            // 
            button1.Location = new Point(958, 269);
            button1.Name = "button1";
            button1.Size = new Size(188, 58);
            button1.TabIndex = 6;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 41;
            listBox1.Location = new Point(856, 875);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(300, 414);
            listBox1.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(770, 1367);
            button2.Name = "button2";
            button2.Size = new Size(386, 100);
            button2.TabIndex = 8;
            button2.Text = "Add Members";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label3.Location = new Point(44, 41);
            label3.Name = "label3";
            label3.Size = new Size(1096, 106);
            label3.TabIndex = 9;
            label3.Text = "Add members to your event";
            // 
            // checkedListBox2
            // 
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Location = new Point(166, 363);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(562, 312);
            checkedListBox2.TabIndex = 10;
            checkedListBox2.SelectedIndexChanged += checkedListBox2_SelectedIndexChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1406, 1608);
            Controls.Add(checkedListBox2);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(checkBox1);
            Controls.Add(checkedListBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Add members";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private CheckedListBox checkedListBox1;
        private CheckBox checkBox1;
        private Label label2;
        private Button button1;
        private ListBox listBox1;
        private Button button2;
        private Label label3;
        private CheckedListBox checkedListBox2;
    }
}