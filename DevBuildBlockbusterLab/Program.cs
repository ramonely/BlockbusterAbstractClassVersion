using System;

namespace DevBuildBlockbusterLab
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BlockBuster blockBuster = new BlockBuster();

            Console.WriteLine("Welcome to GC Blockbuster!");
            blockBuster.Checkout();
            //What way to watch another movie after I finshed another movie
            //blockBuster.PlayAllMovies(); comment this out becuase after I finsh watching one movie it plays all movies
        }
    }
}