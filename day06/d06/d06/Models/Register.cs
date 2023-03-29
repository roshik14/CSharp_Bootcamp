using System;
using System.Collections.Concurrent;
using System.Threading;

namespace d06.Models
{
    public class Register
    {
        public int No { get; }
        public ConcurrentQueue<Customer> QueuedCustomers { get; } = new();

        public TimeSpan TimePerItem { get; }
        public TimeSpan TimePerCustomer { get; }

        public TimeSpan TotalTime { get; private set; } = TimeSpan.Zero;

        public int ProcessedCustomers { get; private set; } = 0;
        
        public Register(int number)
        {
            No = number;
        }

        public Register(int number, int maxTimePerItem, int maxTimePerCustomer)
        {
            No = number;
            var rnd = new Random();
            TimePerItem = TimeSpan.FromSeconds(rnd.Next(1, maxTimePerItem + 1));
            TimePerCustomer = TimeSpan.FromSeconds(rnd.Next(1, maxTimePerCustomer + 1));
        }

        public void Process(ref Storage storage)
        {
            if (!QueuedCustomers.TryDequeue(out var customer))
            {
                return;
            }
            var itemsCount = storage.GetItems(customer.ItemsInCart);
            var spendTime = TimePerCustomer + (TimePerItem * (customer.ItemsInCart - itemsCount));
            TotalTime += spendTime;
            ProcessedCustomers++;
            Console.WriteLine($"{this}, {customer}");

            Thread.Sleep(spendTime);
        }

        public override string ToString() => $"Register#{No} ({QueuedCustomers.Count} customers in line)";
    }
}