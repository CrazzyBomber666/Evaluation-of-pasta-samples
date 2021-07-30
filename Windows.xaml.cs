using System;
using System.IO;
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
using Microsoft.Win32;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Windows : System.Windows.Window
    {

        public Windows()
        {
            InitializeComponent();
            TB_Obr.Focus();
        }

        const Byte stolb = 8;

        bool temp;
        bool изменение = false;
        short k = 0;
        string message = "";
        string message_bold = "";
        string message_continius = "";
        string title = "";

        bool error_textbox = true;
        bool error_textbox_gost = true;
        float[] odin_massiv = new float[stolb];

        float[,] massive = new float[1001, stolb + 1];

        bool[] metod = new bool[7];

        string[,] vivod = new string[1001, 3];
        int vivod_chet;
        int[] index_obr = new int[1000 * 1000];
        int[] одинаковые_образцы = new int[7 * 1000];
        short temp_1 = 0;

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

        public class CollectionRows
        {
            public float CollectionRows_Obr { get; set; }
            public float CollectionRows_Vn_Vid { get; set; }
            public float CollectionRows_Vkyc { get; set; }
            public float CollectionRows_Color { get; set; }
            public float CollectionRows_Zapax { get; set; }
            public float CollectionRows_CBPBBB { get; set; }
            public float CollectionRows_CFCU { get; set; }
            public float CollectionRows_PCU { get; set; }
            public sbyte покраска { get; set; }
        }

        private void Проверка_на_тексбоксы()
        {
            temp = false;
            error_textbox = true;
            if (TB_Obr.Text.Length != 0)
            {
                if (Convert.ToSingle(TB_Obr.Text) == 0)
                {
                    title = "Ошибка № 2";
                    message = "Допущена ошибка в текстовом блоке ";
                    message_bold = "\"№ образца!\"";
                    message_continius = " Поле не может начинаться с цифры \"0\"";
                    Obraz.Focus();
                    Error error = new Error(title, message, message_bold, message_continius);
                    error.ShowDialog();
                    TB_Obr.Focus();
                    TB_Obr.SelectAll();
                }
                else
                {
                    if (TB_Vn_vid.Text.Length != 0)
                    {
                        if (TB_zapax.Text.Length != 0)
                        {
                            if (TB_Vkyc.Text.Length != 0)
                            {
                                if (TB_Color.Text.Length != 0)
                                {
                                    if (TB_CBPBBB.Text.Length != 0)
                                    {
                                        if (TB_CFCU.Text.Length != 0)
                                        {
                                            if (TB_PCU.Text.Length != 0)
                                            {
                                                error_textbox = false;
                                            }
                                            else
                                            {
                                                title = "Ошибка № 9";
                                                message = "Допущена ошибка в текстовом блоке ";
                                                message_bold = "\"Прочность сваренных изделий!\"";
                                                message_continius = " Поле не может быть пустым";
                                                Obraz.Focus();
                                                Error error = new Error(title, message, message_bold, message_continius);
                                                error.ShowDialog();
                                                TB_PCU.Focus();
                                                TB_PCU.SelectAll();
                                            }
                                        }
                                        else
                                        {
                                            title = "Ошибка № 8";
                                            message = "Допущена ошибка в текстовом блоке ";
                                            message_bold = "\"Сохранность формы сваренных изделий!\"";
                                            message_continius = " Поле не может быть пустым";
                                            Obraz.Focus();
                                            Error error = new Error(title, message, message_bold, message_continius);
                                            error.ShowDialog();
                                            TB_CFCU.Focus();
                                            TB_CFCU.SelectAll();
                                        }
                                    }
                                    else
                                    {
                                        title = "Ошибка № 7";
                                        message = "Допущена ошибка в текстовом блоке ";
                                        message_bold = "\"Сухое вещество, перешедшее в варочную воду!\"";
                                        message_continius = " Поле не может быть пустым";
                                        Obraz.Focus();
                                        Error error = new Error(title, message, message_bold, message_continius);
                                        error.ShowDialog();
                                        TB_CBPBBB.Focus();
                                        TB_CBPBBB.SelectAll();
                                    }
                                }
                                else
                                {
                                    title = "Ошибка № 6";
                                    message = "Допущена ошибка в текстовом блоке ";
                                    message_bold = "\"Цвет!\"";
                                    message_continius = " Поле не может быть пустым";
                                    Obraz.Focus();
                                    Error error = new Error(title, message, message_bold, message_continius);
                                    error.ShowDialog();
                                    TB_Color.Focus();
                                    TB_Color.SelectAll();
                                }
                            }
                            else
                            {
                                title = "Ошибка № 5";
                                message = "Допущена ошибка в текстовом блоке ";
                                message_bold = "\"Вкус!\"";
                                message_continius = " Поле не может быть пустым";
                                Obraz.Focus();
                                Error error = new Error(title, message, message_bold, message_continius);
                                error.ShowDialog();
                                TB_Vkyc.Focus();
                                TB_Vkyc.SelectAll();
                            }
                        }
                        else
                        {
                            title = "Ошибка № 4";
                            message = "Допущена ошибка в текстовом блоке ";
                            message_bold = "\"Запах!\"";
                            message_continius = " Поле не может быть пустым";
                            Obraz.Focus();
                            Error error = new Error(title, message, message_bold, message_continius);
                            error.ShowDialog();
                            TB_zapax.Focus();
                            TB_zapax.SelectAll();
                        }
                    }
                    else
                    {
                        title = "Ошибка № 3";
                        message = "Допущена ошибка в текстовом блоке ";
                        message_bold = "\"Внешний вид!\"";
                        message_continius = " Поле не может быть пустым";
                        Obraz.Focus();
                        Error error = new Error(title, message, message_bold, message_continius);
                        error.ShowDialog();
                        TB_Vn_vid.Focus();
                        TB_Vn_vid.SelectAll();
                    }
                }
            }
            else
            {
                title = "Ошибка № 1";
                message = "Допущена ошибка в текстовом блоке ";
                message_bold = "\"№ образца!\"";
                message_continius = " Поле не может быть пустым";
                Obraz.Focus();
                Error error = new Error(title, message, message_bold, message_continius);
                error.ShowDialog();
                TB_Obr.Focus();
                TB_Obr.SelectAll();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Проверка_на_тексбоксы();
            if (error_textbox == false)
            {
                if (k == 0)
                {
                    добавление_в_таблицу();
                    очистка_текстовых_полей();
                    изменение = false;
                }
                else
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (massive[i, 0] == Convert.ToInt32(TB_Obr.Text))
                        {
                            temp = true;
                            title = "Ошибка № 14";
                            message = "Допущена ошибка в текстовом блоке ";
                            message_bold = "\"№ образца!\"";
                            message_continius = " Такой образец с \"№ " + massive[i, 0] + "\" уже существует в таблице";
                            Error error = new Error(title, message, message_bold, message_continius);
                            error.ShowDialog();
                            TB_Obr.Focus();
                            TB_Obr.SelectAll();
                            break;
                        }
                    }
                    if (temp == false)
                    {
                        добавление_в_таблицу();
                        очистка_текстовых_полей();
                        изменение = false;
                    }
                }
            }
        }

        private void добавление_в_таблицу()
        {
            massive[k, 0] = Convert.ToSingle(TB_Obr.Text);
            massive[k, 1] = Convert.ToSingle(TB_Vn_vid.Text);
            massive[k, 2] = Convert.ToSingle(TB_Vkyc.Text);
            massive[k, 3] = Convert.ToSingle(TB_Color.Text);
            massive[k, 4] = Convert.ToSingle(TB_zapax.Text);
            massive[k, 5] = Convert.ToSingle(TB_CBPBBB.Text);
            massive[k, 6] = Convert.ToSingle(TB_CFCU.Text);
            massive[k, 7] = Convert.ToSingle(TB_PCU.Text);
            CollectionRows information = new CollectionRows();
            for (short i = 0; i <= stolb; i++)
            {
                information.CollectionRows_Obr = Convert.ToSingle(TB_Obr.Text);
                information.CollectionRows_Vn_Vid = Convert.ToSingle(TB_Vn_vid.Text);
                information.CollectionRows_Vkyc = Convert.ToSingle(TB_Vkyc.Text);
                information.CollectionRows_Color = Convert.ToSingle(TB_Color.Text);
                information.CollectionRows_Zapax = Convert.ToSingle(TB_zapax.Text);
                information.CollectionRows_CBPBBB = Convert.ToSingle(TB_CBPBBB.Text);
                information.CollectionRows_CFCU = Convert.ToSingle(TB_CFCU.Text);
                information.CollectionRows_PCU = Convert.ToSingle(TB_PCU.Text);
            }
            WPFDataGrid.Items.Add(information);
            TB_Obr.Focus();
            k++;
            добавление_в_таблицу_1();
        }

        private void очистка_текстовых_полей()
        {
            TB_Obr.Text = "";
            TB_Vn_vid.Text = "";
            TB_Vkyc.Text = "";
            TB_Color.Text = "";
            TB_zapax.Text = "";
            TB_CBPBBB.Text = "";
            TB_CFCU.Text = "";
            TB_PCU.Text = "";
        }

        private void проверка_на_значения(object sender, KeyEventArgs e)
        {
            System.Windows.Controls.TextBox temp_text = sender as System.Windows.Controls.TextBox;
            if (!string.IsNullOrEmpty(temp_text.Text))
            {
                if (temp_text.Text == "10")
                {
                    temp_text.MaxLength = 3;
                    if (e.Key == Key.D0)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.Key == Key.Back || e.Key == Key.Tab || e.Key == Key.OemComma)
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    temp_text.MaxLength = 2;
                }
            }
        }

        private void TB_KeyPress_Nomer(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TB_KeyPressDown_Nomer(object sender, KeyEventArgs e)
        {
            System.Windows.Controls.TextBox temp_text = sender as System.Windows.Controls.TextBox;
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            if (!string.IsNullOrEmpty(temp_text.Text))
            {
                if (temp_text.Text == "100")
                {
                    temp_text.MaxLength = 4;
                    if (e.Key == Key.D0)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.Key == Key.Back || e.Key == Key.Tab)
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    temp_text.MaxLength = 3;
                }
            }
        }

        private void TB_KeyPress_Another(object sender, TextCompositionEventArgs e)
        {
            System.Windows.Controls.TextBox temp_text = sender as System.Windows.Controls.TextBox;
            if (!Char.IsDigit(e.Text, 0) && e.Text != ",")
            {
                e.Handled = true;
            }
            else
            {
                if ((e.Text == ",") && (temp_text.Text.IndexOf(",") != -1 || (temp_text.Text == "")))
                {
                    e.Handled = true;
                }
            }
        }

        private void TB_KeyPressDown(object sender, KeyEventArgs e)
        {
            System.Windows.Controls.TextBox temp_text = sender as System.Windows.Controls.TextBox;
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            проверка_на_значения(sender, e);
            string s;
            if (!string.IsNullOrEmpty(temp_text.Text))
            {
                s = temp_text.Text.Substring(temp_text.Text.Length - 1, 1);
                if (s == ",")
                {
                    if (temp_text.Text.Length == 2 && s == ",")
                    {
                        temp_text.MaxLength = 3;
                    }
                    else
                    {
                        temp_text.MaxLength = 2;
                        if (temp_text.Text.Length == 3 && s == ",")
                        {
                            temp_text.MaxLength = 4;
                        }
                        else
                        {
                            temp_text.MaxLength = 3;
                        }
                    }
                }
                else
                {
                    temp_text.MaxLength = 2;
                    проверка_на_значения(sender, e);
                }
            }
            Key k1 = e.Key;
            if (k1 == Key.OemPeriod || k1 == Key.Decimal || k1 == Key.OemQuestion)
            {
                k1 = Key.OemComma;
            }
            if (k1 == Key.OemComma)
            {

                if (temp_text.Text.IndexOf(",") != -1 || (temp_text.Text == ""))
                {
                    e.Handled = true;
                }
                else
                {
                    temp_text.Text += ",";
                    temp_text.MaxLength = 3;
                    temp_text.CaretIndex = temp_text.Text.Length;
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (k != 0 || изменение == true)
            {
                if (изменение == true)
                {
                    title = "Ошибка № 19";
                    message = "Вы не внесли изменения в выбранной строке. Пожалуйста, нажмите кнопку ";
                    message_bold = "\"Изменить строку\"";
                    message_continius = " чтобы внести и сохранить изменения";
                    Error error = new Error(title, message, message_bold, message_continius);
                    error.ShowDialog();
                }
                else { }
            }
            else
            {
                title = "Ошибка № 16";
                message = "Допущена ошибка в таблице! Таблица должна быть заполнена хотя бы одним образцом";
                Error error = new Error(title, message, message_bold, message_continius);
                error.ShowDialog();
                TB_Obr.Focus();
                TB_Obr.SelectAll();
            }
        }

        private void ошибка_15()
        {
            title = "Ошибка № 15";
            message = "Допущена ошибка в таблице! Таблица должна быть заполнена хотя бы одним образцом";
            Error error = new Error(title, message, message_bold, message_continius);
            error.ShowDialog();
            TB_Obr.Focus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (k != 0)
            {
                if (WPFDataGrid.SelectedIndex != -1)
                {
                    k--;
                    for (short i = Convert.ToInt16(WPFDataGrid.SelectedIndex); i <= k; i++)
                    {
                        for (short j = 0; j < stolb; j++)
                        {
                            massive[i, j] = massive[i + 1, j];
                        }
                    }
                    WPFDataGrid.Items.Remove(WPFDataGrid.SelectedItem);
                    добавление_в_таблицу_1();
                    TB_Obr.Focus();
                    TB_Obr.SelectAll();
                }
                else
                {
                    title = "Ошибка № 17";
                    message = "Допущена ошибка в таблице! Чтобы удалить строку необходимо выделить ее";
                    Error error = new Error(title, message, message_bold, message_continius);
                    error.ShowDialog();
                    TB_Obr.Focus();
                    TB_Obr.SelectAll();
                }
            }
            else
            {
                ошибка_15();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (k != 0 || изменение == true)
            {
                if (изменение == false)
                {
                    if (WPFDataGrid.SelectedIndex != -1)
                    {
                        k--;
                        TB_Obr.Text = Convert.ToString(massive[WPFDataGrid.SelectedIndex, 0]);
                        TB_Vn_vid.Text = Convert.ToString(massive[WPFDataGrid.SelectedIndex, 1]);
                        TB_Vkyc.Text = Convert.ToString(massive[WPFDataGrid.SelectedIndex, 2]);
                        TB_Color.Text = Convert.ToString(massive[WPFDataGrid.SelectedIndex, 3]);
                        TB_zapax.Text = Convert.ToString(massive[WPFDataGrid.SelectedIndex, 4]);
                        TB_CBPBBB.Text = Convert.ToString(massive[WPFDataGrid.SelectedIndex, 5]);
                        TB_CFCU.Text = Convert.ToString(massive[WPFDataGrid.SelectedIndex, 6]);
                        TB_PCU.Text = Convert.ToString(massive[WPFDataGrid.SelectedIndex, 7]);
                        for (short i = Convert.ToInt16(WPFDataGrid.SelectedIndex); i <= k; i++)
                        {
                            for (short j = 0; j < stolb; j++)
                            {
                                massive[i, j] = massive[i + 1, j];
                            }
                        }
                        WPFDataGrid.Items.Remove(WPFDataGrid.SelectedItem);
                        TB_Obr.Focus();
                        TB_Obr.SelectAll();
                        изменение = true;
                    }
                    else
                    {
                        title = "Ошибка № 18";
                        message = "Допущена ошибка в таблице! Чтобы изменить строку необходимо выделить ее";
                        Error error = new Error(title, message, message_bold, message_continius);
                        error.ShowDialog();
                        TB_Obr.Focus();
                        TB_Obr.SelectAll();
                    }
                }
                else
                {
                    Button_Click(sender, e);
                    if (temp == false)
                    {
                        изменение = false;
                    }
                }
            }
            else
            {
                ошибка_15();
            }
        }

        private void добавление_в_таблицу_1()
        {
            WPFDataGrid1.Items.Clear();
            k--;
            for (short i = 0; i <= k; i++)
            {
                CollectionRows information = new CollectionRows();
                information.CollectionRows_Obr = massive[i, 0];
                information.CollectionRows_Vn_Vid = massive[i, 1];
                information.CollectionRows_Vkyc = massive[i, 2];
                information.CollectionRows_Color = massive[i, 3];
                information.CollectionRows_Zapax = massive[i, 4];
                information.CollectionRows_CBPBBB = massive[i, 5];
                information.CollectionRows_CFCU = massive[i, 6];
                information.CollectionRows_PCU = massive[i, 7];
                WPFDataGrid1.Items.Add(information);
            }
            k++;
        }

        private void перенести_текстбоксы_в_массив()
        {
            odin_massiv[0] = Convert.ToSingle(TB_Vn_vid1.Text);
            odin_massiv[1] = Convert.ToSingle(TB_Vkyc1.Text);
            odin_massiv[2] = Convert.ToSingle(TB_Color1.Text);
            odin_massiv[3] = Convert.ToSingle(TB_zapax1.Text);
            odin_massiv[4] = Convert.ToSingle(TB_CBPBBB1.Text);
            odin_massiv[5] = Convert.ToSingle(TB_CFCU1.Text);
            odin_massiv[6] = Convert.ToSingle(TB_PCU1.Text);
        }
        private void проверка_пустых_боксов()
        {
            error_textbox_gost = true;
            if (TB_Vn_vid1.Text.Length != 0)
            {
                if (TB_zapax1.Text.Length != 0)
                {
                    if (TB_Vkyc1.Text.Length != 0)
                    {
                        if (TB_Color1.Text.Length != 0)
                        {
                            if (TB_CBPBBB1.Text.Length != 0)
                            {
                                if (TB_CFCU1.Text.Length != 0)
                                {
                                    if (TB_PCU1.Text.Length != 0)
                                    {
                                        перенести_текстбоксы_в_массив();
                                        error_textbox_gost = false;
                                    }
                                    else
                                    {
                                        title = "Ошибка № 26";
                                        message = "Допущена ошибка в текстовом блоке ";
                                        message_bold = "\"Прочность сваренных изделий!\"";
                                        message_continius = " Поле не может быть пустым";
                                        GOST.Focus();
                                        Error error = new Error(title, message, message_bold, message_continius);
                                        error.ShowDialog();
                                        TB_PCU1.Focus();
                                        TB_PCU1.SelectAll();
                                    }
                                }
                                else
                                {
                                    title = "Ошибка № 25";
                                    message = "Допущена ошибка в текстовом блоке ";
                                    message_bold = "\"Сохранность формы сваренных изделий!\"";
                                    message_continius = " Поле не может быть пустым";
                                    GOST.Focus();
                                    Error error = new Error(title, message, message_bold, message_continius);
                                    error.ShowDialog();
                                    TB_CFCU1.Focus();
                                    TB_CFCU1.SelectAll();
                                }
                            }
                            else
                            {
                                title = "Ошибка № 24";
                                message = "Допущена ошибка в текстовом блоке ";
                                message_bold = "\"Сухое вещество, перешедшее в варочную воду!\"";
                                message_continius = " Поле не может быть пустым";
                                GOST.Focus();
                                Error error = new Error(title, message, message_bold, message_continius);
                                error.ShowDialog();
                                TB_CBPBBB1.Focus();
                                TB_CBPBBB1.SelectAll();
                            }
                        }
                        else
                        {
                            title = "Ошибка № 23";
                            message = "Допущена ошибка в текстовом блоке ";
                            message_bold = "\"Цвет!\"";
                            message_continius = " Поле не может быть пустым";
                            GOST.Focus();
                            Error error = new Error(title, message, message_bold, message_continius);
                            error.ShowDialog();
                            TB_Color1.Focus();
                            TB_Color1.SelectAll();
                        }
                    }
                    else
                    {
                        title = "Ошибка № 22";
                        message = "Допущена ошибка в текстовом блоке ";
                        message_bold = "\"Вкус!\"";
                        message_continius = " Поле не может быть пустым";
                        GOST.Focus();
                        Error error = new Error(title, message, message_bold, message_continius);
                        error.ShowDialog();
                        TB_Vkyc1.Focus();
                        TB_Vkyc1.SelectAll();
                    }
                }
                else
                {
                    title = "Ошибка № 21";
                    message = "Допущена ошибка в текстовом блоке ";
                    message_bold = "\"Запах!\"";
                    message_continius = " Поле не может быть пустым";
                    GOST.Focus();
                    Error error = new Error(title, message, message_bold, message_continius);
                    error.ShowDialog();
                    TB_zapax1.Focus();
                    TB_zapax1.SelectAll();
                }
            }
            else
            {
                title = "Ошибка № 20";
                message = "Допущена ошибка в текстовом блоке ";
                message_bold = "\"Внешний вид!\"";
                message_continius = " Поле не может быть пустым";
                GOST.Focus();
                Error error = new Error(title, message, message_bold, message_continius);
                error.ShowDialog();
                TB_Vn_vid1.Focus();
                TB_Vn_vid1.SelectAll();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            KMCNMP.IsChecked = true;
            KMC.IsChecked = true;
            MMC.IsChecked = true;
            KKK.IsChecked = true;
            KKYMB.IsChecked = true;
            MKK.IsChecked = true;
            KK.IsChecked = true;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            KMCNMP.IsChecked = false;
            KMC.IsChecked = false;
            MMC.IsChecked = false;
            KKK.IsChecked = false;
            KKYMB.IsChecked = false;
            MKK.IsChecked = false;
            KK.IsChecked = false;
        }

        private class CollectionRowsResult
        {
            public string CollectionRowsResult_Name_metrika { get; set; }
            public float CollectionRowsResult_Nomer_obr { get; set; }
            public float CollectionRowsResult_Result { get; set; }
        }

        private class CollectionRowsGOST
        {
            public float CollectionRows_Vn_Vid { get; set; }
            public float CollectionRows_Vkyc { get; set; }
            public float CollectionRows_Color { get; set; }
            public float CollectionRows_Zapax { get; set; }
            public float CollectionRows_CBPBBB { get; set; }
            public float CollectionRows_CFCU { get; set; }
            public float CollectionRows_PCU { get; set; }
        }

        private void обнуление()
        {
            for (int i = 0; i < 7 * k; i++)
            {
                index_obr[i] = -1;
                одинаковые_образцы[i] = 0;
            }
            temp_1 = 0;
            vivod_chet = 0;
        }

        private int присваивание()
        {
            int temp;
            if (Convert.ToInt16(temp_1) != 0)
            {
                temp = Convert.ToInt16(temp_1 - 1);
            }
            else
            {
                temp = -1;
            }
            return temp;
        }

        private void результат_при_else(double Min_Max, string name)
        {
            for (int i = 0; i < temp_1; i++)
            {
                CollectionRowsResult information = new CollectionRowsResult();
                information.CollectionRowsResult_Name_metrika = name;
                information.CollectionRowsResult_Nomer_obr = massive[index_obr[i] - 1, 0];
                information.CollectionRowsResult_Result = Convert.ToSingle(Math.Round(Min_Max, 2));
                WPFDataGrid_result.Items.Add(information);
                vivod[vivod_chet, 0] = name;
                vivod[vivod_chet, 1] = Convert.ToString(massive[index_obr[i] - 1, 0]);
                vivod[vivod_chet, 2] = Convert.ToString(Convert.ToSingle(Math.Round(Min_Max, 2)));
                vivod_chet++;
            }
        }

        private void результат_при_true(double Min_Max, int tempp, string name)
        {
            for (int i = tempp + 1; i < temp_1; i++)
            {
                CollectionRowsResult information = new CollectionRowsResult();
                information.CollectionRowsResult_Name_metrika = name;
                information.CollectionRowsResult_Nomer_obr = massive[index_obr[i] - 1, 0];
                information.CollectionRowsResult_Result = Convert.ToSingle(Math.Round(Min_Max, 2));
                WPFDataGrid_result.Items.Add(information);
                vivod[vivod_chet, 0] = name;
                vivod[vivod_chet, 1] = Convert.ToString(massive[index_obr[i] - 1, 0]);
                vivod[vivod_chet, 2] = Convert.ToString(Convert.ToSingle(Math.Round(Min_Max, 2)));
                vivod_chet++;
            }
        }

        private void рассчет()
        {
            for (int i = 0; i < 7; i++)
            {
                if (metod[i] == true)
                {
                    switch (i)
                    {
                        case 0:
                            рассчет_Квадратичная_мера_сходства_N_мерного_пространства();
                            break;
                        case 1:
                            рассчет_Квадратичная_мера_сходства();
                            break;
                        case 2:
                            рассчет_Модульная_мера_сходства();
                            break;
                        case 3:
                            рассчет_Классический_коэффициент_корреляции();
                            break;
                        case 4:
                            рассчет_Квадрат_косинуса_угла_между_векторами();
                            break;
                        case 5:
                            рассчет_Модифицированный_коэффициент_корреляциии();
                            break;
                        case 6:
                            рассчет_Коэффициент_корреляции();
                            break;
                    }
                }
            }
            проверка();
        }

        private async void проверка()
        {
            int temp_1;
            int count;
            int max_temp = int.MinValue;
            int k_ = 0;
            for (int i = 0; i < 7 * k; i++)
            {
                if (index_obr[i] != -1 && index_obr[i] != 0)
                {
                    temp_1 = index_obr[i];
                    count = 0;
                    for (int j = 0; j < 7 * k; j++)
                    {
                        if (temp_1 == index_obr[j])
                        {
                            count++;
                        }
                    }
                    if (count > max_temp)
                    {
                        k_ = 0;
                        max_temp = count;
                        одинаковые_образцы[k_] = index_obr[i];
                    }
                    else
                    {
                        if (count == max_temp)
                        {
                            k_++;
                            одинаковые_образцы[k_] = index_obr[i];
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            await Task.Delay(100);
            title = "Результат";
            message = "Оптимальные образцы помечены зеленым цветом. Один из них образец ";
            message_bold = " № " + massive[одинаковые_образцы[0] - 1, 0] + " Помечен зеленым цветом";
            Error error = new Error(title, message, message_bold, "");
            error.ShowDialog();
            await Task.Delay(500);

            for (short z = 0; z < k; z++)
            {
                bool tempp = false;
                CollectionRows information = new CollectionRows();
                information.CollectionRows_Obr = massive[z, 0];
                information.CollectionRows_Vn_Vid = massive[z, 1];
                information.CollectionRows_Vkyc = massive[z, 2];
                information.CollectionRows_Color = massive[z, 3];
                information.CollectionRows_Zapax = massive[z, 4];
                information.CollectionRows_CBPBBB = massive[z, 5];
                information.CollectionRows_CFCU = massive[z, 6];
                information.CollectionRows_PCU = massive[z, 7];
                for (short i = 0; i <= одинаковые_образцы[i]; i++)
                {
                    if (одинаковые_образцы[i] != -1 && одинаковые_образцы[i] != 0)
                    {

                        if (massive[z, 0] == massive[одинаковые_образцы[i] - 1, 0])
                        {
                            information.покраска = 1;
                            tempp = true;
                        }
                        else
                        {
                            if (tempp == false)
                            {
                                information.покраска = 0;
                            }
                        }
                    }
                    else { }
                }
                WPFDataGrid_obraz.Items.Add(information);
            }
        }

        private void рассчет_Квадратичная_мера_сходства_N_мерного_пространства()
        {
            string name = "Квадратичная мера сходства N мерного пространства";
            double summa;
            double min = double.MaxValue;
            for (short j = 0; j < k; j++)
            {
                summa = 0;
                for (short z = 0; z < stolb; z++)
                {
                    summa += Math.Pow(massive[j, z + 1] - odin_massiv[z], 2);
                }
                summa = Math.Sqrt(summa);
                if (min > summa)
                {
                    min = summa;
                    index_obr[temp_1] = Convert.ToInt16(j + 1);
                }
                else
                {
                    if (min == summa)
                    {
                        temp_1++;
                        index_obr[temp_1] = Convert.ToInt16(j + 1);
                    }
                }
            }
            temp_1++;
            результат_при_else(min, name);
        }

        private void рассчет_Квадратичная_мера_сходства()
        {
            string name = "Квадратичная мера сходства";
            double summa;
            double temp_summa;
            double min = double.MaxValue;
            int tempp = присваивание();
            for (short j = 0; j < k; j++)
            {
                summa = 0;
                temp_summa = 0;
                for (short z = 0; z < stolb; z++)
                {
                    summa += Math.Pow(massive[j, z + 1], 2);
                    temp_summa += Math.Pow(odin_massiv[z], 2);
                }
                summa = Math.Abs(Math.Sqrt(summa) - Math.Sqrt(temp_summa));
                if (min > summa)
                {
                    min = summa;
                    index_obr[temp_1] = Convert.ToInt16(j + 1);
                }
                else
                {
                    if (min == summa)
                    {
                        temp_1++;
                        index_obr[temp_1] = Convert.ToInt16(j + 1);
                    }
                }
            }
            temp_1++;
            if (temp_1 - 1 != tempp && tempp != -1)
            {
                результат_при_true(min, tempp, name);
            }
            else
            {
                результат_при_else(min, name);
            }
        }

        private void рассчет_Модульная_мера_сходства()
        {
            string name = "Модульная мера сходства";
            double summa;
            double temp_summa;
            double min = double.MaxValue;
            int tempp = присваивание();
            for (short j = 0; j < k; j++)
            {
                summa = 0;
                temp_summa = 0;
                for (short z = 0; z < stolb; z++)
                {
                    summa += Math.Abs(massive[j, z + 1]);
                    temp_summa += Math.Abs(odin_massiv[z]);
                }
                summa = Math.Abs(Math.Sqrt(summa) - Math.Sqrt(temp_summa));
                if (min > summa)
                {
                    min = summa;
                    index_obr[temp_1] = Convert.ToInt16(j + 1);
                }
                else
                {
                    if (min == summa)
                    {
                        temp_1++;
                        index_obr[temp_1] = Convert.ToInt16(j + 1);
                    }
                }
            }
            temp_1++;
            if (temp_1 - 1 != tempp && tempp != -1)
            {
                результат_при_true(min, tempp, name);
            }
            else
            {
                результат_при_else(min, name);
            }
        }

        private void рассчет_Классический_коэффициент_корреляции()
        {
            string name = "Классический коэффициент корреляции";
            double summa;
            double temp_summa;
            double temp_summa_1;
            double max = double.MinValue;
            int tempp = присваивание();
            for (short j = 0; j < k; j++)
            {
                summa = 0;
                temp_summa = 0;
                temp_summa_1 = 0;
                for (short z = 0; z < stolb; z++)
                {
                    summa += massive[j, z + 1] * odin_massiv[z];
                    temp_summa += Math.Pow(massive[j, z + 1], 2);
                    temp_summa_1 += Math.Pow(odin_massiv[z], 2);
                }
                summa = summa / (Math.Sqrt(temp_summa) * Math.Sqrt(temp_summa_1));
                if (max < summa)
                {
                    max = summa;
                    index_obr[temp_1] = Convert.ToInt16(j + 1);
                }
                else
                {
                    if (max == summa)
                    {
                        temp_1++;
                        index_obr[temp_1] = Convert.ToInt16(j + 1);
                    }
                }
            }
            temp_1++;
            if (temp_1 - 1 != tempp && tempp != -1)
            {
                результат_при_true(max, tempp, name);
            }
            else
            {
                результат_при_else(max, name);
            }
        }

        private void рассчет_Квадрат_косинуса_угла_между_векторами()
        {
            string name = "Квадрат косинуса угла между векторами";
            double summa;
            double temp_summa;
            double temp_summa_1;
            double max = double.MinValue;
            int tempp = присваивание();
            for (short j = 0; j < k; j++)
            {
                summa = 0;
                temp_summa = 0;
                temp_summa_1 = 0;
                for (short z = 0; z < stolb; z++)
                {
                    summa += massive[j, z + 1] * odin_massiv[z];
                    temp_summa += Math.Pow(massive[j, z + 1], 2);
                    temp_summa_1 += Math.Pow(odin_massiv[z], 2);
                }
                summa = Math.Pow(summa, 2) / (temp_summa * temp_summa_1);
                if (max < summa)
                {
                    max = summa;
                    index_obr[temp_1] = Convert.ToInt16(j + 1);
                }
                else
                {
                    if (max == summa)
                    {
                        temp_1++;
                        index_obr[temp_1] = Convert.ToInt16(j + 1);
                    }
                }
            }
            temp_1++;
            if (temp_1 - 1 != tempp && tempp != -1)
            {
                результат_при_true(max, tempp, name);
            }
            else
            {
                результат_при_else(max, name);
            }
        }

        private void рассчет_Модифицированный_коэффициент_корреляциии()
        {
            string name = "Модифицированный коэффициент корреляции";
            double summa;
            double temp_summa;
            double temp_summa_1;
            double max = double.MinValue;
            int tempp = присваивание();
            for (short j = 0; j < k; j++)
            {
                summa = 0;
                temp_summa = 0;
                temp_summa_1 = 0;
                for (short z = 0; z < stolb; z++)
                {
                    summa += massive[j, z + 1] * odin_massiv[z];
                    temp_summa += Math.Pow(massive[j, z + 1], 2);
                    temp_summa_1 += Math.Pow(odin_massiv[z], 2);
                }
                summa = 2 * summa / (temp_summa + temp_summa_1);
                if (max < summa)
                {
                    max = summa;
                    index_obr[temp_1] = Convert.ToInt16(j + 1);
                }
                else
                {
                    if (max == summa)
                    {
                        temp_1++;
                        index_obr[temp_1] = Convert.ToInt16(j + 1);
                    }
                }
            }
            temp_1++;
            if (temp_1 - 1 != tempp && tempp != -1)
            {
                результат_при_true(max, tempp, name);
            }
            else
            {
                результат_при_else(max, name);
            }
        }

        private void рассчет_Коэффициент_корреляции()
        {
            string name = "Коэффициент корреляции";
            double summa;
            double temp_summa;
            double max = double.MinValue;
            int tempp = присваивание();
            for (short j = 0; j < k; j++)
            {
                summa = 0;
                temp_summa = 0;
                for (short z = 0; z < stolb; z++)
                {
                    summa += massive[j, z + 1] * odin_massiv[z];
                    temp_summa += Math.Pow(massive[j, z + 1] - odin_massiv[z], 2);
                }
                summa = summa / temp_summa;
                if (max < summa)
                {
                    max = summa;
                    index_obr[temp_1] = Convert.ToInt16(j + 1);
                }
                else
                {
                    if (max == summa)
                    {
                        temp_1++;
                        index_obr[temp_1] = Convert.ToInt16(j + 1);
                    }
                }
            }
            temp_1++;
            if (temp_1 - 1 != tempp && tempp != -1)
            {
                результат_при_true(max, tempp, name);
            }
            else
            {
                результат_при_else(max, name);
            }
        }

        private void Рассчитать(object sender, RoutedEventArgs e)
        {
            short i = 0;
            if (KMCNMP.IsChecked == true)
            {
                metod[i] = true;
                i++;
            }
            else
            {
                metod[i] = false;
                i++;
            }
            if (KMC.IsChecked == true)
            {
                metod[i] = true;
                i++;
            }
            else
            {
                metod[i] = false;
                i++;
            }
            if (MMC.IsChecked == true)
            {
                metod[i] = true;
                i++;
            }
            else
            {
                metod[i] = false;
                i++;
            }
            if (KKK.IsChecked == true)
            {
                metod[i] = true;
                i++;
            }
            else
            {
                metod[i] = false;
                i++;
            }
            if (KKYMB.IsChecked == true)
            {
                metod[i] = true;
                i++;
            }
            else
            {
                metod[i] = false;
                i++;
            }
            if (MKK.IsChecked == true)
            {
                metod[i] = true;
                i++;
            }
            else
            {
                metod[i] = false;
                i++;
            }
            if (KK.IsChecked == true)
            {
                metod[i] = true;
                i++;
            }
            else
            {
                metod[i] = false;
                i++;
            }
            int temp = 0;
            for (i = 0; i < 7; i++)
            {
                if (metod[i] == false)
                {
                    temp++;
                }
            }
            if (temp == 7)
            {
                title = "Ошибка № 31";
                message = "Допущена ошибка на странице! Выберите хотя бы ";
                message_bold = "Одну ";
                message_continius = "меру расчета, по которой будут производиться вычисления";
                Metriki.Focus();
                Error error = new Error(title, message, message_bold, message_continius);
                error.ShowDialog();
            }
            else
            {
                проверка_пустых_боксов();
                if (error_textbox_gost == false)
                {
                    if (massive[0, 0] == 0)
                    {
                        Проверка_на_тексбоксы();
                        if (massive[0, 0] == 0 && error_textbox == false)
                        {
                            title = "Ошибка № 32";
                            message = "Допущена ошибка на странице! Таблица пустая. Поля заполнены,";
                            message_bold = " Но не добавлены ";
                            message_continius = "в таблицу";
                            Obraz.Focus();
                            Error error = new Error(title, message, message_bold, message_continius);
                            error.ShowDialog();
                        }
                    }
                    else
                    {
                        WPFDataGrid_obraz.Items.Clear();
                        WPFDataGrid_result.Items.Clear();
                        WPFDataGrid_pokazat.Items.Clear();
                        CollectionRowsGOST data = new CollectionRowsGOST();
                        data.CollectionRows_Vn_Vid = odin_massiv[0];
                        data.CollectionRows_Vkyc = odin_massiv[1];
                        data.CollectionRows_Color = odin_massiv[2];
                        data.CollectionRows_Zapax = odin_massiv[3];
                        data.CollectionRows_CBPBBB = odin_massiv[4];
                        data.CollectionRows_CFCU = odin_massiv[5];
                        data.CollectionRows_PCU = odin_massiv[6];
                        WPFDataGrid_pokazat.Items.Add(data);
                        обнуление();
                        рассчет();
                    }
                }
                else { }
            }
        }

        private void Сохранить_в_ексель(object sender, RoutedEventArgs e)
        {
            int row = 0;
            int column = 0;
            Excel.Application excel = new Excel.Application();
            Workbook workbook = excel.Workbooks.Add(Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < WPFDataGrid_pokazat.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                myRange.Value2 = WPFDataGrid_pokazat.Columns[j].Header;
                sheet1.Cells[1, j + 1].Interior.Color = XlRgbColor.rgbLightGray;
                sheet1.Cells[1, j + 1].Borders[XlBordersIndex.xlEdgeRight].Weight = 3d;
                sheet1.Cells[1, j + 1].Borders[XlBordersIndex.xlEdgeBottom].Weight = 3d;
            }
            for (int i = 0; i < WPFDataGrid_pokazat.Columns.Count; i++)
            {
                for (int j = 0; j < WPFDataGrid_pokazat.Items.Count; j++)
                {
                    TextBlock b = WPFDataGrid_pokazat.Columns[i].GetCellContent(WPFDataGrid_pokazat.Items[j]) as TextBlock;
                    Range myRange = (Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                    myRange.Borders[XlBordersIndex.xlEdgeRight].Weight = 3d;
                    myRange.Borders[XlBordersIndex.xlEdgeBottom].Weight = 3d;
                }
                row = 4;
            }

            for (int j = 0; j < WPFDataGrid_result.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[row, j + 1];
                sheet1.Cells[row, j + 1].Font.Bold = true;
                myRange.Value2 = WPFDataGrid_result.Columns[j].Header;
                sheet1.Cells[row, j + 1].Interior.Color = XlRgbColor.rgbLightGray;
                sheet1.Cells[row, j + 1].Borders[XlBordersIndex.xlEdgeRight].Weight = 3d;
                sheet1.Cells[row, j + 1].Borders[XlBordersIndex.xlEdgeBottom].Weight = 3d;
            }
            row++;
            for (int i = 0; i < vivod_chet; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Range myRange = (Range)sheet1.Cells[row, j + 1];
                    myRange.Value2 = vivod[i, j];
                    myRange.Borders[XlBordersIndex.xlEdgeRight].Weight = 3d;
                    myRange.Borders[XlBordersIndex.xlEdgeBottom].Weight = 3d;
                }
                row = i + 6;/*4 + vivod_chet + 2;*/
            }
            for (int j = 0; j < WPFDataGrid_obraz.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1 + row, j + 1];
                sheet1.Cells[1 + row, j + 1].Font.Bold = true;
                myRange.Value2 = WPFDataGrid_obraz.Columns[j].Header;
                sheet1.Cells[1 + row, j + 1].Interior.Color = XlRgbColor.rgbLightGray;
                sheet1.Cells[1 + row, j + 1].Borders[XlBordersIndex.xlEdgeTop].Weight = 3d;
                sheet1.Cells[1 + row, j + 1].Borders[XlBordersIndex.xlEdgeRight].Weight = 3d;
                sheet1.Cells[1 + row, j + 1].Borders[XlBordersIndex.xlEdgeBottom].Weight = 3d;
                column = j;
            }
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    Range myRange = (Range)sheet1.Cells[row + i + 2, j + 1];
                    myRange.Value2 = Convert.ToString(Math.Round(massive[i, j], 1));
                    myRange.Borders[XlBordersIndex.xlEdgeRight].Weight = 3d;
                    myRange.Borders[XlBordersIndex.xlEdgeBottom].Weight = 3d;
                    for (short z = 0; z <= одинаковые_образцы[z]; z++)
                    {
                        if (одинаковые_образцы[z] != -1 && одинаковые_образцы[z] != 0)
                        {

                            if (massive[i, 0] == massive[одинаковые_образцы[z] - 1, 0])
                            {
                                myRange.Interior.Color = XlRgbColor.rgbLightGreen;
                            }
                        }
                    }
                }
            }
            sheet1.Columns.AutoFit();
            excel.Visible = true;
            excel.WindowState = XlWindowState.xlMaximized;
        }
    }
}