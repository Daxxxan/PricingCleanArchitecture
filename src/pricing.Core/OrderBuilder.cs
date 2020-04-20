using System;
using pricing.Core.Enums;
using pricing.Core.Exception;

namespace pricing.Core
{
    public class OrderBuilder
    {
        private string type;
        private string name;
        private string beverage;
        private string size;
        private string dessert;
        private string dsize;
        private string coffee;
        private int price = 0;

        public OrderBuilder(string type, string name)
        {
            if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(name))
            {
                price += AddPriceAccordingToTheType(type);
                this.type = type;
                this.name = name;
            }
            else
            {
                throw new OrderException();
            }
        }

        private int AddPriceAccordingToTheType(string orderType)
        {
            foreach (var oType in Enum.GetValues(typeof(OrderType)))
            {
                if(string.Equals(oType.ToString(), orderType, StringComparison.OrdinalIgnoreCase))
                {
                    return (int) oType;
                }
            }

            return 0;
        }

        public OrderBuilder WithBeverage(string beverage)
        {
            this.beverage = beverage;
            return this;
        }

        public OrderBuilder AndBeverageSize(string size)
        {
            price += AddPriceAccordingToTheBeverageSize(size);
            this.size = size;
            return this;
        }

        private int AddPriceAccordingToTheBeverageSize(string size)
        {
            foreach (var beverageSize in Enum.GetValues(typeof(BeverageSize)))
            {
                if(string.Equals(beverageSize.ToString(), size, StringComparison.OrdinalIgnoreCase))
                {
                    return (int) beverageSize;
                }
            }

            return 0;
        }

        public OrderBuilder WithDessert(string dessert)
        {
            this.dessert = dessert;
            return this;
        }

        public OrderBuilder AndDessertSize(string dsize)
        {
            AddPriceAccordingToTheDsize(dsize);
            this.dsize = dsize;
            return this;
        }

        private void AddPriceAccordingToTheDsize(string dessertSize)
        {
            Enum orderType = GetOrderType();

            if (string.Equals(BeverageSize.MOYEN.ToString(), size, StringComparison.OrdinalIgnoreCase))
            {
                if (string.Equals(DessertType.NORMAL.ToString(), dessertSize, StringComparison.OrdinalIgnoreCase))
                {
                    if (Equals(orderType, OrderType.ASSIETTE))
                    {
                        price = (int) Meal.ASSIETTE_STANDARD_MEAL;   
                        Console.Write("Prix Formule Standard appliquée ");
                    }
                    else
                    {
                        price = (int) Meal.SANDWICH_STANDARD_MEAL;
                        Console.Write("Prix Formule Standard appliquée ");
                    }
                }
                else
                {
                    price += (int) DessertType.SPECIAL;
                }  
            }
            else if(string.Equals(BeverageSize.GRAND.ToString(), size, StringComparison.OrdinalIgnoreCase))
            {
                    if (string.Equals(DessertType.SPECIAL.ToString(), dessertSize, StringComparison.OrdinalIgnoreCase))
                    {
                        if (Equals(orderType, OrderType.ASSIETTE))
                        {
                            price = (int) Meal.ASSIETTE_MAX_MEAL;
                            Console.Write("Prix Formule Max appliquée ");
                        }
                        else
                        {
                            price = (int) Meal.SANDWICH_MAX_MEAL;
                            Console.Write("Prix Formule Max appliquée ");
                        }
                    }
                    else
                    {
                        price += (int) DessertType.NORMAL;
                    }
            }
            else
            {
                if (string.Equals(DessertType.NORMAL.ToString(), dessertSize, StringComparison.OrdinalIgnoreCase))
                {
                    price += (int) DessertType.NORMAL;
                }
                else
                {
                    price += (int) DessertType.SPECIAL;
                }
            }
        }

        private Enum GetOrderType()
        {
            if (string.Equals(OrderType.ASSIETTE.ToString(), type, StringComparison.OrdinalIgnoreCase))
            {
                return OrderType.ASSIETTE;
            }

            return OrderType.SANDWICH;
        }

        public OrderBuilder WithCoffee(string coffee)
        {
            FreeCoffee(coffee);
            this.coffee = coffee;
            return this;
        }

        private void FreeCoffee(string coffee)
        {
            if (string.Equals(OrderType.ASSIETTE.ToString(), type, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(BeverageSize.MOYEN.ToString(), size, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(DessertType.NORMAL.ToString(), dsize, StringComparison.OrdinalIgnoreCase) &&
                coffee == "yes")
            {
                Console.Write("avec café offert! ");   
            }
            else
            {
                price += 1;
            }
        }

        public Order Build()
        {
            var order = new Order();
            order.Type = type;
            order.Name = name;
            order.Beverage = beverage;
            order.Size = size;
            order.Dessert = dessert;
            order.Dsize = dsize;
            order.Coffee = coffee;
            order.Price = price;

            return order;
        }
    }
}