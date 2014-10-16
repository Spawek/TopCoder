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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TopCoderTestGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Generate_Click(object sender, RoutedEventArgs e)
        {
            TopCoderTaskParser parser = new TopCoderTaskParser();
            ParsedTopCoderTask task = parser.Parse(TextBox_Input.Text);
            TopCoderFileGenerator generator = new TopCoderFileGenerator();
            TextBox_Output.Text = generator.generate(task);
        }
    }
}
