using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    internal class Store
    {
        private HashSet<CashRegister> _cashRegisters;
        public Storage Storage { get; }

        public IReadOnlySet<CashRegister> CashRegisters => _cashRegisters;

        public Store(int storageCapacity, int numberOfCashRegisters) 
        {
            Storage = new Storage(storageCapacity);
            _cashRegisters = new HashSet<CashRegister>();
            for (var i = 0; i < numberOfCashRegisters; i++)
            {
                _cashRegisters.Add(new CashRegister((i + 1).ToString()));
            }
        }

        public bool IsOpen() => !Storage.IsEmpty;

    }
}
