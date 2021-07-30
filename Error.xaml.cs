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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Error.xaml
    /// </summary>
    public partial class Error : Window
    {
        public Error(string Title, string Message, string Message_Bold, string Message_continius)
        {
            InitializeComponent();
            Titlee.Content = Title;
            messagee.Inlines.Add(new Run(Message));
            messagee.Inlines.Add(new Run(Message_Bold) { FontWeight = FontWeights.Bold });
            messagee.Inlines.Add(new Run(Message_continius));
            //messagee.Inlines.Add(new Underline(new Run(Message_underline)));
        }
        private void KrestButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            messagee.Text = "";
            this.Close();
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            messagee.Text = "";
            this.Close();
        }
    }
}
