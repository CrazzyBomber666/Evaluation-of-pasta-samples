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
    /// Логика взаимодействия для Razrabotchik.xaml
    /// </summary>
    public partial class Razrabotchik : Window
    {
        public Razrabotchik()
        {
            InitializeComponent();
            Family.Inlines.Add(new Run("Фамилия: ") { FontWeight = FontWeights.Bold });
            Family.Inlines.Add(new Run("Кузнецов"));
            Name.Inlines.Add(new Run("Имя: ") { FontWeight = FontWeights.Bold });
            Name.Inlines.Add(new Run("Сергей"));
            LastFamily.Inlines.Add(new Run("Отчество: ") { FontWeight = FontWeights.Bold });
            LastFamily.Inlines.Add(new Run("Владимирович"));
            Phone.Inlines.Add(new Run("Телефон: ") { FontWeight = FontWeights.Bold });
            Phone.Inlines.Add(new Run("+7 (977) 994 35 27"));
            Email.Inlines.Add(new Run("Почта: ") { FontWeight = FontWeights.Bold });
            Email.Inlines.Add(new Run("kuznezov199989@mail.ru"));
            Note.Inlines.Add(new Run("О себе: ") { FontWeight = FontWeights.Bold });
            Note.Inlines.Add(new Run("Выпускник бакалавриата Московского Государственного Университета Пищевых Производств 2021 года"));
        }

        private void KrestButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
