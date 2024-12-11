using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        private readonly IDbConnectionService dbConnection;
        private int userId;

        public Form4(IDbConnectionService dbConnection, int userId)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            this.userId = userId;
            InitializeComponent();
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;

            comboBox1.Items.Add("--select");
            comboBox1.Items.Add("public");
            comboBox1.Items.Add("private");
            comboBox1.SelectedIndex = 0;

            LoadUserEvents();
        }

        private void LoadUserEvents()
        {
            string query = @"
        SELECT E.EventID, E.EventName, E.EventDate, E.Frequency, E.Duration, E.Description
        FROM Events E
        INNER JOIN UserEvents UE ON E.EventID = UE.EventID
        WHERE UE.UserID = @UserID";

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand mySqlCommand = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    mySqlCommand.Parameters.AddWithValue("@UserID", userId);

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.HasRows)
                        {
                            flowLayoutPanel1.Controls.Clear(); // Clear previous items

                            while (mySqlDataReader.Read())
                            {
                                // Create a card for each event
                                Panel card = new Panel
                                {
                                    Width = 450,
                                    Height = 150,
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Padding = new Padding(10),
                                    Margin = new Padding(10),
                                    Cursor = Cursors.Hand // Indicate that it's clickable
                                };

                                // Add a click event to the card
                                int eventId = Convert.ToInt32(mySqlDataReader["EventID"]);
                                card.Click += (s, e) =>
                                {
                                    OpenEventForm(eventId);
                                };

                                // Create a TableLayoutPanel for better layout
                                TableLayoutPanel table = new TableLayoutPanel
                                {
                                    ColumnCount = 1,
                                    RowCount = 4,
                                    Dock = DockStyle.Fill,
                                    AutoSize = true
                                };

                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                                // Add event details to the table
                                Label lblName = new Label
                                {
                                    Text = $"Name: {mySqlDataReader["EventName"]}",
                                    AutoSize = true,
                                    Font = new Font("Arial", 10, FontStyle.Bold)
                                };
                                Label lblDate = new Label
                                {
                                    Text = $"Date: {Convert.ToDateTime(mySqlDataReader["EventDate"]).ToLongDateString()}",
                                    AutoSize = true
                                };
                                Label lblFrequency = new Label
                                {
                                    Text = $"Recurring: {mySqlDataReader["Frequency"]}",
                                    AutoSize = true
                                };
                                Label lblDuration = new Label
                                {
                                    Text = $"Duration: {mySqlDataReader["Duration"]} hours",
                                    AutoSize = true
                                };

                                lblName.Click += (s, e) => OpenEventForm(eventId);
                                lblDate.Click += (s, e) => OpenEventForm(eventId);
                                lblFrequency.Click += (s, e) => OpenEventForm(eventId);
                                lblDuration.Click += (s, e) => OpenEventForm(eventId);

                                table.Controls.Add(lblName);
                                table.Controls.Add(lblDate);
                                table.Controls.Add(lblFrequency);
                                table.Controls.Add(lblDuration);

                                card.Controls.Add(table);

                                flowLayoutPanel1.Controls.Add(card);
                            }
                        }
                        else
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void OpenEventForm(int eventId)
        {
            Form5 form5 = new Form5(dbConnection, eventId, userId);
            form5.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(dbConnection, userId);
            form1.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(dbConnection, userId);
            form7.ShowDialog();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Trim();
            LoadFilteredEvents(filterText);
        }

        private void LoadFilteredEvents(string filter)
        {
            string query = @"
                SELECT E.EventID, E.EventName, E.EventDate, E.Frequency, E.Duration, E.Description
                FROM Events E
                INNER JOIN UserEvents UE ON E.EventID = UE.EventID
                WHERE UE.UserID = @UserID AND E.EventName LIKE @Filter";

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand mySqlCommand = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    mySqlCommand.Parameters.AddWithValue("@UserID", userId);
                    mySqlCommand.Parameters.AddWithValue("@Filter", $"%{filter}%");

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        if (mySqlDataReader.HasRows)
                        {
                            while (mySqlDataReader.Read())
                            {
                                Panel card = new Panel
                                {
                                    Width = 450,
                                    Height = 150,
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Padding = new Padding(10),
                                    Margin = new Padding(10),
                                    Cursor = Cursors.Hand
                                };

                                int eventId = Convert.ToInt32(mySqlDataReader["EventID"]);
                                card.Click += (s, e) => OpenEventForm(eventId);

                                TableLayoutPanel table = new TableLayoutPanel
                                {
                                    ColumnCount = 1,
                                    RowCount = 4,
                                    Dock = DockStyle.Fill,
                                    AutoSize = true
                                };

                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                                Label lblName = new Label
                                {
                                    Text = $"Name: {mySqlDataReader["EventName"]}",
                                    AutoSize = true,
                                    Font = new Font("Arial", 10, FontStyle.Bold)
                                };
                                Label lblDate = new Label
                                {
                                    Text = $"Date: {Convert.ToDateTime(mySqlDataReader["EventDate"]).ToLongDateString()}",
                                    AutoSize = true
                                };
                                Label lblFrequency = new Label
                                {
                                    Text = $"Recurring: {mySqlDataReader["Frequency"]}",
                                    AutoSize = true
                                };
                                Label lblDuration = new Label
                                {
                                    Text = $"Duration: {mySqlDataReader["Duration"]} hours",
                                    AutoSize = true
                                };

                                lblName.Click += (s, e) => OpenEventForm(eventId);
                                lblDate.Click += (s, e) => OpenEventForm(eventId);
                                lblFrequency.Click += (s, e) => OpenEventForm(eventId);
                                lblDuration.Click += (s, e) => OpenEventForm(eventId);

                                table.Controls.Add(lblName);
                                table.Controls.Add(lblDate);
                                table.Controls.Add(lblFrequency);
                                table.Controls.Add(lblDuration);

                                card.Controls.Add(table);

                                flowLayoutPanel1.Controls.Add(card);
                            }
                        }
                        else
                        {
                            Label noEventsLabel = new Label
                            {
                                Text = "No matching events found.",
                                AutoSize = true,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Fill
                            };
                            flowLayoutPanel1.Controls.Add(noEventsLabel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();

            if (selectedOption == "--select")
            {
                LoadUserEvents();
            }
            else
            {
                LoadFilteredEventsByType(selectedOption);
            }
        }

        private void LoadFilteredEventsByType(string eventType)
        {
            int privacyValue = eventType == "public" ? 0 : 1;

            string query = @"
                SELECT E.EventID, E.EventName, E.EventDate, E.Frequency, E.Duration, E.Description
                FROM Events E
                INNER JOIN UserEvents UE ON E.EventID = UE.EventID
                WHERE UE.UserID = @UserID AND E.Privacy = @Privacy";

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand mySqlCommand = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    mySqlCommand.Parameters.AddWithValue("@UserID", userId);
                    mySqlCommand.Parameters.AddWithValue("@Privacy", privacyValue);

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        if (mySqlDataReader.HasRows)
                        {
                            while (mySqlDataReader.Read())
                            {
                                Panel card = new Panel
                                {
                                    Width = 450,
                                    Height = 150,
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Padding = new Padding(10),
                                    Margin = new Padding(10),
                                    Cursor = Cursors.Hand
                                };

                                int eventId = Convert.ToInt32(mySqlDataReader["EventID"]);
                                card.Click += (s, e) => OpenEventForm(eventId);

                                TableLayoutPanel table = new TableLayoutPanel
                                {
                                    ColumnCount = 1,
                                    RowCount = 4,
                                    Dock = DockStyle.Fill,
                                    AutoSize = true
                                };

                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                                Label lblName = new Label
                                {
                                    Text = $"Name: {mySqlDataReader["EventName"]}",
                                    AutoSize = true,
                                    Font = new Font("Arial", 10, FontStyle.Bold)
                                };
                                Label lblDate = new Label
                                {
                                    Text = $"Date: {Convert.ToDateTime(mySqlDataReader["EventDate"]).ToLongDateString()}",
                                    AutoSize = true
                                };
                                Label lblFrequency = new Label
                                {
                                    Text = $"Recurring: {mySqlDataReader["Frequency"]}",
                                    AutoSize = true
                                };
                                Label lblDuration = new Label
                                {
                                    Text = $"Duration: {mySqlDataReader["Duration"]} hours",
                                    AutoSize = true
                                };

                                lblName.Click += (s, e) => OpenEventForm(eventId);
                                lblDate.Click += (s, e) => OpenEventForm(eventId);
                                lblFrequency.Click += (s, e) => OpenEventForm(eventId);
                                lblDuration.Click += (s, e) => OpenEventForm(eventId);

                                table.Controls.Add(lblName);
                                table.Controls.Add(lblDate);
                                table.Controls.Add(lblFrequency);
                                table.Controls.Add(lblDuration);

                                card.Controls.Add(table);

                                flowLayoutPanel1.Controls.Add(card);
                            }
                        }
                        else
                        {
                            Label noEventsLabel = new Label
                            {
                                Text = "No matching events found.",
                                AutoSize = true,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Fill
                            };
                            flowLayoutPanel1.Controls.Add(noEventsLabel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            LoadUserEvents();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8(userId, dbConnection);
            form8.ShowDialog();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(dbConnection, userId);
            form7.ShowDialog();
            this.Hide();
        }
    }
}
