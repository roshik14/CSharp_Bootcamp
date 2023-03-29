using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using d06.Extensions;
using d06.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace d06
{
    class Program
    {
        private static readonly object _lock = new();

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var maxTimePerItem = int.Parse(config.GetSection("timePerItem").Value);
            var maxTimePerCustomer = int.Parse(config.GetSection("timePerCustomer").Value);

            Console.WriteLine("Customers choose the shortest queue: ");
            SimulateStoreOperation(maxTimePerItem, maxTimePerCustomer, 1);
            Console.WriteLine("Customers choose the queue with the least number of goods.");
            SimulateStoreOperation(maxTimePerItem, maxTimePerCustomer, 2);
        }

        static void SimulateStoreOperation(int maxTimePerItem, int maxTimePerCustomer, int operationCase)
        {
            const int registerCount = 4;
            const int storageCapacity = 50;
            const int cartCapacity = 7;
            const int customerCount = 10;

            var customers = Enumerable.Range(1, customerCount)
                .Select(x => new Customer(x))
                .ToArray();

            var store = new Store(registerCount, storageCapacity, maxTimePerItem, maxTimePerCustomer);

            Parallel.ForEach(customers, x =>
                AddCustomerToRegister(x, store.Registers, operationCase, cartCapacity));

            var thread = new Thread(() =>
            {
                var next = 11;
                while (store.IsOpen)
                {
                    Thread.Sleep((int)TimeSpan.FromSeconds(7).TotalMilliseconds);
                    var customer = new Customer(next++);
                    AddCustomerToRegister(customer, store.Registers, operationCase, cartCapacity);
                }
            });

            thread.Start();

            store.OpenRegisters();
            Parallel.ForEach(store.Registers, x =>
            {
                var average = x.TotalTime / x.ProcessedCustomers;
                Console.WriteLine($"{x}, Average: {average.TotalSeconds:N2}");
            });

            thread.Join();
        }

        static void AddCustomerToRegister(Customer customer, List<Register> registers, int operationCase, int count)
        {
            lock (_lock)
            {
                customer.FillCart(count);
                var register = operationCase == 1
                    ? customer.GetInLineByPeople(registers)
                    : customer.GetInLineByItems(registers);
                register?.QueuedCustomers.Enqueue(customer);
            }
        }
    }
}
