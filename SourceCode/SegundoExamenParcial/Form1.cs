using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoExamenParcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
              throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {

                    var dt = ConnectionDB.ExecuteQuery($"SELECT use.usertype " +
                                                       "FROM APPUSER use " +
                                                       $"WHERE use.username = '{textBox2.Text}'" +
                                                       $"AND use.password = '{textBox3.Text}'");

                    if (dt.Rows[0][0].Equals(true))
                    {
                        MessageBox.Show("Welcome " + textBox2.Text);
                        Administrator wind = new Administrator();
                        wind.Show();
                    }
                    else
                    {
                        MessageBox.Show("Welcome " + textBox2.Text);
                        ActualUser.addUser(textBox2.Text);
                        Customer win = new Customer();
                        win.Show();
                    }

                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Incorrect password");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangePassword windo = new ChangePassword();
            windo.Show();
        }
    }
}