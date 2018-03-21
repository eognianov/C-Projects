using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Bag
    {
        private List<Item> items;

        public int Capacity { get; private set; }

        public int Load => Items.Sum(i => i.Weight);

        public List<Item> Items => items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (this.Load+item.Weight>this.Capacity)
            {
                throw new InvalidOperationException(ErrorMessages.BagIsFull);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count==0)
            {
                throw new InvalidOperationException(ErrorMessages.BasIsEmpty);
            }

            Item item = items.FirstOrDefault(i => i.Name == name);

            if (item==null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.NotSuchItem, name));
            }

            items.Remove(item);

            return item;
        }

    }
}
