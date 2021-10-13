using System;

namespace GruppUppgiftMyCellar
/// MADE BY:
/// LOUISE LITTECKE
/// HECTOR WIKLUND
/// MOHAMED EL YAHIAOUI
/// ADRIAN BJÖRKRYD
{
    public enum GrapeVariants
    {
        CabernetSauvignon, PinotNoir, Corvina, Shiraz, Merlot, Chablis,
        Riesling, Tempranillo
    }
    public enum GrapeRegions
    {
        Bordeaux, Burgundy, Veneto, Piedmonte, RiberaDelDuero,
        NapaValley, Puglia, Pfalz
    }
    public struct Wine
    {
        public int? Year;                   // null = undefined
        public string Name;
        public GrapeVariants Grape;
        public GrapeRegions Region;

        /// <summary>
        /// Creates a string representing the content of the Wine struct
        /// </summary>
        /// <returns>string that can be printed out using Console.WriteLine</returns>
        public string StringToPrint()
        {
            return $"Wine {Year} {Name} is made of {Grape} from {Region}";
        }
    }
    class Program
    {
        private static readonly int maxNrOfBottles = 4;

        static void Main(string[] args)
        {

            Wine[] myCellar = new Wine[maxNrOfBottles];

            Console.WriteLine($"My cellar can have maximum {maxNrOfBottles} bottles.");

            Wine wine1 = new Wine { Year = 2000, Name = "Chateau Lafite Rothschild", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.Bordeaux };
            bool bOK = InsertWine(myCellar, wine1);

            Wine wine2 = new Wine { Year = 2010, Name = "Domaine de la Romanee-Conti", Grape = GrapeVariants.PinotNoir, Region = GrapeRegions.Burgundy };
            bOK = InsertWine(myCellar, wine2);

            Wine wine3 = new Wine { Year = 2005, Name = "Giuseppe Quintarelli Amarone", Grape = GrapeVariants.Corvina, Region = GrapeRegions.Veneto };
            bOK = InsertWine(myCellar, wine3);

            Wine wine4 = new Wine { Year = 2008, Name = "Sierra Cantabria", Grape = GrapeVariants.Tempranillo, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine4);

            Wine wine5 = new Wine { Year = 1992, Name = "Screaming Eagle", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine5);

            // invoke custom methods
            PrintWines(myCellar);

            SearchWine(myCellar);

            DeleteWine(myCellar);
            // initiates a string variable that stores input from user 

        }

        /// <summary>
        /// Inserts a wine into myCellar at first available position
        /// </summary>
        /// <param name="myCellar"></param>
        /// <param name="wine"></param>
        /// <returns>true - if insertion was possible, otherwise false</returns>
        private static bool InsertWine(Wine[] myCellar, Wine wine)
        {
            // try/catch block for catching errors
            try
            {
                for (int i = 0; i < myCellar.Length; i++)
                {
                    // check if wine name is null...
                    if (myCellar[i].Name == null)
                    {
                        // if index is null assign wine to index 
                        myCellar[i] = wine;
                        // Print out that wine was added using StringToPrint method
                        Console.WriteLine($"Added to my cellar: {wine.StringToPrint()}");
                        // method returns true
                        return true;
                    }
                }
                // if index is not null, write message explaining the cellar is full
                Console.WriteLine($"Could NOT add to my cellar: {wine.StringToPrint()}");
                // method returns false
                return false;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
            return false;
        }

        /// <summary>
        /// Print out all the wines in myCellar
        /// </summary>
        /// <param name="myCellar"></param>
        private static void PrintWines(Wine[] myCellar)
        {
            try
            {
                // Message telling the user how many bottles the cellar has
                Console.WriteLine($"\nMy cellar has {NrOfBottles(myCellar)} bottles");
                // foreach winebottle in my cellar...
                foreach (Wine wineBottle in myCellar)
                {
                    // if there is a bottle with year that is NOT null...
                    if (wineBottle.Year != null)
                        // print it with string interpolation using the StringToPrint method
                        Console.WriteLine($"{wineBottle.StringToPrint()}");
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
        }

        /// <summary>
        /// Counts the number of bottles in myCellar. That is all items
        /// where Year is not null 
        /// </summary>
        /// <param name="myCellar"></param>
        /// <returns>Number of bottles in myCellar</returns>
        private static int NrOfBottles(Wine[] myCellar)
        {
            //Creat a intiger that will hold the value of how many bottles there is.
            int count = 0;

            //For each item in the Wine[] array...
            foreach (var item in myCellar)
            {
                //If the yhear in the index is not null...
                if (item.Year != null)
                {
                    //Add + 1 to the counter.
                    count++;
                }
            }
            //Return the value of the counter
            return count;
        }

        //Search for a wine.
        //bool method using Wine[] array and string input from user
        private static bool SearchWine(Wine[] myCellar)
        {
            //Search for wine
            Console.WriteLine("\nSearch for a wine name: ");
            // initiates a string variable that store input from user
            string inputSearch = Console.ReadLine();

            try
            {
                // as long as i is smaller than myCellar...
                for (int i = 0; i < myCellar.Length; i++)
                {
                    // search for any wine containing user input string using .Contains-method
                    // using ToLower method to convert input string to small letters to allow all user input
                    // if user input is the same as the name of the wine...
                    if (myCellar[i].Name.ToLower().Contains(inputSearch.ToLower()))
                    {
                        // message using string interpolation and method StringToPrint
                        Console.WriteLine($"The {myCellar[i].StringToPrint()}, was found!");
                        // return value true since wine was found 
                        return true;
                    }
                }
                // message if wine was not found
                Console.WriteLine($"The Wine could NOT be found!");
                // return false if wine was not found
                return false;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
            return false;
        }

        // Delete a wine
        // method that returns a bool with parameters Wine [] array and string user input
        private static bool DeleteWine(Wine[] myCellar)
        {
            try
            {
                Console.WriteLine("\nInput a wine name that you want to delete: ");
                string inputDelete = Console.ReadLine();
                // as long as i is smaller than myCellar...
                for (int i = 0; i < myCellar.Length; i++)
                {
                    // if user input is the same as the name of a wine in the cellar...
                    if (myCellar[i].Name.ToLower().Contains(inputDelete.ToLower()))
                    {
                        // write message using to StringToPrint method
                        Console.WriteLine($"{myCellar[i].StringToPrint()}, was deleted!");

                        // the wine equal to user input is deleted (is set to default = null)
                        myCellar[i] = new Wine();

                        // using PrintWines method to print updated wine cellar without deleted wine
                        PrintWines(myCellar);

                        // since input could be found, the method returns true
                        return true;
                    }
                }
                // message if the wine could not be deleted
                Console.WriteLine($"The wine was NOT deleted!\n");
                // using PrintWine method to show that all wines are still there
                PrintWines(myCellar);
                // since nothing was deleted, method returns false
                return false;
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
            return false;
        }
    }
}

