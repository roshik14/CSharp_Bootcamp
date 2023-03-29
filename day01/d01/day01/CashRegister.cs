using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    internal class CashRegister
    {
        public Queue<Customer> Customers { get; }
        public string Name { get; }

        public CashRegister(string name)
        {
            Name = name;
            Customers = new Queue<Customer>();
        }

        public override string ToString()
        {
            return $"Register #{Name}";
        }

    }
}
