using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechProg3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void Del(string message);

        static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        void DumpObject(object obj)
        {
          
            var obj_type = obj.GetType();


            richTextBox2.AppendText("================"
                + obj_type.Name + "===============\r\n");
            richTextBox2.AppendText("ASSEMBLY NAME: " + obj_type.Assembly.GetName().Name + "\r\n");
            richTextBox2.AppendText("MODIFIERS: " +
                (obj_type.IsNestedPublic ? "public " : "") +
                (obj_type.IsNestedPrivate ? "private " : "") +
                (obj_type.IsNestedAssembly ? "internal " : "") +
                (obj_type.IsNestedFamily ? "protected " : "") + "\r\n"
                );
            if (obj_type.BaseType == null) return;
            richTextBox2.AppendText("PARENT :" +
                                    obj_type.BaseType.Name + "\r\n\r");

            richTextBox2.AppendText("PUBLIC INTERFACE:\r\n");
            richTextBox2.AppendText("FIELDS:\r\n");

            var fields = obj_type.GetFields(BindingFlags.Public | BindingFlags.Instance
                                                                        | BindingFlags.Static);
            foreach (FieldInfo field in fields )
            {
                richTextBox2.AppendText((field.IsPublic ? "public " : "") + (field.IsAssembly ? "internal " : "") +
                                        (field.IsFamily ? "protected " : "") + (field.IsStatic ? "static " : "") +
                                        field.FieldType.Name +
                                        " " + field.Name + "\r\n");
                richTextBox2.AppendText("PROPERTIES:\r\n");
            }

            PropertyInfo[] properties = obj_type.GetProperties(BindingFlags.Public | BindingFlags.Instance
                                                                                   | BindingFlags.Static);
            foreach (PropertyInfo property in properties)
                richTextBox2.AppendText("public " + property.PropertyType.Name + " " + property.Name + " { "
                                        + (property.CanRead ? "get; " : "") + (property.CanWrite ? "set; " : "") +
                                        "}\r\n");

            richTextBox2.AppendText("METHODS:\r\n");
            var methods = obj_type.GetMethods(BindingFlags.Public | BindingFlags.Instance
                                                                           | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                string m;
                m = (method.IsPublic ? "public " : "") + (method.IsAssembly ? "internal " : "") +
                    (method.IsFamily ? "protected " : "") + (method.IsStatic ? "static " : "") +
                    method.ReturnType.Name + " " + method.Name + "(";
                foreach (ParameterInfo param in method.GetParameters())
                    m += (param.IsOut ? "out " : "") + param.ParameterType.Name + " " + param.Name + ", ";
                m += ")\r\n";
                if (method.IsVirtual && method.GetBaseDefinition().DeclaringType.Name != obj_type.Name)
                {
                    richTextBox2.SelectionColor = Color.Yellow;
                }

                if (method.IsVirtual && method.GetBaseDefinition().DeclaringType.Name == obj_type.Name)
                    richTextBox2.SelectionColor = Color.Green;
                if (method.DeclaringType.Name != "Object")
                {
                    MethodInfo[] infos = method.DeclaringType.BaseType.GetMethods(BindingFlags.Public |
                                                                                  BindingFlags.Instance |
                                                                                  BindingFlags.Static);
                    var list = new List<String>();
                    foreach (MethodInfo meth in infos)
                        list.Add(meth.Name);
                    if (!method.IsVirtual && list.Contains(method.Name))
                        richTextBox2.SelectionColor = Color.Red;
                    richTextBox2.AppendText(m);
                }
                else
                    richTextBox2.AppendText(m);


                if (method.IsVirtual)
                {
                    richTextBox2.AppendText("  Defined in: " + method.DeclaringType.Name + "\r\n");
                    richTextBox2.AppendText("  Created in: " + method.GetBaseDefinition().DeclaringType.Name +
                                            "\r\n");
                }
            }


            richTextBox2.AppendText("PRIVATE INTERFACE:\r\n");
            richTextBox2.AppendText("FIELDS:\r\n");

            FieldInfo[] fields1 = obj_type.GetFields(BindingFlags.Instance | BindingFlags.DeclaredOnly
                                                                           | BindingFlags.NonPublic |
                                                                           BindingFlags.Static);
            foreach (FieldInfo field in fields1)
                richTextBox2.AppendText((field.IsPrivate ? "private " : "") +
                                        (field.IsAssembly ? "internal " : "") +
                                        (field.IsFamily ? "protected " : "") + (field.IsStatic ? "static " : "") +
                                        field.FieldType.Name +
                                        " " + field.Name + "\r\n");

            richTextBox2.AppendText("PROPERTIES:\r\n");


            var properties1 = obj_type.GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly |
                                                     BindingFlags.NonPublic | BindingFlags.Static);
            foreach (PropertyInfo property in properties1)
            {
                var getMeth = property.GetGetMethod(true);
                var setMeth = property.GetSetMethod(true);
                var attr = "";

                if (getMeth != null)
                {
                    if (getMeth.IsPrivate)
                        attr += "private ";
                    if (getMeth.IsAssembly)
                        attr += "internal ";
                    if (getMeth.IsFamily)
                        attr += "protected ";
                    if (getMeth.IsStatic)
                        attr += "static ";
                }

                if (setMeth != null)
                {
                    attr = "";
                    if (setMeth.IsPrivate)
                        attr += "private ";
                    if (setMeth.IsAssembly)
                        attr += "internal ";
                    if (setMeth.IsFamily)
                        attr += "protected ";
                    if (setMeth.IsStatic)
                        attr += "static ";
                }

                richTextBox2.AppendText(attr + property.PropertyType.Name + " " + property.Name + " { "
                                        + (property.CanRead ? "get; " : "") + (property.CanWrite ? "set; " : "") +
                                        "}\r\n");
            }


            richTextBox2.AppendText("METHODS:\r\n");

            MethodInfo[] methods1 = obj_type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly
                                                                              | BindingFlags.NonPublic |
                                                                              BindingFlags.Static
            );
            foreach (MethodInfo method in methods1)
            {
                string m;
                m = (method.IsPrivate ? "private " : "") + (method.IsAssembly ? "internal " : "") +
                    (method.IsFamily ? "protected " : "") + (method.IsStatic ? "static " : "")
                    + method.ReturnType.Name + " " + method.Name + "(";
                m = method.GetParameters().Aggregate(m, (current, param) => current + ((param.IsOut ? "out " : "")
                                                                                       + param.ParameterType.Name +
                                                                                       " " + param.Name + ", "));
                m += ")\r\n";

                if (method.IsVirtual && method.GetBaseDefinition().DeclaringType.Name != obj_type.Name)
                {
                    richTextBox2.SelectionColor = Color.Yellow;
                }

                if (method.IsVirtual && method.GetBaseDefinition().DeclaringType.Name == obj_type.Name)
                    richTextBox2.SelectionColor = Color.Green;
                var infos = method.DeclaringType.BaseType.GetMethods(BindingFlags.Instance |
                                                                     BindingFlags.NonPublic | BindingFlags.Static);
                var list = infos.Select(meth => meth.Name).ToList();
                if (!method.IsVirtual && list.Contains(method.Name))
                    richTextBox2.SelectionColor = Color.Red;


                richTextBox2.AppendText(m);

                if (method.IsVirtual)
                {
                    richTextBox2.AppendText("  Defined in: " + method.DeclaringType.Name + "\r\n");
                    richTextBox2.AppendText("  Created in: " + method.GetBaseDefinition().DeclaringType.Name +
                                            "\r\n");
                }
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DumpObject(new RTTIRoot());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DumpObject(new RTTIClass21());
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            richTextBox2.Clear();
            DumpObject(new RTTIClass1());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DumpObject(new RTTIClass2());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DumpObject(new RTTIClass11());
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DumpObject(new RTTIClass12());
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DumpObject(new RTTIClass22());
        }

        private class RTTIClass11 : RTTIClass1
        {
            internal float D;
            private float PropD { get { return D; } }
            internal new void DoIt() { }
        }
    }
}

