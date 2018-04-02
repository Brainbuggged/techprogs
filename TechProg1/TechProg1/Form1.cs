using MyClassLibrary;
using System;
using System.Windows.Forms;
using MynameSpace;
using System.Reflection;
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
        public string Func1() => "Александр Чернышев, ИСБО-11-16, Func1";

        [DllImport("unmlib1.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void Func5([MarshalAs(UnmanagedType.BStr)]out string data);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void Func6Delegate([MarshalAs(UnmanagedType.BStr)]out string data);


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Func1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Func2 = new Class2();
            MessageBox.Show(Func2.Func2()); }

        private void button3_Click(object sender, EventArgs e)
        {
            var Func3 = new Class3();
            MessageBox.Show(Func3.Func3());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var lib = Assembly.LoadFile(Application.StartupPath + "\\MyNextClassLibrary.dll");
            var myType = lib.GetType("MyNextClassLibrary.Class4");
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
            var pDll = NativeMethods.LoadLibrary(Application.StartupPath + "\\unmlib2.dll");
            var FuncAddr = NativeMethods.GetProcAddress(pDll, "Func6");

            var Func6 = (Func6Delegate)Marshal.GetDelegateForFunctionPointer(FuncAddr, typeof(Func6Delegate));

            Func6(out var str1);
            MessageBox.Show(str1);
            NativeMethods.FreeLibrary(pDll);
        }
    }
}
