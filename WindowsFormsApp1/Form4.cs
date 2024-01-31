using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void display()
        {
            string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Rendon;Integrated Security=True";
            string query = "select * from NotebooksAndPaper";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].Width = 100;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string item = textBox2.Text;
            int qty = int.Parse(textBox3.Text);
            decimal price = decimal.Parse(textBox4.Text);
            int cat_id = 3;

            string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Rendon;Integrated Security=True";
            string query = "INSERT INTO ArtsAndCraftsSupplies (arts_crafts_id, item_name, quantity, price, category_id) VALUES (@id, @item, @qty, @price, @cat_id)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@item", item);
                    command.Parameters.AddWithValue("@qty", qty);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@cat_id", cat_id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Call display method to update UI or refresh data grid
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Rendon;Integrated Security=True";
                string query = "UPDATE ArtsAndCraftsSupplies SET item_name = @item, quantity = @qty, price = @price, category_id = @cat_id WHERE arts_crafts_id = @idToUpdate";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idToUpdate", int.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@item", textBox2.Text);
                    command.Parameters.AddWithValue("@qty", int.Parse(textBox3.Text));
                    command.Parameters.AddWithValue("@price", decimal.Parse(textBox4.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                    display();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idToDelete = int.Parse(textBox1.Text); // Assuming textBox1 contains the ID of the item to delete

            string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=Rendon;Integrated Security=True";
            string query = "DELETE FROM ArtsAndCraftsSupplies WHERE arts_crafts_id = @idToDelete";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idToDelete", idToDelete);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Optionally, you may want to clear the textboxes after deletion
            display();
            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Fill textboxes with data from the selected row
                textBox1.Text = selectedRow.Cells["arts_crafts_id "].Value.ToString();
                textBox2.Text = selectedRow.Cells["item_name"].Value.ToString();
                textBox3.Text = selectedRow.Cells["quantity"].Value.ToString();
                textBox4.Text = selectedRow.Cells["price"].Value.ToString();
            }
        }
        
    }
}
