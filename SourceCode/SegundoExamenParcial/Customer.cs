using System;
using System.Windows.Forms;

namespace SegundoExamenParcial
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"INSERT INTO ADDRESS(iduser, address) VALUES(" +
                                      $"'{textBox2.Text}', " +
                                      $"'{textBox1.Text}') ";
                                    
                    ConnectionDB.ExecuteNonQuery(nonQuery);
                
                    MessageBox.Show("Address successfully created");
                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Address not available");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"INSERT INTO APPORDER(createdate, idproduct, idaddress) VALUES(" +
                                      $"'{DateTime.Now}' ," +
                                      $"'{textBox3.Text}', " +
                                      $"'{textBox4.Text}' )";
                                    
                    ConnectionDB.ExecuteNonQuery(nonQuery);
                
                    MessageBox.Show("Registered order");
                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Data not available");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {

                try
                {
                    var dt = ConnectionDB.ExecuteQuery("SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, " +
                                                       "ad.address " +
                                                       "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au " +
                                                       "WHERE ao.idProduct = pr.idProduct " +
                                                       "AND ao.idAddress = ad.idAddress " +
                                                       "AND ad.idUser = au.idUser " +
                                                       $"AND au.idUser = '{textBox9.Text}' ");

                    dataGridView1.DataSource = dt;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    var dt = ConnectionDB.ExecuteQuery($"SELECT ad.idAddress, ad.address FROM ADDRESS ad " +
                                                       $"WHERE idUser = '{textBox5.Text}' ");

                    dataGridView2.DataSource = dt;
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT * FROM BUSINESS ");

                dataGridView3.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    var dt = ConnectionDB.ExecuteQuery($"SELECT p.idProduct, p.name FROM PRODUCT p " +
                                                       $"WHERE idBusiness = '{textBox6.Text}' ");

                    dataGridView4.DataSource = dt;
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"DELETE FROM ADDRESS ad WHERE ad.idaddress = '{textBox7.Text}'";
                                
                    ConnectionDB.ExecuteNonQuery(nonQuery);
                    MessageBox.Show("Removed successfully");
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"DELETE FROM APPORDER ap WHERE ap.idorder = '{textBox8.Text}'";
                                
                    ConnectionDB.ExecuteNonQuery(nonQuery);
                    MessageBox.Show("Removed successfully");
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox10.Text.Equals("") || textBox11.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"UPDATE ADDRESS SET address = '{textBox10.Text}' " +
                                      $"WHERE iduser = '{textBox11.Text}' ";
                                
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