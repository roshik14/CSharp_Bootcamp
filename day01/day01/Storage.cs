using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    internal class Storage
    {
        public int GoodsCapacity { get; private set; }

        public Storage(int capacity) 
        {
            GoodsCapacity = capacity;
        }

        public void RemoveGoods(int count)
        {
            if (!IsEmpty)
                GoodsCapacity -= count;
        }

        public bool IsEmpty => GoodsCapacity == 0;
    }
}
