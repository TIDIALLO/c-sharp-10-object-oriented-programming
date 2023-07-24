using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BethanysPieShop.InventoryManagement
{
    public class Product
    {
        private int id ;
        private string name = string.Empty;
        private string? description;

        private int maxItemsInStock = 0;
    
        private UnitType unitType;
        private int amountInStock = 0;
        private bool isBelowStockTreshold = false;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value.Length > 50 ? value[..50] : value;
            }
        }

        public string? Description
        {
            get { return description; }
            set
            {
                if (value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Length > 250 ? value[..250] : value;

                }
            }
        }
        public void UseProduct(int items)
        {
            if (items <= amountInStock)
            {
                //use the items
                amountInStock -= items;

                UpdateLowStock();

                Log($"Amount in stock updated. Now {amountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {amountInStock} available but {items} requested.");
            }
        }

        private void UpdateLowStock()
        {
            if (amountInStock < 10)//for now a fixed value
            {
                isBelowStockTreshold = true;
            }
        }

        private void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }

        public void IncreaseStock()
        {
            amountInStock++;
        }

        public void IncreaseStock(int amount)
        {
            int newStock = amountInStock + amount;

            if (newStock <= maxItemsInStock)
            {
                amountInStock += amount;
            }
            else
            {
                amountInStock = maxItemsInStock;//we only store the possible items, overstock isn't stored
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - amountInStock} item(s) ordere that couldn't be stored.");
            }

            if (amountInStock > 10)
            {
                isBelowStockTreshold = false;
            }
        }

        private void DecreaseStock(int items, string reason)
        {
            if (items <= amountInStock)
            {
                //decrease the stock with the specified number items
                amountInStock -= items;
            }
            else
            {
                amountInStock = 0;
            }

            UpdateLowStock();

            Log(reason);
        }

        public string DisplayDetailsShort()
        {
            return $"{id}. {name} \n{amountInStock} items in stock";
        }

        public string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{id} {name} \n{description}\n{amountInStock} item(s) in stock");

            if (isBelowStockTreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();

            //return DisplayDetailsFull("");
        }


    }
}
