using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfAnimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            startAll();
        }
        Image img = new Image();
        public void startAll()
        {
            //-------------billede------------------                
            img.Width = 50;
            img.Height = 50;
            img.Source = new BitmapImage(new Uri("car3.png", UriKind.Relative));
            img.Opacity = 1.0;
            Canvas.SetLeft(img, 0);
            Canvas.SetTop(img, 0);
            //-----------billed på canvas-----------
            canvas.Children.Add(img); 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            flyt();
        }

        private void flyt()
        {
            double x = Canvas.GetLeft(img); //Henter x pos som img har lige nu.
            Canvas.SetLeft(img, x + 10); //flytter img 10 til højre.
        }

    }
}