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
using BinaryCalculator.Core;

namespace BinaryCalculator.Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Calculator _calculator = new Calculator();
        
        public MainWindow()
        {
            InitializeComponent();
            Input.Text = _calculator.CurrentInput.Value;
        }

        private void ClearLast(object sender, RoutedEventArgs e)
        {
            _calculator.ClearLastEntry();
            Input.Text = _calculator.CurrentInput.Value;
        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            _calculator.ClearAll();
            Input.Text = _calculator.CurrentInput.Value;
        }

        private void EnterOne(object sender, RoutedEventArgs e)
        {
            _calculator.EnterOne();
            Input.Text = _calculator.CurrentInput.Value;
        }

        private void EnterZero(object sender, RoutedEventArgs e)
        {
            _calculator.EnterZero();
            Input.Text = _calculator.CurrentInput.Value;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            _calculator.Add();
            Input.Text = _calculator.CurrentInput.Value;
        }

        private void Subtract(object sender, RoutedEventArgs e)
        {
            _calculator.Subtract();
            Input.Text = _calculator.CurrentInput.Value;
        }

        private void Perform(object sender, RoutedEventArgs e)
        {
            _calculator.PerformOperation();
            Input.Text = _calculator.CurrentResult.Value;
        }
    }
}
