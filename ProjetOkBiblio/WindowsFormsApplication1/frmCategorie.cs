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
    public partial class frmCategorie : Form
    {
        public frmCategorie()
        {
            InitializeComponent();
        }
        private void afficher()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; database = gestiondelabibliothequekambali; uid = root; pwd =";

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Categorie";
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
        private void enregistrer()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=gestiondelabibliothequekambali;uid=root;pwd=''";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO Categorie(idCategorie,NomCategorie,idRayon) VALUES(@idCategorie,@NomCategorie,@idRayon)";
            cmd.Parameters.Add("idCategorie", MySqlDbType.Int16).Value = textBox1.Text;
            cmd.Parameters.Add("NomCategorie", MySqlDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("idRayon", MySqlDbType.VarChar).Value = textBox3.Text;
            cmd.Connection = cn;
            try
            {
                cn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Enregistrement effectuée avec succes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afficher();
                    //vider champs();
                }
                else
                {
                    MessageBox.Show("Echec D'enregistrement", "echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cn.Close();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            enregistrer();
        }

        private void frmCategorie_Load(object sender, EventArgs e)
        {
            afficher();
        }
    }
}
