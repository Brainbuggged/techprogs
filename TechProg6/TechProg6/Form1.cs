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
            outputTxtBox.Text = "";
            var rTest = new Regex("[0-7]");
            var lText = new Regex("[a-zA-Z]");
            var eightText = new Regex("[8-9]");

            if (inputTxtBox.Text != "")
            {
                if (rTest.IsMatch(inputTxtBox.Text) && !lText.IsMatch(inputTxtBox.Text)
                    && !eightText.IsMatch(inputTxtBox.Text))
                    outputTxtBox.AppendText("Корректное восьмеричное число\r\n");
                else
                    outputTxtBox.AppendText("Некорректное восьмеричное число\r\n");
            }
            else { outputTxtBox.Text = @"Обнаружено пустое поле"; }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            outputTxtBox.Text = "";
            var rTest = new Regex("[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{2,4}");

            if (inputTxtBox.Text != "")
            {
                outputTxtBox.AppendText(rTest.IsMatch(inputTxtBox.Text)
                    ? "Корректный электронный адрес\r\n"
                    : "Некорректный электронный адрес\r\n");
            }
            else { outputTxtBox.Text = @"Обнаружено пустое поле"; }
        }
    
        private void Button3_Click(object sender, EventArgs e)
        {
            outputTxtBox.Text = "";
            var passTest = new Regex(@"^[^)(1-9,\.\\\@\'\""{}<>:;*&'/]{1,}[0-9a-zA-Z_]{1,}$");
            foreach (Match m in passTest.Matches(inputTxtBox.Text))
            {
                outputTxtBox.AppendText(m.Value + "\n");
            }
        }
    }
}
