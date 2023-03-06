using Bookstore.DataLayer;
using Bookstore.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BusinessLayer
{
    public class ItemBusiness
    {
        private readonly ItemRepository itemRepository;
        public ItemBusiness()
        {
            this.itemRepository = new ItemRepository(); //inicijalizacija objekta
        }
        public List<Item> GetAllItems()
        {
            return this.itemRepository.GetAllItems();
        }
        public bool InsertItem(Item i)
        {
            if (this.itemRepository.InsertItem(i) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateItem(Item i)
        {
            if (this.itemRepository.UpdateItem(i) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteItem(int id)
        {
            if (this.itemRepository.DeleteItem(id) > 0)
            {
                return true;
            }
            return false;
        }
        
        public Item GetItemById(int id)
        {
            return this.itemRepository.GetAllItems().FirstOrDefault(i => i.id == id);
        }

        public List<Item> SearchItems(string s)
        {
            return this.itemRepository.SearchItems(s);
        }
    }
}
