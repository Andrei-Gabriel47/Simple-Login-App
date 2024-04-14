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

namespace LoginAppV2
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void AddToDo_Click(object sender, RoutedEventArgs e)
        {
            string ToDoText = ToDoInput.Text;
            if (!string.IsNullOrEmpty(ToDoText))
            {
                TextBlock toolItem = new TextBlock();
                toolItem.Text = ToDoText;
                toolItem.Margin = new Thickness(10);
                toolItem.Foreground = new SolidColorBrush(Colors.White);
                ToDoList.Children.Add(toolItem);
                ToDoInput.Clear();
            }
        }
    }
}
