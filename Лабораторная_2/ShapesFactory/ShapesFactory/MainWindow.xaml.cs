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
using ShapesFactory.Shapes;
using ShapesFactory.Creators;

namespace ShapesFactory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<ShapeCreator>> _creatorsByColor;
        public MainWindow()
        {
            InitializeComponent();
            _creatorsByColor = new Dictionary<string, List<ShapeCreator>>
            {
                ["Red"] = new List<ShapeCreator>
            {
                new RedCircleCreator(),
                new RedSquareCreator(),
                new RedTriangleCreator()
            },
                ["Blue"] = new List<ShapeCreator>
            {
                new BlueCircleCreator(),
                new BlueSquareCreator(),
                new BlueTriangleCreator()
            },
                ["Green"] = new List<ShapeCreator>
            {
                new GreenCircleCreator(),
                new GreenSquareCreator(),
                new GreenTriangleCreator()
            }
            };
            //MyButton.Click += new RoutedEventHandler(Button1_Click);
        }

        // обработчик, подключаемый в XAML
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tools.Clear(MyCanvas);


            IShape[] shapes = { new Triangle(Brushes.Green, 25), new Circle(Brushes.Blue, 12.5), new Square(Brushes.Red, 25)};

            foreach (var shape in shapes)
            {
                shape.Draw(MyCanvas);
            }

        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tools.Clear(MyCanvas);

            var selectedTextBlock = ColorComboBox.SelectedItem as TextBlock;
            if (selectedTextBlock == null) return;

            string selectedColor = selectedTextBlock.Text;

            if (_creatorsByColor.TryGetValue(selectedColor, out var creators))
            {
                foreach (var creator in creators)
                {
                    IShape shape = creator.CreateShape();
                    shape.Draw(MyCanvas);
                }
            }
        }
        // обработчик, подключаемый в конструкторе
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi from Button1_Click");
        }
    }
}