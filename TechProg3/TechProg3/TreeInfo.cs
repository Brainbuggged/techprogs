using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechProg3
{
    partial class Form1 : Form
    {
        public class RTTIRoot
        {
            internal int A;
            public int PA;
            public int Prop1 { get; set; }
            internal void DoIt() { }
            public virtual void DoThat() { }
        }
         
       
        internal class RTTIClass1 : RTTIRoot
        {
            private int B;
            public string C;
            internal new void DoIt() { }
            public override void DoThat() { }
        }

     

        internal class RTTIClass12 : RTTIClass1
        {
            public override void DoThat() { }
        }

        public class RTTIClass2 : RTTIRoot
        {
            protected int Proto1;
            protected int PropProto { set { Proto1 = value; DoAnother(); } }
            private int DoAnother() { return 25; }
            public new virtual void DoThat() { }
          
        }

        protected class RTTIClass21 : RTTIClass2
        {
            private static int St1;
            public RTTIClass21() { St1 = 100500; }
            internal new void DoIt() { }
        }

     

        public class RTTIClass22 : RTTIClass2
        {
            public override void DoThat() { }
            private Del _Sw;
           
            


        }
      
   
         
    }

}
