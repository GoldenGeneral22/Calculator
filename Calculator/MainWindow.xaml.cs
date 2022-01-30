using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string? saved;
        private void Button_Click_clear(object sender, RoutedEventArgs e)
        {
            inputTb.Text = "";
            list.Items.Clear();
        }

        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {
            try
            {
                result();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    result();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                }
            }
        }

        private void result()
        {
            String op;
            int iop = 0;
            if (inputTb.Text.Contains("+"))
            {
                iop = inputTb.Text.IndexOf("+");
            }
            else if (inputTb.Text.Contains("-"))
            {
                iop = inputTb.Text.IndexOf("-");
            }
            else if (inputTb.Text.Contains("*"))
            {
                iop = inputTb.Text.IndexOf("*");
            }
            else if (inputTb.Text.Contains("/"))
            {
                iop = inputTb.Text.IndexOf("/");
            }
            else
            {
                
            }

            string save = inputTb.Text;

            op = inputTb.Text.Substring(iop, 1);
            double op1 = Convert.ToDouble(inputTb.Text.Substring(0, iop));
            double op2 = Convert.ToDouble(inputTb.Text.Substring(iop + 1, inputTb.Text.Length - iop - 1));

            if (op == "+")
            {
                inputTb.Text = "" + Math.Round(op1 + op2, 5);
            }
            else if (op == "-")
            {
                inputTb.Text = "" + Math.Round(op1 - op2, 5);
            }
            else if (op == "*")
            {
                inputTb.Text = "" + Math.Round(op1 * op2, 5);
            }
            else
            {
                inputTb.Text = "" + Math.Round(op1 / op2, 5);
            }
            list.Items.Insert(0, save + " = " + inputTb.Text);
            inputTb.Select(inputTb.Text.Length, 0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            inputTb.Text += b.Content.ToString();
        }

        private void Button_Click_Comma(object sender, RoutedEventArgs e)
        {
            if (!inputTb.Text.Contains(","))
            {
                inputTb.Text += ",";
            }
        }

        private void Button_Click_BaseTentoBinary(object sender, RoutedEventArgs e)
        {
            if (!inputTb.Text.Contains(","))
            {
                int text = Int32.Parse(inputTb.Text);
                string binary = Convert.ToString(text, 2);
                saved = inputTb.Text;
                inputTb.Text = binary;
                Save();
            }
        }

        private void Button_Click_BinarytoBaseTen(object sender, RoutedEventArgs e)
        {
            int baseTen = Convert.ToInt32(inputTb.Text, 2);
            saved = inputTb.Text;
            inputTb.Text = baseTen.ToString();
            Save();
        }
        private void Button_Click_BaseTentoHex(object sender, RoutedEventArgs e)
        {
            if (!inputTb.Text.Contains(","))
            {
                int text = Int32.Parse(inputTb.Text);
                string binary = Convert.ToString((int)text, 16);
                saved = inputTb.Text;
                inputTb.Text = binary;
                Save();
            }
        }

        private void Button_Click_HextoBaseTen(object sender, RoutedEventArgs e)
        {
            int baseTen = Convert.ToInt32(inputTb.Text, 16);
            saved = inputTb.Text;
            inputTb.Text = baseTen.ToString();
            Save();
        }

        private void Button_Click_HextoBinary(object sender, RoutedEventArgs e)
        {
            saved = inputTb.Text;
            inputTb.Text =Convert.ToString(Convert.ToInt64(inputTb.Text, 16), 2);
            Save();
        }

        private void Button_Click_BinarytoHex(object sender, RoutedEventArgs e)
        {
            saved = inputTb.Text;
            inputTb.Text = Convert.ToInt32(inputTb.Text, 2).ToString("X");
            Save();
        }

        private void Save()
        {
            list.Items.Insert(0, saved + " -> " + inputTb.Text);
            inputTb.Select(inputTb.Text.Length, 0);
        }
    }
}
