using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form7 : Form
    {
        private readonly IDbConnectionService dbConnection;
        private int userId;

        public Form7(IDbConnectionService dbConnection, int userId)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            this.userId = userId;
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            LoadPublicGroups();
        }

        private void LoadPublicGroups()
        {
            string query = "SELECT EventID, EventName, EventDate, Description FROM Events WHERE Privacy = 0";

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        while (reader.Read())
                        {
                            int eventId = Convert.ToInt32(reader["EventID"]);

                            Panel groupPanel = new Panel
                            {
                                Width = 500,
                                Height = 250,
                                BorderStyle = BorderStyle.FixedSingle,
                                Padding = new Padding(10),
                                Margin = new Padding(10),
                                Tag = eventId // Assign eventId to the entire panel
                            };
                            groupPanel.Click += GroupPanel_Click;

                            Label lblEventName = new Label
                            {
                                Text = $"Name: {reader["EventName"]}",
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                AutoSize = true
                            };
                            lblEventName.Click += (s, e) => GroupPanel_Click(groupPanel, e); // Attach panel click

                            Label lblEventDate = new Label
                            {
                                Text = $"Date: {Convert.ToDateTime(reader["EventDate"]).ToString("yyyy-MM-dd")}",
                                Font = new Font("Arial", 10),
                                AutoSize = true
                            };
                            lblEventDate.Click += (s, e) => GroupPanel_Click(groupPanel, e); // Attach panel click

                            Label lblDescription = new Label
                            {
                                Text = $"Description: {reader["Description"]}",
                                Font = new Font("Arial", 10),
                                AutoSize = true
                            };
                            lblDescription.Click += (s, e) => GroupPanel_Click(groupPanel, e); // Attach panel click

                            Button btnView = new Button
                            {
                                Text = "View",
                                Tag = eventId,
                                Dock = DockStyle.Bottom
                            };
                            btnView.Click += BtnView_Click;

                            groupPanel.Controls.Add(lblEventName);
                            groupPanel.Controls.Add(lblEventDate);
                            groupPanel.Controls.Add(lblDescription);
                            groupPanel.Controls.Add(btnView);

                            lblEventName.Location = new Point(10, 10);
                            lblEventDate.Location = new Point(10, lblEventName.Bottom + 5);
                            lblDescription.Location = new Point(10, lblEventDate.Bottom + 5);
                            btnView.Location = new Point(10, lblDescription.Bottom + 10);

                            flowLayoutPanel1.Controls.Add(groupPanel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading public groups: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }


        private void GroupPanel_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is int eventId)
            {
                Form5 form5 = new Form5(dbConnection, eventId, userId);
                form5.Show();
                this.Hide();
            }
        }


        private void BtnView_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is int eventId)
            {
                Form5 form5 = new Form5(dbConnection, eventId, userId);
                form5.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(dbConnection, userId);
            form1.Show();
            this.Hide();
        }
    }
}
