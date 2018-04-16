using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TechProg6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            var rTest = new Regex("[0-7]");
            var lText = new Regex("[a-zA-Z]");
            var eightText = new Regex("[8-9]");

            if (richTextBox1.Text != "")
            {
                if (rTest.IsMatch(richTextBox1.Text) && !lText.IsMatch(richTextBox1.Text)
                    && !eightText.IsMatch(richTextBox1.Text))
                    textBox1.AppendText("Корректное восьмеричное число\r\n");
                else
                    textBox1.AppendText("Некорректное восьмеричное число\r\n");
            }
            else { textBox1.Text = @"Обнаружено пустое поле"; }

        }

        private void Button2_Click(object sender, EventArgs e)
        {


            textBox1.Text = "";
            var rTest = new Regex("[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{2,4}");

            if (richTextBox1.Text != "")
            {
                textBox1.AppendText(rTest.IsMatch(richTextBox1.Text)
                    ? "Корректный электронный адрес\r\n"
                    : "Некорректный электронный адрес\r\n");
            }
            else { textBox1.Text = @"Обнаружено пустое поле"; }
        }
    
        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
         
            var passTest = new Regex(@"^[^)(1-9,\.\\\@\'\""{}<>:;*&'/]{1,}[0-9a-zA-Z_]{1,}$");

            //var passTest1 = new Regex(@"^[\D_]*[\d]*");
            foreach (Match m in passTest.Matches(richTextBox1.Text))
            {
                textBox1.AppendText(m.Value + "\n");
            }


        }
    }
}
