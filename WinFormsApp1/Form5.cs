using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        private readonly IDbConnectionService dbConnection;
        private int eventId;
        private int userId;
        private bool isAdmin;

        private bool isResizing = false;
        private Point lastMousePosition;

        public Form5(IDbConnectionService dbConnection, int eventId, int userId)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            this.eventId = eventId;
            this.userId = userId;
            InitializeComponent();

            picturePanel.MouseDown += PicturePanel_MouseDown;
            picturePanel.MouseMove += PicturePanel_MouseMove;
            picturePanel.MouseUp += PicturePanel_MouseUp;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            CheckIfUserIsAdmin();

            flowLayoutPanel1.AutoScroll = true;

            label2.Visible = isAdmin;
            textBox1.Visible = isAdmin;
            button1.Visible = isAdmin;

            LoadEventDetails();
            LoadEventUsers();
        }

        private void CheckIfUserIsAdmin()
        {
            string query = @"
                SELECT IsAdmin
                FROM UserEvents
                WHERE UserID = @UserID AND EventID = @EventID";

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    object result = cmd.ExecuteScalar();
                    isAdmin = result != null && Convert.ToBoolean(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void LoadEventUsers()
        {
            string usersQuery = @"
                SELECT U.UserName, UE.IsAdmin
                FROM UserEvents UE
                INNER JOIN Users U ON UE.UserID = U.UserID
                WHERE UE.EventID = @EventID";

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(usersQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        while (reader.Read())
                        {
                            Panel card = new Panel
                            {
                                Width = 300,
                                Height = 100,
                                BorderStyle = BorderStyle.FixedSingle,
                                Padding = new Padding(10),
                                Margin = new Padding(10)
                            };

                            Label lblUserName = new Label
                            {
                                Text = $"Name: {reader["UserName"]}",
                                AutoSize = true,
                                Font = new Font("Arial", 10, FontStyle.Bold)
                            };
                            Label lblIsAdmin = new Label
                            {
                                Text = $"Admin: {(Convert.ToBoolean(reader["IsAdmin"]) ? "Yes" : "No")}",
                                AutoSize = true
                            };

                            card.Controls.Add(lblUserName);
                            card.Controls.Add(lblIsAdmin);

                            flowLayoutPanel1.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void LoadEventDetails()
        {
            string eventQuery = @"
        SELECT EventID, EventName, EventDate, Frequency, Duration, Description, EventImage
        FROM Events
        WHERE EventID = @EventID";

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(eventQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            flowLayoutPanelDetails.Controls.Clear();

                            AddDetailLabel("Event Name:", reader["EventName"].ToString());
                            AddDetailLabel("Event Date:", Convert.ToDateTime(reader["EventDate"]).ToString("yyyy-MM-dd"));

                            AddDetailLabel("Frequency:", reader["Frequency"].ToString());
                            AddDetailLabel("Duration:", $"{reader["Duration"]} hours");

                            string description = reader["Description"].ToString();
                            if (description.Contains("Name:") && description.Contains("Recurring:"))
                            {
                                description = "There is no description for this event";
                            }

                            AddDetailLabel("Description:", description);

                            if (reader["EventImage"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["EventImage"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    Image image = Image.FromStream(ms);

                                    picturePanel.Controls.Clear();

                                    PictureBox pictureBox = new PictureBox
                                    {
                                        Image = image,
                                        SizeMode = PictureBoxSizeMode.AutoSize
                                    };

                                    picturePanel.Controls.Add(pictureBox);
                                    picturePanel.AutoScroll = true;
                                }
                            }
                            else
                            {
                                picturePanel.Controls.Clear();
                                Label noImageLabel = new Label
                                {
                                    Text = "No image available",
                                    AutoSize = true,
                                    Dock = DockStyle.Fill,
                                    TextAlign = ContentAlignment.MiddleCenter
                                };
                                picturePanel.Controls.Add(noImageLabel);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Event not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void AddDetailLabel(string labelText, string valueText)
        {
            Label label = new Label
            {
                Text = $"{labelText} {valueText}",
                AutoSize = true,
                Margin = new Padding(5),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            flowLayoutPanelDetails.Controls.Add(label);
        }


        private void PicturePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Location.X >= picturePanel.Width - 10 && e.Location.Y >= picturePanel.Height - 10)
            {
                isResizing = true;
                lastMousePosition = e.Location;
            }
        }

        private void PicturePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                picturePanel.Width += e.X - lastMousePosition.X;
                picturePanel.Height += e.Y - lastMousePosition.Y;
                lastMousePosition = e.Location;
            }
            else if (e.Location.X >= picturePanel.Width - 10 && e.Location.Y >= picturePanel.Height - 10)
            {
                picturePanel.Cursor = Cursors.SizeNWSE;
            }
            else
            {
                picturePanel.Cursor = Cursors.Default;
            }
        }

        private void PicturePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isResizing = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userNameToAdd = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(userNameToAdd))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            string addUserQuery = @"
                INSERT INTO UserEvents (UserID, EventID, IsAdmin)
                SELECT UserID, @EventID, 0 FROM Users WHERE UserName = @UserName";

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(addUserQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    cmd.Parameters.AddWithValue("@UserName", userNameToAdd);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully to the group.");
                        LoadEventUsers();
                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("User not found or already in the group.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Event_{eventId}_Details.csv");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Event Details:");
                    writer.WriteLine("Name,Date,Frequency,Duration,Description");

                    foreach (Control control in flowLayoutPanelDetails.Controls)
                    {
                        if (control is Label label)
                        {
                            writer.WriteLine(label.Text.Replace(":", ",").Replace("\n", ""));
                        }
                    }

                    writer.WriteLine("\nInvited Members:");
                    writer.WriteLine("Username,IsAdmin");

                    foreach (Control card in flowLayoutPanel1.Controls)
                    {
                        string username = "";
                        string isAdmin = "";

                        foreach (Control label in card.Controls)
                        {
                            if (label is Label lbl)
                            {
                                if (lbl.Text.StartsWith("Name:"))
                                    username = lbl.Text.Substring(6);
                                else if (lbl.Text.StartsWith("Admin:"))
                                    isAdmin = lbl.Text.Substring(7);
                            }
                        }

                        writer.WriteLine($"{username},{isAdmin}");
                    }
                }

                MessageBox.Show($"Details exported successfully to {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
