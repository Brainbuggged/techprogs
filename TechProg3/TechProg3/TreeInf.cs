
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TechProg3
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

     class RTTIClass11 : RTTIClass1
    {
        internal float D;
        private float PropD { get { return D; } }
        internal new void DoIt() { }
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

     class RTTIClass21 : RTTIClass2
    {
        private static int St1;
        public RTTIClass21() { St1 = 100500; }
        internal new void DoIt() { }
    }



    public class RTTIClass22 : RTTIClass2
    {
        public override void DoThat() { }

    }
}