using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace hm11_10hm
{
    class Primer : INotifyPropertyChanged
    {
        private double a;
        private double b;

        public double A { get { return a; } set { a = value; onPropertyChanged("Число А"); } }
        public double B { get { return b; } set { b = value; onPropertyChanged("Число Б"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Sum()
        {
            string ans = Convert.ToString(A + B);
            return ans;
        }

        void onPropertyChanged(params string[] propertyNames)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                foreach (var pn in propertyNames)
                {
                    handler(this, new PropertyChangedEventArgs(pn));
                }
            }
        }
    }


    public partial class MainWindow : Window
    {
        Primer primer;

        public MainWindow()
        {
            InitializeComponent();
            primer = new Primer();
            this.DataContext = primer;
        }

        private void result_GotFocus(object sender, RoutedEventArgs e)
        {
            result.Text = primer.Sum();
        }
    }
}