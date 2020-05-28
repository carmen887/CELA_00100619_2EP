using System;
using System.Windows.Forms;

namespace SegundoExamenParcial
{
    public partial class Administrator : Form
    {
        public Administrator()
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
                 string nonQuery = $"INSERT INTO APPUSER(fullname, username, password, usertype) VALUES(" +
                                                      $"'{textBox1.Text}',"+
                                                      $"'{textBox2.Text}',"+
                                                      $"'{textBox2.Text}',"+
                                                      $"'true')";
                                    
                 ConnectionDB.ExecuteNonQuery(nonQuery);
                
                 MessageBox.Show("Admin successfully created");
                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception)
                {
                   MessageBox.Show("User not available");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") )
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"INSERT INTO APPUSER(fullname, username, password, usertype) VALUES(" +
                                      $"'{textBox1.Text}',"+
                                      $"'{textBox2.Text}',"+
                                      $"'{textBox2.Text}',"+
                                      $"'false')";
                                    
                    ConnectionDB.ExecuteNonQuery(nonQuery);
                
                    MessageBox.Show("Customer successfully created");
                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("User not available");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals("") || textBox5.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"INSERT INTO BUSINESS(name, description) VALUES(" +
                                      $"'{textBox4.Text}',"+
                                      $"'{textBox5.Text}')";
                                     
                                    
                    ConnectionDB.ExecuteNonQuery(nonQuery);
                
                    MessageBox.Show("Business successfully created");
                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Business not available");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals("") || textBox8.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"INSERT INTO PRODUCT(idBusiness, name) VALUES(" +
                                      $"'{textBox6.Text}',"+
                                      $"'{textBox8.Text}')";
                                     
                                    
                    ConnectionDB.ExecuteNonQuery(nonQuery);
                
                    MessageBox.Show("Product successfully created");
                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Product not available");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dt = ConnectionDB.ExecuteQuery("SELECT ao.idorder, ao.createDate, pr.name, au.fullname, " +
                                               "ad.address " +
                                               "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au " +
                                               "WHERE ao.idProduct = pr.idProduct " +
                                               "AND ao.idAddress = ad.idAddress " +
                                               "AND ad.idUser = au.idUser ");

            dataGridView1.DataSource = dt;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT * FROM APPUSER ");

                dataGridView2.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            
        }


        private void button7_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    var dt = ConnectionDB.ExecuteQuery($"SELECT p.idProduct, p.name FROM PRODUCT p " +
                                                       $"WHERE idBusiness = '{textBox7.Text}' ");

                    dataGridView4.DataSource = dt;
                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {

                    var dt = ConnectionDB.ExecuteQuery("SELECT ad.idAddress, ad.address " +
                                                       "FROM ADDRESS ad " +
                                                       $"WHERE idUser = '{textBox9.Text}' ");

                    dataGridView5.DataSource = dt;
                }
                catch (EmptySpacesException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox10.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"DELETE FROM APPUSER us WHERE us.iduser = '{textBox10.Text}'";
                    
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

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox11.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"DELETE FROM BUSINESS bs WHERE bs.idbusiness = '{textBox11.Text}'";
                    
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

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox12.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                  string nonQuery = $"DELETE FROM ADDRESS ad WHERE ad.idaddress = '{textBox12.Text}'";
                                
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

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Equals(""))
            {
                throw new EmptySpacesException("You cannot leave empty fields");
            }
            else
            {
                try
                {
                    string nonQuery = $"DELETE FROM PRODUCT p WHERE p.idproduct = '{textBox13.Text}'";
                                
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

    }
}