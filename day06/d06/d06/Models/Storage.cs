using System.Threading;

namespace d06.Models
{
    public class Storage
    {
        private readonly object _lock = new();

        private int itemsInStorage;

        public bool IsEmpty
        { 
            get
            {
                lock (_lock)
                {
                    return itemsInStorage <= 0;
                }
            }
        }
        
        public Storage(int totalItemCount)
        {
            itemsInStorage = totalItemCount;
        }

        public int GetItems(int count)
        {
            lock (_lock)
            {
                int result = count - itemsInStorage >= 0 ? count - itemsInStorage : 0;
                itemsInStorage -= count;
                return result;
            }
        }
    }
}