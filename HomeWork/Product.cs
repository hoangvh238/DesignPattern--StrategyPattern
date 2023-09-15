using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Product
    {
        public string ProductName { get; set; }
        public int Price { get; set; }

        private IDiscountStrategy _discountStrategy;
        
        public Product (string productName, int price)
        {
            ProductName = productName;
            Price = price + this.GetImportTax(price);
        }

        public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public int FinalPrice(int price)
        {
            return  _discountStrategy?.ApplyDiscount(price) ?? new NoDiscountStrategy().ApplyDiscount(price);
        }

        private int GetImportTax(int price)
        {
            return (int)Math.Ceiling(price * 10.0 / 100); 
        }

        public void Display()
        {
            Console.WriteLine($"Product name : {ProductName} , Final Price : {this.FinalPrice(Price)}");
        }

    }
}
