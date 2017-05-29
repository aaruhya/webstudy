using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1mvc.Models
{
    public class CartItem
    {
        public Product product { get; set; }

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
        }

        public CartItem(Product prd)
        {
            product = prd;
            _quantity = 1;
        }

        public CartItem(Product prd,int quantity)
        {
            product = prd;
            _quantity = quantity;
        }

        public void RaiseQuantity()
        {
            _quantity++;
        }

        public void LowerQuantity()
        {
            if (_quantity > 0)
            {
                _quantity--;
            }
        }
    }

    public class Cart
    {
        public string CartID { get; set; }
        public List<CartItem> Contents;
        public double Amount { get; set; }

        public Cart()
        {
            Contents = new List<CartItem>();
        }

        public void AddProduct(Product prd)
        {
            int index = -1;
            int rindex = -1;
            double amount = 0;
            foreach (CartItem item in Contents)
            {
                index++;
                if (item.product.ID == prd.ID)
                {
                    rindex = index;
                    amount = item.product.Price * item.Quantity;
                }
            }

            if (rindex >= 0)
            {
                Contents[rindex].RaiseQuantity();
            }
            else
            {
                Contents.Add(new CartItem(prd));
            }
            Amount += prd.Price;
        }

        public void RemoveProduct(string id)
        {
            int index = -1;
            int rindex = -1;
            double amount = 0;
            foreach(CartItem item in Contents)
            {
                index++;
                if(item.product.ID == id)
                {
                    rindex = index;
                    amount = item.product.Price * item.Quantity;
                }
            }

            if (rindex >= 0)
            {
                Contents.RemoveAt(rindex);
                Amount -= amount;
            }
            
        }
    }
}