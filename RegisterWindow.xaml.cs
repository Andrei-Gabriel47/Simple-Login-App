using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Management;
using System.Diagnostics.PerformanceData;

namespace LoginAppV2
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow :Window
    {

        SqlConnection conn;
        public RegisterWindow()
        {
            InitializeComponent();
            string connection = ConfigurationManager.ConnectionStrings["LoginAppV2.Properties.Settings.AndreiDB1ConnectionString"].ConnectionString;
            conn = new SqlConnection(connection);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            registerViewPage.Close();
        }

        private void Register_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if(passwordBox.Password!= passwordConfrimBox.Password)
                {
                    MessageBox.Show("Passowrd wrong");
                }
                else
                {
                    string query = "insert into Userr values(@Username,@Password)";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    command.Parameters.AddWithValue("@Username", usernameBox.Text);
                    command.Parameters.AddWithValue("@Password", passwordBox.Password);
                    command.ExecuteScalar();
                    conn.Close();
                    MessageBox.Show("Register succes!");
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }

}
