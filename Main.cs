using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        string clipread, clippaste;
        char c = ' ';
        double a, b, m, clear_number;
        public Main()
        {
            InitializeComponent();
        }

        //Кнопки цифр
        private void numbers(object sender, EventArgs e)
        {
            if ((textBox1.Text != "0") && (textBox1.Text != "Деление на ноль невозможно") && (clear_number == 0) && (textBox1.Text != "Неверные входые данные"))
            {
                textBox1.Text += (sender as Button).Text;
            }
            else
            {
                textBox1.Text = (sender as Button).Text;
                clear_number = 0;
            }
        }

        // , запятая
        private void comma(object sender, EventArgs e)
        {
            if ((textBox1.Text.IndexOf(',') == -1) && (textBox1.Text != "Деление на ноль невозможно") && (textBox1.Text != "Неверные входые данные") && (textBox1.Text.IndexOf('E') == -1))
            {
                textBox1.Text += ',';
            }
        }

        //Удаление символа
        private void backspace(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf('E') == -1)
            {
                if ((textBox1.Text == "Деление на ноль невозможно") && (textBox1.Text != "Неверные входые данные"))
                {
                    textBox1.Text = "0";
                }
                if (textBox1.Text.Length != 0)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
                if (textBox1.Text.Length == 0)
                {
                    textBox1.Text = "0";
                }
                if (textBox1.Text == "-")
                {
                    textBox1.Text = "0";
                }
            }
        }

        //удаление строки
        private void clearline(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        //очищение всего
        private void clearall(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            a = 0;
            b = 0;
            c = ' ';
        }

        //мат функции
        private void math_act(object sender, EventArgs e)
        {
            if ((textBox1.Text != "Деление на ноль невозможно") && (textBox1.Text != "Неверные входые данные"))
            {
                button28.PerformClick();
                textBox2.Text = textBox1.Text + "  " + (sender as Button).Text;
                clear_number = 1;
            }
        }

        //смена знака
        private void change_sight(object sender, EventArgs e)
        {
            if ((textBox1.Text != "Деление на ноль невозможно") && (textBox1.Text != "Неверные входые данные"))
            {
                textBox1.Text = (-Convert.ToDouble(textBox1.Text)).ToString();
            }
        }

        //= равно
        private void equally(object sender, EventArgs e)
        {
            if (((textBox2.Text != "") || ((c != ' ') && (b != 0))) && (textBox1.Text != "Деление на ноль невозможно") && (textBox1.Text != "Неверные входые данные"))
            {
                if (textBox2.Text != "")
                {
                    c = textBox2.Text[textBox2.Text.Length - 1];
                    b = Convert.ToDouble(textBox1.Text);
                    a = Convert.ToDouble(textBox2.Text.Remove(textBox2.Text.Length - 3));
                }
                else
                {
                    a = Convert.ToDouble(textBox1.Text);
                }
                switch (c)
                {
                    case '+':
                        {
                            textBox1.Text = (a + b).ToString();
                            break;
                        }
                    case '-':
                        {
                            textBox1.Text = (a - b).ToString();
                            break;
                        }
                    case '*':
                        {
                            textBox1.Text = (a * b).ToString();
                            break;
                        }
                    case '/':
                        {
                            if (b != 0)
                            {
                                textBox1.Text = (a / b).ToString();
                            }
                            else
                            {
                                textBox1.Text = "Деление на ноль невозможно";
                            }
                            break;
                        }
                }
                textBox2.Text = "";
                clear_number = 1;
            }
        }

        //1/x 
        private void back_number(object sender, EventArgs e)
        {
            if ((textBox1.Text != "Деление на ноль невозможно") && (textBox1.Text != "Неверные входые данные"))
            {
                textBox1.Text = (1 / Convert.ToDouble(textBox1.Text)).ToString();
                clear_number = 1;
            }
        }

        // корень
        private void sqrt(object sender, EventArgs e)
        {
            if (textBox1.Text[0] == '-')
            {
                textBox1.Text = "Неверные входые данные";
            }
            if ((textBox1.Text != "Деление на ноль невозможно") && (textBox1.Text != "Неверные входые данные"))
            {
                textBox1.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(textBox1.Text)));
                clear_number = 1;
            }
        }

        //сохранение числа в буфер
        private void MS(object sender, EventArgs e)
        {
            if ((textBox1.Text != "Деление на ноль невозможно") && (textBox1.Text != "Неверные входые данные"))
            {
                m = Convert.ToDouble(textBox1.Text);
                Buffer.Text = "M=" + m.ToString();
                clear_number = 1;
            }
        }

        //запись числа из буфера в первое поле
        private void MR(object sender, EventArgs e)
        {
            textBox1.Text = (m).ToString();
            clear_number = 1;
        }

        //очищение буфера
        private void MC(object sender, EventArgs e)
        {
            m = 0;
            Buffer.Text = "M=" + m.ToString();
        }

        //добавление к числу в буфере
        private void Mplus(object sender, EventArgs e)
        {
            m += Convert.ToDouble(textBox1.Text);
            Buffer.Text = "M=" + m.ToString();
            clear_number = 1;
        }

        //вычитание из числа в буфере
        private void Mminus(object sender, EventArgs e)
        {
            m -= Convert.ToDouble(textBox1.Text);
            Buffer.Text = "M=" + m.ToString();
            clear_number = 1;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if ((textBox1.Text != "0") && (textBox1.Text != "Деление на ноль невозможно") && (textBox1.Text != "Неверные входые данные"))
                {
                    textBox1.Text += e.KeyChar;
                }
                else
                {
                    textBox1.Text = e.KeyChar.ToString();
                }
            }
            if ((e.KeyChar == '+') || (e.KeyChar == '-') || (e.KeyChar == '*') || (e.KeyChar == '/'))
            {
                if (textBox1.Text != "Деление на ноль невозможно")
                {
                    button28.PerformClick();
                    textBox2.Text = textBox1.Text + "  " + e.KeyChar.ToString();
                    textBox1.Text = "0";
                }
            }
            if ((e.KeyChar == ',') || (e.KeyChar == '.'))
            {
                button5.PerformClick();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    {
                        button19.PerformClick();
                        break;
                    }
                case Keys.Enter:
                    {
                        button28.PerformClick();
                        break;
                    }
            }
            if ((e.Control) && (e.KeyCode == Keys.C))
            {
                Clipboard.SetText(textBox1.Text);
            }
            if ((e.Control) && (e.KeyCode == Keys.V))
            {
                clippaste = "";
                clipread = Clipboard.GetText();
                if (clipread != "")
                {
                    for (int i = 0; i <= clipread.Length - 1; i++)
                    {
                        if ((Convert.ToByte(clipread[i]) >= 48) && (Convert.ToByte(clipread[i]) <= 57))
                        {
                            clippaste += clipread[i];
                        }
                    }
                    if (clippaste != "")
                    {
                        textBox1.Text = clippaste;
                    }
                }
            }

        }

        private void focus(object sender, EventArgs e)
        {
            Buffer.Focus();

        }

        private void percent(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                c = textBox2.Text[textBox2.Text.Length - 1];
                b = Convert.ToDouble(textBox1.Text);
                a = Convert.ToDouble(textBox2.Text.Remove(textBox2.Text.Length - 3));
                b = a / 100 * b;
                switch (c)
                {
                    case '+':
                        {
                            textBox1.Text = (a + b).ToString();
                            break;
                        }
                    case '-':
                        {
                            textBox1.Text = (a - b).ToString();
                            break;
                        }
                    case '*':
                        {
                            textBox1.Text = b.ToString();
                            break;
                        }
                    case '/':
                        {
                            if (b != 0)
                            {
                                textBox1.Text = (a / b).ToString();
                            }
                            else
                            {
                                textBox1.Text = "Деление на ноль невозможно";
                            }
                            break;
                        }
                }
                textBox2.Text = "";
                clear_number = 1;
            }
        }

    }
}
