using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly IDbConnectionService dbConnection;
        private int UserId;
        List<string> meetingFrequencies = new List<string> { "--Select", "Daily", "Weekly", "Weekdays" };
        ToolTip toolTip1 = new ToolTip();

        public Form1(IDbConnectionService dbConnection, int userId)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            this.UserId = userId;
            InitializeComponent();
        }

        private int AddEventToDatabase()
        {
            string eventName = eventNameInput.Text;
            DateTime eventDate = dateTimePicker1.Value;
            string frequency = comboBox1.SelectedItem.ToString();
            int duration = trackBar1.Value;
            string description = richTextBox1.Text;
            int privacy = radioButton1.Checked ? 0 : 1;
            byte[] imageBytes = null;

            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }
            }

            string query = "INSERT INTO Events (EventName, EventDate, EventImage, Frequency, Duration, Description, Privacy) " +
                           "VALUES (@EventName, @EventDate, @EventImage, @Frequency, @Duration, @Description, @Privacy)";

            try
            {
                dbConnection.OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@EventImage", imageBytes);
                    cmd.Parameters.AddWithValue("@Frequency", frequency);
                    cmd.Parameters.AddWithValue("@Duration", duration);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Privacy", privacy);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return (int)cmd.LastInsertedId;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = meetingFrequencies;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            eventNameInput.TextChanged += textBox1_TextChanged;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;

            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            trackBar1.Minimum = 1;
            trackBar1.Maximum = 12;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 5; // Updated for radio buttons

            richTextBox1.ReadOnly = true;

            toolTip1.SetToolTip(uploadImageButton, "Click to upload a picture for the event");

            UpdateProgressBar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateRichTextBox();
            UpdateProgressBar();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UpdateRichTextBox();
            UpdateProgressBar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRichTextBox();
            UpdateProgressBar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                UpdateProgressBar();
            }
        }

        private void inviteMembersButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(eventNameInput.Text) || comboBox1.SelectedIndex == 0 || pictureBox1.Image == null || trackBar1.Value == 0 ||
                (!radioButton1.Checked && !radioButton2.Checked))
            {
                MessageBox.Show("Please complete all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int eventID = AddEventToDatabase();
            if (eventID > 0)
            {
                string eventName = eventNameInput.Text;
                Form2 f2 = new Form2(eventID, eventName, dbConnection, UserId);
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to add the event to the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRichTextBox()
        {
            richTextBox1.Clear();

            string eventName = eventNameInput.Text;
            string eventDate = dateTimePicker1.Value.ToString("MMMM dd, yyyy");
            string frequency = comboBox1.SelectedItem.ToString();
            string hours = trackBar1.Value.ToString();
            string privacy = radioButton1.Checked ? "Public" : radioButton2.Checked ? "Private" : "Not Selected";

            richTextBox1.Text = $"Name: {eventName}\n" +
                                $"Time: {eventDate}\n" +
                                $"Recurring: {frequency}\n" +
                                $"Duration: {hours} hours\n" +
                                $"Privacy: {privacy}";
        }

        private void UpdateProgressBar()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(eventNameInput.Text))
            {
                progress++;
            }

            if (comboBox1.SelectedIndex > 0)
            {
                progress++;
            }

            if (pictureBox1.Image != null)
            {
                progress++;
            }

            if (trackBar1.Value > 0)
            {
                progress++;
            }

            if (radioButton1.Checked || radioButton2.Checked) // Radio button validation
            {
                progress++;
            }

            progressBar1.Value = progress;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateRichTextBox();
            UpdateProgressBar();
        }

        private void eventNameInput_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(eventNameInput.Text, out _))
            {
                errorProvider1.SetError(eventNameInput, "Please enter a valid name");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
