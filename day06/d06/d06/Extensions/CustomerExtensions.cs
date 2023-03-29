using System.Collections.Generic;
using System.Linq;
using d06.Models;

namespace d06.Extensions
{
    public static class CustomerExtensions
    {
        public static Register GetInLineByPeople(this Customer customer,
            IEnumerable<Register> registers)
        {
            return registers
                .OrderBy(x => x.QueuedCustomers.Count)
                .FirstOrDefault();
        }

        public static Register GetInLineByItems(this Customer customer,
            IEnumerable<Register> registers)
        {
            return registers
                .OrderBy(x => x.QueuedCustomers.Sum(c => c.ItemsInCart))
                .FirstOrDefault();
        }
    }
}