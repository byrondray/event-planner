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
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                            DataTable dataTable = new DataTable();
                            dataTable.Load(mySqlDataReader);
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("No events found for this user.");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                int eventId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["EventID"].Value);

                Form5 form5 = new Form5(dbConnection, eventId, userId);
                form5.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(dbConnection, userId);
            form1.ShowDialog();
            this.Hide();
        }
    }
}
