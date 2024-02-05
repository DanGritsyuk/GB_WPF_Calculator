using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GB_WPF_Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calculator;

        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            calculator.Result += Calculator_Result;
        }

        private void Calculator_Result(object sender, CalculatorArgs e)
        {
            Display.Text = e.answer.ToString();
        }

        private void Operation_Button_Click(object sender, RoutedEventArgs e)
        {
            string name = (e.Source as FrameworkElement).Name;
            if (!int.TryParse(Display.Text, out int value))
            {
                MessageBox.Show("Некорректные данные!");
                Display.Text = string.Empty;
            }
            switch (name)
            {
                case "Add":
                    calculator.Add(value); break;
                case "Sub":
                    calculator.Sub(value); break;
                case "Mul":
                    calculator.Mul(value); break;
                case "Div":
                    calculator.Div(value); break;
                case "Cancel":
                    calculator.Cancel(); break;
                case "Equals":
                    // В раздумьях :)
                    break;
                default:
                    MessageBox.Show("Неизвестное арифметическое действие!");
                    Display.Text = string.Empty;
                    break;
            }
        }

        private void Number_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                // Проверяем, является ли введенный символ цифрой или плавающей запятой
                if (!char.IsDigit(e.Text, 0) && e.Text[0] != ',' && e.Text[0] != '.')
                {
                    e.Handled = true; // Отменяем ввод символа
                }
                else if ((e.Text[0] == ',' || e.Text[0] == '.') && textBox.Text.Contains(","))
                {
                    e.Handled = true; // Отменяем ввод дополнительной плавающей запятой
                }
                else
                {
                    // Заменяем запятую на точку
                    if (e.Text[0] == ',')
                    {
                        e.Handled = true;
                        textBox.SelectedText = ".";
                    }
                }
            }
        }

    }
}
