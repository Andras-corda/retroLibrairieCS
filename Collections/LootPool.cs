using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retroLib.Collections
{
    public class LootPool<T>
    {
        private readonly List<LootEntry<T>> _entries = new();
        private readonly Random _random;
        private int _rollsSinceLastRare = 0;

        public LootPool(int? seed = null)
        {
            _random = seed.HasValue ? new Random(seed.Value) : new Random();
        }

        public LootPool<T> Add(T item, float weight, bool isRare = false, int? pityThreshold = null)
        {
            _entries.Add(new LootEntry<T>(item, weight, isRare, pityThreshold));
            return this;
        }

        public T Roll()
        {
            _rollsSinceLastRare++;

            var pityEntry = _entries.FirstOrDefault(e =>
                e.IsRare &&
                e.PityThreshold.HasValue &&
                _rollsSinceLastRare >= e.PityThreshold.Value);

            if (pityEntry != null)
            {
                _rollsSinceLastRare = 0;
                return pityEntry.Item;
            }

            float totalWeight = _entries.Sum(e => e.Weight);
            float roll = (float)_random.NextDouble() * totalWeight;
            float cumulative = 0;

            foreach (var entry in _entries)
            {
                cumulative += entry.Weight;
                if (roll <= cumulative)
                {
                    if (entry.IsRare) _rollsSinceLastRare = 0;
                    return entry.Item;
                }
            }

            return _entries.Last().Item;
        }

        public List<T> RollMany(int count)
        {
            var results = new List<T>();
            for (int i = 0; i < count; i++)
                results.Add(Roll());
            return results;
        }

        public T RollOnce()
        {
            if (_entries.Count == 0)
                throw new InvalidOperationException("Le pool est vide.");

            var entry = _entries[_random.Next(_entries.Count)];
            _entries.Remove(entry);
            return entry.Item;
        }

        public List<T> RollWithoutReplacement(int count)
        {
            if (count > _entries.Count)
                throw new ArgumentException("Pas assez d'entrées dans le pool.");

            var results = new List<T>();
            for (int i = 0; i < count; i++)
                results.Add(RollOnce());
            return results;
        }
    }
}
