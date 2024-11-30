namespace WinFormsApp1
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            eventPlanLabel = new Label();
            eventNameInput = new TextBox();
            label1 = new Label();
            eventDateLabel = new Label();
            imageUploadLabel = new Label();
            uploadImageButton = new Button();
            dateTimePicker1 = new DateTimePicker();
            richTextBox1 = new RichTextBox();
            inviteMembersButton = new Button();
            comboBox1 = new ComboBox();
            meetingOccurButton = new Label();
            progressBar1 = new ProgressBar();
            label2 = new Label();
            trackBar1 = new TrackBar();
            label3 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(962, 157);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(446, 460);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // eventPlanLabel
            // 
            eventPlanLabel.AutoSize = true;
            eventPlanLabel.Location = new Point(63, 157);
            eventPlanLabel.Name = "eventPlanLabel";
            eventPlanLabel.Size = new Size(446, 41);
            eventPlanLabel.TabIndex = 1;
            eventPlanLabel.Text = "What is the name of your event?";
            // 
            // eventNameInput
            // 
            eventNameInput.Location = new Point(552, 157);
            eventNameInput.Name = "eventNameInput";
            eventNameInput.Size = new Size(360, 47);
            eventNameInput.TabIndex = 2;
            eventNameInput.TextChanged += eventNameInput_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(681, 196);
            label1.Name = "label1";
            label1.Size = new Size(0, 41);
            label1.TabIndex = 3;
            // 
            // eventDateLabel
            // 
            eventDateLabel.AutoSize = true;
            eventDateLabel.Location = new Point(63, 234);
            eventDateLabel.Name = "eventDateLabel";
            eventDateLabel.Size = new Size(286, 41);
            eventDateLabel.TabIndex = 4;
            eventDateLabel.Text = "When is your event?";
            // 
            // imageUploadLabel
            // 
            imageUploadLabel.AutoSize = true;
            imageUploadLabel.Location = new Point(63, 323);
            imageUploadLabel.Name = "imageUploadLabel";
            imageUploadLabel.Size = new Size(432, 41);
            imageUploadLabel.TabIndex = 6;
            imageUploadLabel.Text = "Upload a picture for your event";
            // 
            // uploadImageButton
            // 
            uploadImageButton.Location = new Point(533, 314);
            uploadImageButton.Name = "uploadImageButton";
            uploadImageButton.Size = new Size(248, 58);
            uploadImageButton.TabIndex = 7;
            uploadImageButton.Text = "Upload Image";
            uploadImageButton.UseVisualStyleBackColor = true;
            uploadImageButton.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(394, 234);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(500, 47);
            dateTimePicker1.TabIndex = 8;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(65, 620);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(697, 294);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // inviteMembersButton
            // 
            inviteMembersButton.Location = new Point(1144, 947);
            inviteMembersButton.Name = "inviteMembersButton";
            inviteMembersButton.Size = new Size(251, 58);
            inviteMembersButton.TabIndex = 10;
            inviteMembersButton.Text = "Start Inviting Members";
            inviteMembersButton.UseVisualStyleBackColor = true;
            inviteMembersButton.Click += inviteMembersButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(610, 408);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(302, 49);
            comboBox1.TabIndex = 11;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // meetingOccurButton
            // 
            meetingOccurButton.AutoSize = true;
            meetingOccurButton.Location = new Point(63, 408);
            meetingOccurButton.Name = "meetingOccurButton";
            meetingOccurButton.Size = new Size(503, 41);
            meetingOccurButton.TabIndex = 12;
            meetingOccurButton.Text = "How often will this meeting happen?";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(65, 947);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(697, 58);
            progressBar1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 500);
            label2.Name = "label2";
            label2.Size = new Size(385, 41);
            label2.TabIndex = 14;
            label2.Text = "How long will the event be?";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(479, 500);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(260, 114);
            trackBar1.TabIndex = 15;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.9000006F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(65, 41);
            label3.Name = "label3";
            label3.Size = new Size(639, 72);
            label3.TabIndex = 16;
            label3.Text = "Start by creating an event";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1455, 1145);
            Controls.Add(label3);
            Controls.Add(trackBar1);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Controls.Add(meetingOccurButton);
            Controls.Add(comboBox1);
            Controls.Add(inviteMembersButton);
            Controls.Add(richTextBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(uploadImageButton);
            Controls.Add(imageUploadLabel);
            Controls.Add(eventDateLabel);
            Controls.Add(label1);
            Controls.Add(eventNameInput);
            Controls.Add(eventPlanLabel);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label eventPlanLabel;
        private TextBox eventNameInput;
        private Label label1;
        private Label eventDateLabel;
        private Label imageUploadLabel;
        private Button uploadImageButton;
        private DateTimePicker dateTimePicker1;
        private RichTextBox richTextBox1;
        private Button inviteMembersButton;
        private ComboBox comboBox1;
        private Label meetingOccurButton;
        private ProgressBar progressBar1;
        private Label label2;
        private TrackBar trackBar1;
        private Label label3;
        private ErrorProvider errorProvider1;
    }
}
