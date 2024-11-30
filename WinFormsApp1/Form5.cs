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

        public Form5(IDbConnectionService dbConnection, int eventId, int userId)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            this.eventId = eventId;
            this.userId = userId;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            richTextBox1.ReadOnly = true;

            CheckIfUserIsAdmin();

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
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No users found for this event.");
                        }
                        else
                        {
                            dataGridView1.DataSource = dataTable;

                            dataGridView1.Columns["UserName"].HeaderText = "User Name";
                            dataGridView1.Columns["IsAdmin"].HeaderText = "Admin Status";
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
                            richTextBox1.Clear();

                            richTextBox1.Text = $"Event Name: {reader["EventName"]}\n" +
                                                $"Event Date: {Convert.ToDateTime(reader["EventDate"]).ToString("yyyy-MM-dd")}\n" +
                                                $"Frequency: {reader["Frequency"]}\n" +
                                                $"Duration: {reader["Duration"]} hours\n" +
                                                $"Description: {reader["Description"]}";

                            if (reader["EventImage"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["EventImage"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pictureBox1.Image = null;
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
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
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
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
    }
}
