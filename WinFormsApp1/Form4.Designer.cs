﻿namespace WinFormsApp1
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
            button2 = new Button();
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
            button1.Location = new Point(107, 906);
            button1.Name = "button1";
            button1.Size = new Size(455, 107);
            button1.TabIndex = 2;
            button1.Text = "Create a new event";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(107, 183);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1790, 682);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(644, 906);
            button2.Name = "button2";
            button2.Size = new Size(444, 107);
            button2.TabIndex = 4;
            button2.Text = "Find public events to join";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(2069, 1096);
            Controls.Add(button2);
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
        private Button button2;
    }
}