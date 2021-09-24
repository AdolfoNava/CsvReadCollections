using System.IO;
using System.Reflection;

namespace CsvReadCollections
{
    public class CSVManipulator
    {
        public string[] file1content, file2content;
        public string path;
        public CSVManipulator()
        {
            //As my build is through debug for testing path will lead to a dead end which is why the full address of the files
            //is $"{path}\\..\\..\\..\\csvfiles\\values1.csv" because it can be very flexible
            this.path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        }
        public void Readfile1()
        {
            //This locates the exact location of the csvfiles folder and get the individual file for the analysis as well as ALL of its contents
            file1content = System.IO.File.ReadAllLines($"{path}\\..\\..\\..\\csvfiles\\values1.csv");
        }
        public void Readfile2()
        {

            file2content = System.IO.File.ReadAllLines($"{path}\\..\\..\\..\\csvfiles\\values2.csv");
        }
        public void MakeCSV(decimal total,decimal average)
        {                
            //This will make sure that old file doesn't get stacked information from previous builds and/or different csv content
            File.Delete($"{path}\\..\\..\\..\\csvfiles\\Created.csv");
            using (StreamWriter sw = File.AppendText($"{path}\\..\\..\\..\\csvfiles\\Created.csv"))
            {

                sw.WriteLine(@$"Sum,Average
${total},${average}");
            }
        }
    }        
}
