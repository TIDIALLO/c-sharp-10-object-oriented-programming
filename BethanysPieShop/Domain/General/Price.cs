using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.General
{
    public class Price
    {
        private int v;
        private Currency euro;

        public Price()
        {
        }

        public Price(int v, Currency euro)
        {
            this.v = v;
            this.euro = euro;
        }

        public double ItemPrice { get; set; }
        public Currency Currency { get; set; }

        public override string ToString()
        {
            return $"{ItemPrice} {Currency}";
        }
    }
}
