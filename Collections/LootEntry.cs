using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retroLib.Collections
{
    public class LootEntry<T>(T item, float weight, bool isRare, int? pityThreshold)
    {
        public T Item { get; } = item;
        public float Weight { get; } = weight;
        public bool IsRare { get; } = isRare;
        public int? PityThreshold { get; } = pityThreshold;
    }
}
