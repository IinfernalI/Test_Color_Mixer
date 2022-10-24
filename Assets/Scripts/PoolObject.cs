using System.Collections.Generic;

namespace DefaultNamespace
{
    public class PoolObject
    {
        private Dictionary<ItemType, Stack<Item>> itemdictionary = new Dictionary<ItemType, Stack<Item>>();

        public bool TryGet(ItemType type, out Item item)
        {
            if (itemdictionary.TryGetValue(type, out Stack<Item> stack) == false)
            {
                item = null;
                return false;                
            }
            
            if (stack.TryPop(out Item element) == false)
            {
                item = null;
                return false;  
            }

            item = element;
            return true;
        }

        public void Push(Item item)
        {
            if (itemdictionary.ContainsKey(item.Type) == false)
            {
                Stack<Item> stack = new Stack<Item>();
                stack.Push(item);
                itemdictionary.Add(item.Type, stack);
            }
            else
            {
                itemdictionary[item.Type].Push(item);
            }
        }
        
        
    }
}