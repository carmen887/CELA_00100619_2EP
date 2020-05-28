using System;
using System.Windows.Forms;

namespace SegundoExamenParcial
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") ||textBox2.Text.Equals("") )
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"UPDATE APPUSER SET password = '{textBox2.Text}' " +
                                      $"WHERE iduser = '{textBox1.Text}' ";

                    ConnectionDB.ExecuteNonQuery(nonQuery);
                    MessageBox.Show("Changes saved");
                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}