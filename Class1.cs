using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Class1
    {
        public class MyDataGridRow : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public short _Value1;
            public float _Value2;
            public float _Value3;
            public float _Value4;
            public float _Value5;
            public float _Value6;
            public float _Value7;
            public float _Value8;
            public float _Value9;
            public float _Value10;
            public float _Value11;
            public float _Value12;

            public void OnPropertyChanged(string prop)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(prop));
            }

            /*public void проверка(float _Value)
            {
                if (_Value.)
            }*/

            public short Value1
            {
                get { return _Value1; }
                set
                {
                    if (_Value1 == value) return;
                    _Value1 = value;
                    OnPropertyChanged("Value1");
                }
            }

            public float Value2
            {
                get { return _Value2; }
                set
                {
                    if (_Value2 == value) return;
                    _Value2 = value;
                    OnPropertyChanged("Value2");
                }
            }

            public float Value3
            {
                get { return _Value3; }
                set
                {
                    if (_Value3 == value) return;
                    _Value3 = value;
                    OnPropertyChanged("Value3");
                }
            }

            public float Value4
            {
                get { return _Value4; }
                set
                {
                    if (_Value4 == value) return;
                    _Value4 = value;
                    OnPropertyChanged("Value4");
                }
            }

            public float Value5
            {
                get { return _Value5; }
                set
                {
                    if (_Value5 == value) return;
                    _Value5 = value;
                    OnPropertyChanged("Value5");
                }
            }

            public float Value6
            {
                get { return _Value6; }
                set
                {
                    if (_Value6 == value) return;
                    _Value6 = value;
                    OnPropertyChanged("Value6");
                }
            }

            public float Value7
            {
                get { return _Value7; }
                set
                {
                    if (_Value7 == value) return;
                    _Value7 = value;
                    OnPropertyChanged("Value7");
                }
            }

            public float Value8
            {
                get { return _Value8; }
                set
                {
                    if (_Value8 == value) return;
                    _Value8 = value;
                    OnPropertyChanged("Value8");
                }
            }

            public float Value9
            {
                get { return _Value9; }
                set
                {
                    if (_Value9 == value) return;
                    _Value9 = value;
                    OnPropertyChanged("Value9");
                }
            }

            public float Value10
            {
                get { return _Value10; }
                set
                {
                    if (_Value10 == value) return;
                    _Value10 = value;
                    OnPropertyChanged("Value10");
                }
            }

            public float Value11
            {
                get { return _Value11; }
                set
                {
                    if (_Value11 == value) return;
                    _Value11 = value;
                    OnPropertyChanged("Value11");
                }
            }

            public float Value12
            {
                get { return _Value12; }
                set
                {
                    if (_Value12 == value) return;
                    _Value12 = value;
                    OnPropertyChanged("Value12");
                }
            }
        }
    }
}
