using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        private IDbConnectionService dbConnection;

        public Form6(IDbConnectionService dbConnection)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            maskedTextBox1.PasswordChar = '*';
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


        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(dbConnection);
            f3.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string email = textBox2.Text;
            string password = maskedTextBox1.Text;

            string insertQuery = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";
            string getIdQuery = "SELECT LAST_INSERT_ID()";
            MySqlCommand insertCmd = new MySqlCommand(insertQuery, dbConnection.GetConnection());
            MySqlCommand getIdCmd = new MySqlCommand(getIdQuery, dbConnection.GetConnection());

            try
            {
                checkUsernameAndPassword();
                checkEmail(email);

                if (CheckUserExists(username, email))
                {
                    MessageBox.Show("Username or email already exists. Please use a different one.");
                    return;
                }

                dbConnection.OpenConnection();

                insertCmd.Parameters.AddWithValue("@Username", username);
                insertCmd.Parameters.AddWithValue("@Email", email);
                insertCmd.Parameters.AddWithValue("@Password", password);
                insertCmd.ExecuteNonQuery();

                int userId = Convert.ToInt32(getIdCmd.ExecuteScalar());

                Form4 form4 = new Form4(dbConnection, userId);
                form4.Show();
                this.Close();
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

    }
}
