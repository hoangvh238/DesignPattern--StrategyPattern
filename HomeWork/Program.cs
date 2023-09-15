using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    static void Main(string[] args)
    {
        Product card1 = new Product("Card garena 500k", 500);
        Product card2 = new Product("Card vina 200k", 200);

        card1.SetDiscountStrategy(new VoucherDiscountStrategy("GARENA50%"));
        card2.SetDiscountStrategy(new PercentageDiscountStrategy(50));

        card1.Display();
        card2.Display();
    }
}