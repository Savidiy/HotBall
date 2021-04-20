using System.Collections.Generic;
using UnityEngine.Events;

namespace HotBall
{
    internal class Inventory
    {
        private readonly Dictionary<ItemType, int> _items = new Dictionary<ItemType, int>();

        public UnityAction OnUpdate;
        
        public void AddItem(Item item)
        {
            if (item.Type == ItemType.NONE) return;
            if (_items.ContainsKey(item.Type))
                _items[item.Type]++;
            else
                _items.Add(item.Type, 1);
            OnUpdate?.Invoke();
        }

        public bool HasItem(ItemType type)
        {
            return _items.ContainsKey(type);
        }
        
        public bool HasItems(ItemType type, int count)
        {
            return _items.ContainsKey(type) && _items[type] >= count;
        }

        public int GetItemCount(ItemType type)
        {
            return _items.ContainsKey(type) ? _items[type] : 0;
        }
    }
}