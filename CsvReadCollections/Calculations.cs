using System;

namespace CsvReadCollections
{
    public class Calculations
    {
        //I decided to make the math functions that I'll be using in the same main class for organization sake.
        //All values will be from the read files function that the CSVManipulator class handles
        public decimal Total,Average;
        public int countofvalues;

        public Calculations()
        {
            this.Total = 0;
            this.Average = 0;
        }
        public void AddingValuesTogether(decimal value)
        {
            //These values will be accumulative as for every value takes part in the system
            Average += value;
            Total += value;
            //The countofvalues keeps track of how many values that the app has taken in for the last AverageFinisherfunction
            countofvalues++;
        }
        public decimal AverageFinisher(decimal average)
        {
            //This function makes sure that the average is found and doesn't manipulate total in anyway
            Average = average / Convert.ToDecimal(countofvalues);
            
            //this round to the nearest 2 decimal point as that is USD standard of currency.
           return Math.Round(Average,2);
        }
    }
}
