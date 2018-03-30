using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MynameSpace;
using System.Reflection;
using MyNextClassLibrary;
using System.Runtime.InteropServices;


namespace TechProg1
{
    public partial class Form1 : Form
    {
        string function5String;
        public Form1()
        {
            InitializeComponent();
        }
        public string Func1()
        {
            return "Александр Чернышев, ИСБО-11-16, Func1";

        }

        [DllImport("unmlib1.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void Func5([MarshalAs(UnmanagedType.BStr)]out string data);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void Func6Delegate([MarshalAs(UnmanagedType.BStr)]out string data);

   


        static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string dllToLoad);

            [DllImport("kernel32.dll")]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

            [DllImport("kernel32.dll")]
            public static extern Int32 GetLastError();

            [DllImport("kernel32.dll")]
            public static extern bool FreeLibrary(IntPtr hModule);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Func1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class2 Func2 = new Class2();
            MessageBox.Show(Func2.Func2()); }

        private void button3_Click(object sender, EventArgs e)
        {
            Class3 Func3 = new Class3();
            MessageBox.Show(Func3.Func3());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assembly lib = Assembly.LoadFile(Application.StartupPath + "\\MyNextClassLibrary.dll");
            Type myType = lib.GetType("MyNextClassLibrary.Class4");
            dynamic obj = Activator.CreateInstance(myType);
            MessageBox.Show(obj.Func4());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Func5( out function5String);
            MessageBox.Show(function5String);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            IntPtr pDll = NativeMethods.LoadLibrary(Application.StartupPath + "\\unmlib2.dll");
            IntPtr FuncAddr = NativeMethods.GetProcAddress(pDll, "Func6");

            Func6Delegate Func6 = (Func6Delegate)Marshal.GetDelegateForFunctionPointer(FuncAddr, typeof(Func6Delegate));

            String str1;
            Func6(out str1);
            MessageBox.Show(str1);
            NativeMethods.FreeLibrary(pDll);
        }
    }
}
