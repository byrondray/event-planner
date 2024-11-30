using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private readonly IDbConnectionService dbConnection;
        private int eventID;
        private int userId;

        public Form2(int eventId, string eventName, IDbConnectionService dbConnection, int userId)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            InitializeComponent();
            this.eventID = eventId;
            label3.Text = $"Add members to: {eventName}";
            this.userId = userId;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string query = "SELECT Username FROM Users WHERE UserID = @UserID";
            try
            {
                dbConnection.OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string username = result.ToString();
                        checkedListBox1.Items.Add(username);
                        checkedListBox1.SetItemChecked(0, true);
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

            listBox1.Items.Clear();
            listBox1.Items.Add("Admin:");
        }


        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(() =>
            {
                string selectedItem = checkedListBox1.Items[e.Index].ToString();

                if (e.NewValue == CheckState.Checked)
                {
                    if (!listBox1.Items.Contains(selectedItem))
                    {
                        listBox1.Items.Add(selectedItem);
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    listBox1.Items.Remove(selectedItem);
                }
            }));
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Admin:");

            foreach (var item in checkedListBox1.CheckedItems)
            {
                listBox1.Items.Add(item.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }

            UpdateListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool success = AddMembersToDatabase();

            if (success)
            {
                MessageBox.Show("Members added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form4 form3 = new Form4(dbConnection, userId);
                form3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to add members to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AddMembersToDatabase()
        {
            try
            {
                dbConnection.OpenConnection();

                foreach (var item in checkedListBox1.Items)
                {
                    string email = item.ToString();
                    bool isAdmin = checkedListBox1.CheckedItems.Contains(item);

                    int userId = GetUserId(email);

                    string query = "INSERT INTO UserEvents (UserID, EventID, IsAdmin) VALUES (@UserID, @EventID, @IsAdmin) " +
                                   "ON DUPLICATE KEY UPDATE IsAdmin = @IsAdmin";

                    using (MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@EventID", eventID);
                        cmd.Parameters.AddWithValue("@IsAdmin", isAdmin);

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }


        private int GetUserId(string email)
        {
            string checkUserQuery = "SELECT UserID FROM Users WHERE Username = @Username";

            try
            {
                using (MySqlCommand checkCmd = new MySqlCommand(checkUserQuery, dbConnection.GetConnection()))
                {
                    checkCmd.Parameters.AddWithValue("@Username", email);
                    object result = checkCmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception($"User with email {email} not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string getUserByUsernameQuery = "SELECT Username FROM Users WHERE Username = @Username";
            string username = textBox1.Text;

            try
            {
                dbConnection.OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(getUserByUsernameQuery, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        checkedListBox1.Items.Add(username);
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
    }
}
