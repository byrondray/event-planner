using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form8 : Form
    {
        private readonly IDbConnectionService dbConnection;
        private int userId;

        public Form8(int userId, IDbConnectionService dbConnection)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            this.userId = userId;
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadFriends();
        }

        private void LoadFriends()
        {
            string getFriendsQuery = @"
                SELECT U.Username 
                FROM Friends F
                INNER JOIN Users U ON F.FriendID = U.UserID
                WHERE F.UserID = @UserID";

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(getFriendsQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        while (reader.Read())
                        {
                            string friendUsername = reader["Username"].ToString();

                            Label friendLabel = new Label
                            {
                                Text = friendUsername,
                                AutoSize = true,
                                Font = new Font("Arial", 12, FontStyle.Regular),
                                Margin = new Padding(5)
                            };

                            flowLayoutPanel1.Controls.Add(friendLabel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading friends: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string getUserByUsernameQuery = "SELECT UserID FROM Users WHERE Username = @Username";
            string username = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dbConnection.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(getUserByUsernameQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int friendId = Convert.ToInt32(result);

                        AddFriend(userId, friendId);

                        LoadFriends();

                        MessageBox.Show($"{username} has been added as a friend.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AddFriend(int userId, int friendId)
        {
            string addFriendQuery = @"
                INSERT INTO Friends (UserID, FriendID) 
                VALUES (@UserID, @FriendID)
                ON DUPLICATE KEY UPDATE UserID = UserID";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(addFriendQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@FriendID", friendId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding friend: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(dbConnection, userId);
            f4.Show();
            this.Hide();
        }
    }
}
