using BethanysPieShop.InventoryManagement.Domain.General;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public class BulkProduct : Product
    {
        public BulkProduct(int id, string name, string? description, Price price, int maxAmountInStock) : base(id, name, description, price, UnitType.PerKg, maxAmountInStock)
        {
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }
    }
}
