// csharp/Cart.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce
{
    public class Cart
    {
        private List<CartItem> items;

        public Cart()
        {
            items = new List<CartItem>();
        }

        public void Add(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be positive");
            }

            if (!product.IsAvailable(quantity))
            {
                throw new ArgumentException("Insufficient stock for " + product.Name);
            }

            var existingItem = items.FirstOrDefault(item => item.Product.Equals(product));
            if (existingItem != null)
            {
                int newQuantity = existingItem.Quantity + quantity;
                if (!product.IsAvailable(newQuantity))
                {
                    throw new ArgumentException("Insufficient stock for " + product.Name);
                }
                existingItem.Quantity = newQuantity;
            }
            else
            {
                items.Add(new CartItem(product, quantity));
            }
        }

        public List<CartItem> GetItems()
        {
            return new List<CartItem>(items);
        }

        public bool IsEmpty()
        {
            return !items.Any();
        }

        public double GetSubtotal()
        {
            return items.Sum(item => item.GetTotalPrice());
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
