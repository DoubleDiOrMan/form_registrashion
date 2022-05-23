using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Лаба20_Курьяков_319_4
{
    public partial class Form2 : Form
    {
        SqlConnection mycon;
        public Form2()
        {
            InitializeComponent();
            string s = @"Data Source = DESKTOP-E8UQAJI\SQLEXPRESS; Initial catalog = Lab21_Kuryakov_319/4; Integrated Security = True";
            mycon = new SqlConnection(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ass = "insert into users values ('" + textBox1.Text + "', '" + textBox2.Text + "', 'user', HASHBYTES('SHA2_256', '" + textBox3.Text + "'))";
            string ass1 = "select count(*) from users where login = @login";
            SqlParameter p1 = new SqlParameter("@login", textBox1.Text);
            SqlCommand cm = new SqlCommand(ass1, mycon);
            SqlCommand cm1 = new SqlCommand(ass, mycon);
            cm.Parameters.Add(p1);

            mycon.Open();
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Айяйяй");
            }
            else
            {
                if (Convert.ToInt32(cm.ExecuteScalar()) == 0)
                {
                    if (Convert.ToInt32(cm1.ExecuteNonQuery()) == 1)
                    {
                        MessageBox.Show("К сожалению, вы зарегестрировались", "Успех?!");
                        Form1 f1 = new Form1();
                        f1.Show();
                        this.Hide();
                    }
                   
                        
                    
                }
                else
                {
                    MessageBox.Show("К счастью, такой логин занят)", "ОЙойой...");
                }
            }
            mycon.Close();
        }
    }
}
