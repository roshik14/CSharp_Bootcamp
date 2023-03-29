using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d06.Models
{
    public class Store
    {
        private Storage _storage;

        public List<Register> Registers { get; }
        public Storage Storage => _storage;

        public bool IsOpen => !Storage.IsEmpty;

        public Store(int registerCount,
            int storageCapacity,
            int maxTimePerItem,
            int maxTimePerCustomer)
        {
            
            _storage = new Storage(storageCapacity);
            Registers = Enumerable.Range(1, registerCount)
                .Select(i => new Register(i,maxTimePerItem, maxTimePerCustomer))
                .ToList();
        }

        public void OpenRegisters()
        {
            Parallel.ForEach(Registers, x =>
            {
                while (IsOpen)
                {
                    x.Process(ref _storage);
                }
            });
        }
    }
}