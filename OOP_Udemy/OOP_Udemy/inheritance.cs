using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy
{
    public class BankTeminal
    {
        protected string id;
        public BankTeminal(string id)
        {
            this.id = id;
        }
        public virtual void Connect()
        {
            Console.WriteLine("General Connecting Protocol...");
        }
    }

    public class ModelXTerminal: BankTeminal
    {
        public ModelXTerminal(string id) : base(id)
        {
        }
        public override void Connect()
        {
            base.Connect();
            Console.WriteLine("Additional actions for Model X");
        }
    }
    public class ModelYTerminal : BankTeminal
    {
        public ModelYTerminal(string id) : base(id)
        {
        }
        public override void Connect()
        {
            base.Connect();
            Console.WriteLine("Actions for Y");
        }
    }

}
