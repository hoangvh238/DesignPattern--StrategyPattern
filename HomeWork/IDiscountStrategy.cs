using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal interface IDiscountStrategy
    {
       public int ApplyDiscount(int price);
    }

    public class NoDiscountStrategy : IDiscountStrategy 
    {
        public int ApplyDiscount(int price)
        {
            return price;
        }
    }

    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly int _percent;

        public PercentageDiscountStrategy(int percent)
        {
            _percent = percent;
        }
        public int ApplyDiscount(int price)
        {
            return (int) Math.Ceiling(price - (price *1.0* _percent) / 100);
        }
    }

    public class VoucherDiscountStrategy : IDiscountStrategy
    {
        private readonly string _voucher;

        public VoucherDiscountStrategy(string voucher) { 
            _voucher = voucher;
        }
        
        private int UseVoucher(int price)
        {
            switch (_voucher)
            {
                case "GARENA50K": 

                    return price - 50;

                case "GARENA50%":

                   return new PercentageDiscountStrategy(50).ApplyDiscount(price);
            }
            return new NoDiscountStrategy().ApplyDiscount(price);
        }
        public int ApplyDiscount(int price) {
           return UseVoucher(price);
        }
    }
}
