using System;
using pricing.Core;
using pricing.Core.Exception;

namespace pricing.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var myOrder = new OrderBuilder(args[0], args[1])
                    .WithBeverage(args[2])
                    .AndBeverageSize(args[3])
                    .WithDessert(args[4])
                    .AndDessertSize(args[5])
                    .WithCoffee(args[6])
                    .Build();

                Console.WriteLine($"Prix à payer : {myOrder.Price} euros");
            }
            catch (OrderException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
