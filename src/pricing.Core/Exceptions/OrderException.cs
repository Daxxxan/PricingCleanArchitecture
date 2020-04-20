using System;

namespace pricing.Core.Exception
{
    public class OrderException : System.Exception
    {
        public OrderException()
            : base(string.Format("You have to specify the name and the type of your order"))
        {

        }
    }
}