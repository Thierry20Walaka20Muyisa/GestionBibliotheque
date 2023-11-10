using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class frmEleve : Form
    {
        public frmEleve()
        {
            InitializeComponent();
        }
        private void afficher()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; database =gestiondelabibliothequekambali; uid = root; pwd =";

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM eleves";
            cmd.Connection = conn;

            try
            {
                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lblEleve_Click(object sender, EventArgs e)
        {

        }

        private void frmEleve_Load(object sender, EventArgs e)
        {
            afficher();

        }
    }
}
