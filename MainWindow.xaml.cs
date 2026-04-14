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
        Image img2 = new Image();
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
            //-------------billede------------------                
            img2.Width = 50;
            img2.Height = 50;
            img2.Source = new BitmapImage(new Uri("Guitar.png", UriKind.Relative));
            img2.Opacity = 1.0;
            Canvas.SetLeft(img2, 0);
            Canvas.SetTop(img2, 50);
            //-----------billed på canvas-----------
            canvas.Children.Add(img2);
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            flyt(img, 10);
            flyt(img2, 7);
        }
        private async Task flyt(Image imgIn, int hastighed)
        {
            for (int i = 0; i < 300; i++)
            {
                double x = Canvas.GetLeft(imgIn); //Henter x pos som img har lige nu.
                Canvas.SetLeft(imgIn, x + hastighed); //flytter img 10 til højre.
                if (x > 200)
                    Canvas.SetLeft(imgIn, 0);
                await Task.Delay(100);
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                // drej bil til venstre
            }
            else if (e.Key == Key.Right)
            {
                // drej bil til højre
            }
            else if (e.Key == Key.Up)
            {
                double y = Canvas.GetTop(img2); //Henter x pos som img har lige nu.
                Canvas.SetTop(img2, y - 5); //flytter img 10 til højre.
            }
            else if (e.Key == Key.Down)
            {
                double y = Canvas.GetTop(img2); //Henter x pos som img har lige nu.
                Canvas.SetTop(img2, y + 5); //flytter img 10 til højre.
            }
        }

    }
}