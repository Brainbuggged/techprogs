using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace TProg4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        [DllImport(@"MyDllLibrary.dll")]
        static extern long Mul(int[] arr, int count);

      


        [DllImport(@"MyDllLibrary.dll")]
        static extern long Null(int[] arr, int count);

        [DllImport(@"MyDllLibrary.dll")]
        static extern void Min(int[] arr, int count);

        [DllImport(@"MyDllLibrary.dll")]
        static extern void MulMas(int[] arr, int[] arr2, int count);

        int[] mymas = new int[5];
        int[] mymas2 = new int[5];
        private void Button_min_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Check();
                Min(mymas, mymas.Length - 1);
                MessageBox.Show(mymas[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_multi_Click(object sender, RoutedEventArgs e)
        {
            try {
                Check();
                MessageBox.Show(Mul(mymas, mymas.Length)  .ToString());
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        public void Check()
        {
            
            if (int.TryParse(box1.Text, out int A) &&
                int.TryParse(box2.Text, out  int B) &&
                int.TryParse(box3.Text, out  int C) &&
                int.TryParse(box4.Text, out  int D) &&
                int.TryParse(box5.Text, out int E))
            {
              
                mymas[0] = A;
                mymas[1] = B;
                mymas[2] = C;
                mymas[3] = D;
                mymas[4] = E;
               
            

                
            }
            else { throw new Exception("Проверьте данные"); }

           

        }

        private void Button_null_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Check();
            
                MessageBox.Show(Null(mymas, mymas.Length).ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_mulMas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Check();
                SecCheck();
                MulMas(mymas, mymas2, 5);

                MessageBox.Show(
                    mymas2[0].ToString() + "\n" +
                    mymas2[1].ToString() + "\n" +
                    mymas2[2].ToString() + "\n" +
                    mymas2[3].ToString() + "\n" +
                    mymas2[4].ToString());
                        
                        

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void SecCheck()
        {
            if (int.TryParse(box6.Text, out int A) &&
                int.TryParse(box7.Text, out int B) &&
                int.TryParse(box8.Text, out int C) &&
                int.TryParse(box9.Text, out int D) &&
                int.TryParse(box10.Text, out int E))
            {

                mymas2[0] = A;
                mymas2[1] = B;
                mymas2[2] = C;
                mymas2[3] = D;
                mymas2[4] = E;




            }
            else { throw new Exception("Проверьте данные"); }
        }
    }
}
