using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestShopApp.Models
{
    public class Cart
    {
        private List<CartLine> CartItemsList = new List<CartLine>();
        public void AddToCart(int quantity, Item item)
        {
            var value = CartItemsList.Where(i => i.Product.id == item.id).FirstOrDefault();
            if(value == null)
            {
                CartItemsList.Add(new CartLine
                {
                    Product = item,
                    Quantity = quantity
                });
            }
            else
            {
                value.Quantity += quantity;
            }
        }
        public class CartLine
        {
            public Item Product { get; set; }
            public int Quantity { get; set; }
        }
        public IEnumerable<CartLine> Lines
        {
            get { return CartItemsList; }
        }
        public void Clear()
        {
            CartItemsList.Clear();
        }
        public decimal ComputeTotalValue()
        {
            return Convert.ToDecimal(CartItemsList.Sum(e => e.Product.price * e.Quantity));
        }
        public void RemoveLine(Item item)
        {
            CartItemsList.RemoveAll(l => l.Product.id == item.id);
        }
    }
}