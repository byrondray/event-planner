using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        private IDbConnectionService dbConnection;

        public Form3(IDbConnectionService dbConnection)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
        }

        private void UpdateGridView()
        {
            string query = "SELECT * FROM Users";
            MySqlCommand mySqlCommand = new MySqlCommand(query, dbConnection.GetConnection());

            try
            {
                dbConnection.OpenConnection();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader != null)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(mySqlDataReader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void checkUsernameAndPassword()
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                throw new Exception("Please enter a valid password.");
            }

            if (!Regex.IsMatch(maskedTextBox1.Text, @"\d"))
            {
                throw new Exception("Password must contain at least one number.");
            }
        }

        private void checkEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new Exception("Please enter a valid email address.");
            }
        }

        private bool CheckUserExists(string username, string email)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username OR Email = @Email";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Email", email);

            dbConnection.OpenConnection();
            int userExists = Convert.ToInt32(cmd.ExecuteScalar());
            dbConnection.CloseConnection();

            return userExists > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "CREATE TABLE IF NOT EXISTS Users (UserID INT PRIMARY KEY AUTO_INCREMENT, Username VARCHAR(255) NOT NULL, Email VARCHAR(255) NOT NULL, Password VARCHAR(255) NOT NULL, UNIQUE(Username), UNIQUE(Email))";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

            try
            {
                dbConnection.OpenConnection();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Users table has been created.");
                UpdateGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(dbConnection);
            f6.Show();
            this.Hide();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string newPassword = maskedTextBox1.Text;

            string query = "UPDATE Users SET Password = @NewPassword, Email = @NewEmail WHERE Username = @Username";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

            try
            {
                checkUsernameAndPassword();
                dbConnection.OpenConnection();

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User password and email updated successfully.");
                    UpdateGridView();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;

            string query = "DELETE FROM Users WHERE Username = @Username";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

            try
            {
                dbConnection.OpenConnection();
                cmd.Parameters.AddWithValue("@Username", username);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User deleted successfully.");
                    UpdateGridView();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double i;

            if (double.TryParse(textBox1.Text, out i))
            {
                errorProvider1.SetError(textBox1, "Please enter a valid name");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = maskedTextBox1.Text;

            string query = "SELECT UserID FROM Users WHERE (Username = @Username) AND Password = @Password";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

            try
            {
                dbConnection.OpenConnection();

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int userId = Convert.ToInt32(result);

                    Form4 form1 = new Form4(dbConnection, userId);
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username/email or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public static implicit operator Form3(Form4 v)
        {
            throw new NotImplementedException();
        }
    }
}
