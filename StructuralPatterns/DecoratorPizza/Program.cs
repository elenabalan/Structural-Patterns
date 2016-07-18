using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPizza
{
    public abstract class BasePizza
    {
        public double MyPrice { get; set; }
        public virtual double GetPrice() => MyPrice;

    }

    public abstract class ToppingsDecorator : BasePizza
    {
        protected BasePizza pizza;

        public ToppingsDecorator(BasePizza pizzaToDecorate)
        {
            pizza = pizzaToDecorate;
        }

        public override double GetPrice()
        {
            return pizza.GetPrice() + MyPrice;
        }
    }

    public class BazaSubtire : BasePizza 
    {
        public BazaSubtire ()
        {
            MyPrice = 25;
        }
    }
    public class BazaTraditionala : BasePizza
    {
        public BazaTraditionala()
        {
            MyPrice = 28;
        }
    }

    public class ExtraCheeseTopping : ToppingsDecorator
    {
        public ExtraCheeseTopping(BasePizza pizzaToDecorate) : base(pizzaToDecorate)
        {
           MyPrice = 4;
        }
    }
    public class MushroomTopping : ToppingsDecorator
    {
        public MushroomTopping(BasePizza pizzaToDecorate) : base(pizzaToDecorate)
        {
            MyPrice = 3;
        }
    }
    public class PickledOnionTopping : ToppingsDecorator
    {
        public PickledOnionTopping(BasePizza pizzaToDecorate) : base(pizzaToDecorate)
        {
            MyPrice = 1;
        }
    }
    public class ExtraMeatTopping : ToppingsDecorator
    {
        public ExtraMeatTopping(BasePizza pizzaToDecorate) : base(pizzaToDecorate)
        {
            MyPrice = 9;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BazaTraditionala pizzaTraditionala = new BazaTraditionala();

            ExtraCheeseTopping moreCheese = new ExtraCheeseTopping(pizzaTraditionala);
            ExtraCheeseTopping more2Cheese = new ExtraCheeseTopping(moreCheese);
            ExtraMeatTopping meatTopping = new ExtraMeatTopping(more2Cheese);
            ExtraMeatTopping moreMeatTopping = new ExtraMeatTopping(meatTopping);
            Console.WriteLine($"Pizza traditionala cu cheese si meat dublu. Costul este {moreMeatTopping.GetPrice()}");

            Console.ReadKey();
        }
    }
}
