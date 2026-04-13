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
        public void startAll()
        {
            p1 = new Person(canvas, 10, 10, Colors.LightGray, "Ole", "Ole.png");
            p2 = new Person(canvas, 30, 50, Colors.LightGreen, "Per", "Per.png");
            p3 = new Person(canvas, 60, 10, Colors.LightBlue, "Henriette", "Henriette.png");
            p4 = new Person(canvas, 10, 70, Colors.LightCoral, "Niels", "Niels.png");
            p5 = new Person(canvas, 50, 70, Colors.LightCyan, "Sofie", "Sofie.png");
            p6 = new Person(canvas, 30, 120, Colors.LightGray, "Jakup", "Jakup.png");
        }
        public Person p1, p2, p3, p4, p5, p6;
        public class Person
        {
            public string name;
            public Canvas MyCanvas;
            public Rectangle rect;
            public TextBlock text;
            public Image img = new Image();
            public Line line;
            static Random rand = new Random();
            public int width = 50;
            public int height = 50;

            public int x = 5;
            public int y = 0;
            public Person(Canvas mainCanvas, int xIn, int yIn, Color color, string nameIn, string url)
            {
                MyCanvas = new Canvas();
                x = xIn;
                y = yIn;
                name = nameIn;
                MyCanvas.Width = width;
                MyCanvas.Height = height;
                //------------Firkanten--------------------------
                rect = new Rectangle();
                rect.Stroke = new SolidColorBrush(color);
                rect.Fill = new SolidColorBrush(color);
                rect.StrokeThickness = 2;
                rect.Width = 50;
                rect.Height = 50;
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                MyCanvas.Children.Add(rect);
                //----------Texten----------------------
                text = new TextBlock();
                text.Text = name;
                text.Foreground = Brushes.Black;
                text.FontSize = 16;
                Canvas.SetLeft(text, x);
                Canvas.SetTop(text, y + 20);
                MyCanvas.Children.Add(text);
                //-------------billede------------------
                img = new Image();
                img.Width = 20;
                img.Height = 20;
                img.Source = new BitmapImage(new Uri(url, UriKind.Relative));
                Canvas.SetLeft(img, x);
                Canvas.SetTop(img, y);
                MyCanvas.Children.Add(img);
                //--------------Linje---------------------
                line = new Line();
                line.X1 = x+width/2;
                line.Y1 = y + height/2;
                line.X2 = x+100;
                line.Y2 = y +50;
                line.Stroke = Brushes.LightPink;
                line.StrokeThickness = 1;
                MyCanvas.Children.Add(line);
                //---------------Hoved Canvas ------------  
                mainCanvas.Children.Add(MyCanvas);
                //------Tråde laves og startes her--------
                Thread t = new Thread(flytPerson);
                t.Start();
                Thread t2 = new Thread(drawPerson);
                t2.Start();
            }
            public void flytPerson()
            {
                int time = rand.Next(100, 300);
                for (int i = 0; i < 50; i++)
                {
                    x = x + 2;
                    Thread.Sleep(time);
                }
            }
            public void drawPerson()
            {
                for (int i = 0; i < 100; i++)
                {
                    MyCanvas.Dispatcher.Invoke(() =>
                    {
                        //Læg mærke til at vi flytter hele personens canvas.
                        Canvas.SetLeft(MyCanvas, x);
                    });
                    Thread.Sleep(200);
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //p1.flytPerson();
            //p2.flytPerson();
            //p3.flytPerson();
            //p4.flytPerson();
            //p5.flytPerson();

            //p1.drawPerson();
            //p2.drawPerson();
            //p3.drawPerson();
            //p4.drawPerson();
            //p5.drawPerson();
        }
    }
}