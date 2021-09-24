using System;



namespace CsvReadCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculations Calculations = new Calculations();
            CSVManipulator manipulator = new CSVManipulator();
            manipulator.Readfile1();
            Console.WriteLine("File 1: values1.csv");
            //This nested for loop goes through horizontal then vertical lines rinse and repeat for the entire file
            for(int i =0; i < manipulator.file1content.Length; i++)
            {
                //rowdata takes all elements of the csv and the split makes it so that its not all one line per row
                string[] rowdata = manipulator.file1content[i].Split(',');
                for(int j = 0; j < rowdata.Length; j++)
                {
                    try {
                        //this is why the try catch is here to avoid any exceptions thats not a number value
                        decimal value=Convert.ToDecimal(rowdata[j]);     
                        //Verifies what did the program read
                        Console.WriteLine(rowdata[j]);
                        //Goes into the overall collection of the file's number values
                        Calculations.AddingValuesTogether(value);
                    }
                    catch
                    {                    
                        //The catch is for any non number value.
                        Console.WriteLine($"Failed to convert section for value: {rowdata[j]}");
                    }                    
                }
                
            }


            manipulator.Readfile2();
            Console.WriteLine("File 2: values2.csv");
            for (int i = 0; i < manipulator.file2content.Length; i++)
            {
                string[] rowdata = manipulator.file2content[i].Split(',');
                for (int j = 0; j < rowdata.Length; j++)
                {
                    try
                    {

                        decimal value = Convert.ToDecimal(rowdata[j]);                        
                        Console.WriteLine(rowdata[j]);
                        Calculations.AddingValuesTogether(value);
                    }
                    catch
                    {
                        Console.WriteLine($"Failed to convert section for value: {rowdata[j]}");
                    }
                }
            }
            Calculations.Average=Calculations.AverageFinisher(Calculations.Average);
            //These are command line checks that everything works as intended
            Console.WriteLine($"Average: {Calculations.Average}");
            Console.WriteLine($"Grand Total: {Calculations.Total}");
            Console.WriteLine($"Total number of values processed: { Calculations.countofvalues}");
            manipulator.MakeCSV(Calculations.Total, Calculations.Average);
        }
    }
}
