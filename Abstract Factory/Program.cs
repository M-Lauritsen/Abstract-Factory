using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    class Program
    {


        //To demo this, let's make some abstract classes representing the generic kinds of recipes
        //(these are our AbstractProduct participants)
        abstract class Sandwich { }
        abstract class Dessert { }

        //Next, we need an abstract class that will return a Sandwich and a Dessert(this is the
        //AbstractFactory participant)
        abstract class RecipeFactory
        {
            public abstract Sandwich CreateSandwich();
            public abstract Dessert CreateDessert();
        }

        //Now we can start implementing the actual objects.First let's consider the adult menu (these
        //next classes are ConcreteProduct objects)
        class BLT : Sandwich { }
        class CremeBrulee : Dessert { }

        //We also need a ConcreteFactory which implements the AbstractFactory and returns the
        //adult recipes
        class AdultCuisineFactory : RecipeFactory
        {
            public override Sandwich CreateSandwich()
            {
                return new BLT();
            }

            public override Dessert CreateDessert()
            {
                return new CremeBrulee();
            }
        }

        //Now that we've got the Adult recipes defined, let's define the Child recipes.Here are the
        //ConcreteProduct classes and ConcreteFactory for said recipes
        class GrilledCheese : Sandwich { }
        class IceCreamSundae : Dessert { }

        class KidCuisineFactory : RecipeFactory
        {
            public override Sandwich CreateSandwich()
            {
                return new GrilledCheese();
            }
            public override Dessert CreateDessert()
            {
                return new IceCreamSundae();
            }
        }

        //How do we use all these classes we've just defined? We implement the Client participant!
        //Let's have our Client ask the user if they are an adult or a child, then display the
        //corresponding menu items
        static void Main(string[] args)
        {
            Console.WriteLine("Who are you? (A)dult or (C)hild?");
            char input = Console.ReadKey().KeyChar;
            RecipeFactory factory;
            switch (input)
            {
                case 'A':
                    factory = new AdultCuisineFactory();
                    break;
                case 'C':
                    factory = new KidCuisineFactory();
                    break;
                default:
                    throw new NotImplementedException();
            }
            var sandwich = factory.CreateSandwich();
            var dessert = factory.CreateDessert();

            Console.WriteLine("\nSandwich: " + sandwich.GetType().Name);
            Console.WriteLine("Dessert: " + dessert.GetType().Name);

            Console.ReadKey();
        }

    }
}
