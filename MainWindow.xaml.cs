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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Management;
using System.Diagnostics.PerformanceData;


namespace LoginAppV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            string connection = ConfigurationManager.ConnectionStrings["LoginAppV2.Properties.Settings.AndreiDB1ConnectionString"].ConnectionString;
            conn = new SqlConnection(connection);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "select Password from Userr where Name=@Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                using (adapter)
                {
                    cmd.Parameters.AddWithValue("@Name", usernameBox.Text);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    string passwordfromData= dataTable.Rows[0]["Password"].ToString();
                    if (passwordfromData == passwordfromuserBox.Password)
                    {
                        MessageBox.Show("Login succes!"); 
                        HomeWindow homeWindow = new HomeWindow();
                        homeWindow.Show();
                        loginViewPage.Close();
                    }
                    else MessageBox.Show("Wrong password!");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            
            RegisterWindow registerViewPage = new RegisterWindow();
            registerViewPage.Show();
            loginViewPage.Close();
        }


    }
}
