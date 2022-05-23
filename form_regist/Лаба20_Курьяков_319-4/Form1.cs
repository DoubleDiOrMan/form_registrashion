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
    public partial class Form1 : Form
    {
        SqlConnection mycon;
        public Form1()
        {
            InitializeComponent();
            string s = @"Data Source = DESKTOP-E8UQAJI\SQLEXPRESS; Initial catalog = Lab21_Kuryakov_319/4; Integrated Security = True";
            mycon = new SqlConnection(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kia = "select count(*) from users where login = @login and hashpass = HASHBYTES('SHA2_256', '" + textBox2.Text +"')";
            string kia1 = "select name from users where login = @login";
            string kia2 = "select count(*) from users where login = @login and role = 'admin'";
            SqlParameter p1 = new SqlParameter("@login", textBox1.Text);
            SqlParameter p2 = new SqlParameter("@login", textBox1.Text);
            SqlParameter p3 = new SqlParameter("@login", textBox1.Text);
            SqlCommand cm1 = new SqlCommand(kia, mycon);
            SqlCommand cm2 = new SqlCommand(kia1, mycon);
            SqlCommand cm3 = new SqlCommand(kia2, mycon);
            cm1.Parameters.Add(p1);
            cm2.Parameters.Add(p2);
            cm3.Parameters.Add(p3);


            mycon.Open();
            if (Convert.ToInt32(cm1.ExecuteScalar()) == 1)
            {
                if (Convert.ToInt32(cm3.ExecuteScalar()) == 1) { 
                    MessageBox.Show("Привет, админ " + Convert.ToString(cm2.ExecuteScalar()) + "!", "Добро пожаловать!");
                    Form3 f3 = new Form3();
                    f3.Show();
                    this.Hide();
                }
                else { 
                    MessageBox.Show("Привет, обычный смертный " + Convert.ToString(cm2.ExecuteScalar()) + "!", "Добро пожаловать!");
                    Form4 f4 = new Form4();
                    f4.Show();
                    this.Hide();
                }

            }
            else
            {
                if ((textBox1.Text == "") || (textBox2.Text == "")) {
                    MessageBox.Show("Что же ты тут делаешь тогда?", "Я рад, что ты даже не пытаешься");
                }
                else {
                    MessageBox.Show("Логин/Пароль НеВерный!!!", "Как так-то, ну...");
                }
                
            }
            mycon.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
