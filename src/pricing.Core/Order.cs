using System;
using pricing.Core.Exception;

namespace pricing.Core
{
    public class Order
    {
        private string type;
        private string name;
        private string beverage;
        private string size;
        private string dessert;
        private string dsize;
        private string coffee;
        private int price;
        
        public Order(){}
        public Order(string type, string name, string beverage, string size, string dessert, string dsize,
            string coffee)
        {
            this.type = type;
            this.name = name;
            this.beverage = beverage;
            this.size = size;
            this.dessert = dessert;
            this.dsize = dsize;
            this.coffee = coffee;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Beverage
        {
            get => beverage;
            set => beverage = value;
        }

        public string Size
        {
            get => size;
            set => size = value;
        }

        public string Dessert
        {
            get => dessert;
            set => dessert = value;
        }

        public string Dsize
        {
            get => dsize;
            set => dsize = value;
        }

        public string Coffee
        {
            get => coffee;
            set => coffee = value;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }
    }
}