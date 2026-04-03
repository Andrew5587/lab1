using System;
using System.Collections;
using System.Collections.Generic;

namespace Core
{
    public class Storage
    {
        private List<Product> _items = new List<Product>();

        public void Add(Product item)
        {
            _items.Add(item);
        }

        // Реалізація "качиної типізації" для foreach через yield return
        public IEnumerator GetEnumerator()
        {
            foreach (var item in _items)
            {
                yield return item;
            }
        }
        
        public List<Product> AllItems => _items;
    }
}