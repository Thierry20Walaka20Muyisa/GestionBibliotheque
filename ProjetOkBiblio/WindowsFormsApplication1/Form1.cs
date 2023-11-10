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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void afficher()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; database = gestiondelabibliothequekambali; uid = root; pwd =";

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Ouvrage";
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
        private void modifier()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=gestiondelabibliothequekambali;uid=root;pwd=''";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE Ouvrage SET Titre = @Titre, Edition = @Edition, NombreLivre = @NombreLivre, idCategorie=@idCategorie) WHERE id = @id";
            cmd.Parameters.Add("idOuvrage", MySqlDbType.Int16).Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmd.Parameters.Add("Titre", MySqlDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("Edition", MySqlDbType.Int16).Value = textBox3.Text;
            cmd.Parameters.Add("NombreLivre", MySqlDbType.Int16).Value = textBox4.Text;
            cmd.Parameters.Add("idCategorie", MySqlDbType.Double).Value = textBox5.Text;
            cmd.Connection = cn;
            try
            {
cn.Open();
if (cmd.ExecuteNonQuery() == 1)
                {
MessageBox.Show("modification effectuer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
afficher();
                }
else
                {
MessageBox.Show("echec de modification", "echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


          
            
        

        private void enregistrer ()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=gestiondelabibliothequekambali;uid=root;pwd=''";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO Ouvrage(idOuvrage,Titre,Edition,NombreLivre,idCategorie,NumCartedelecteur) VALUES(@idOuvrage,@Titre,@Edition,@NombreLivre,@idCategorie,@NumCartedelecteur)";
            cmd.Parameters.Add("idOuvrage", MySqlDbType.Int16).Value = textBox1.Text;
            cmd.Parameters.Add("Titre", MySqlDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("Edition", MySqlDbType.Int16).Value = textBox3.Text;
            cmd.Parameters.Add("NombreLivre", MySqlDbType.Int16).Value = textBox4.Text;
            cmd.Parameters.Add("idCategorie", MySqlDbType.Int16).Value = textBox5.Text;
            cmd.Parameters.Add("NumCartedelecteur", MySqlDbType.Int16).Value = textBox6.Text;
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


        private void Form1_Load(object sender, EventArgs e)
        {
            afficher();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enregistrer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            modifier();
        }
    }
}
