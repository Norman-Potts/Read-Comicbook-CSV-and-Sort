
/** 
 * Read-Comicbook-CSV-and-Sort
 * 
 * This C# program was created by Norman Potts.
 * Date: April 2017
 * 
 *     The goal of this lab is to read the data in a csv file, give the user six different options of how to 
 *     sort, then display a neat orderly table following that sort. The contents of the csv file is information 
 *     about comic books. This program makes use of a comic book class called... 'ComicBook'. This class 
 *     stores information about a single comic book. The class follows a UML diagram that is specified in the 
 *     instructions for the course.
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    // compile with: /doc:DocLab1.xml 

    
    /// <summary> 
    /// This Program is a C# class for Lab 1 of Advanced Programming in .Net
    /// </summary>
    class Program
    {        
    
        
        /// <summary> 
        ///  The main method for this program. Parameter Args not used.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ComicBook[] books = Read();                               
            if ( books != null)
            {                
                MenuInputManagement(books);                                          
            }                      
        }




        /// <summary>
        /// Method Read builds an array of comic books, from the comics.txt
        /// </summary>
        /// <returns>The comic book array.</returns>
        public static ComicBook[] Read()
        {
            string[] fields;
            string line, title, publisher, date;
            Boolean toobig, toosmall;            
            int issue;            
            decimal bookValue, marketValue;
            ComicBook[] books = null;   
            try
            {                
                FileStream file = new FileStream(@"comics.txt", FileMode.Open, FileAccess.Read);        
                StreamReader data = new StreamReader(file);                                             
                int numberOfLinesintxt = File.ReadLines(@"comics.txt").Count();
                toobig = (numberOfLinesintxt < 100) ? false : true; /// If number of lines less than 100,  toobig is false. 
                toosmall = (numberOfLinesintxt > 0 ) ? false : true; /// If number of lines greater than zero,  toosmall is false.                 
                if (toobig == false)
                {
                    if (toosmall == false)
                    {
                        books = new ComicBook[numberOfLinesintxt];
                        int countofLines = 0;
                        while ((line = data.ReadLine()) != null)
                        {
                            fields = line.Split(',');
                            char[] braces = { ' ', '(', ')' };
                            title = fields[6].Trim(braces);
                            publisher = fields[0];
                            issue = Convert.ToInt32(fields[2]);
                            date = fields[3];
                            bookValue = Convert.ToDecimal(fields[4]);
                            marketValue = Convert.ToDecimal(fields[5]);
                            books[countofLines] = new ComicBook(publisher, title, issue, date, bookValue, marketValue);
                            countofLines++;
                        }                        
                        data.Close();
                        file.Close();                     
                    }
                    else
                    {
                        Console.WriteLine(" Not enough lines in comic.txt.");
                        data.Close();
                        file.Close();                        
                    }
                }
                else
                {
                    Console.WriteLine(" Too many Lines in comic.txt.");            
                    data.Close();
                    file.Close();
                    
                }
            }
            catch (IOException io)
            {
                Console.WriteLine("An error occured while the commic book was being read.");
                String Error = io.ToString();
                Console.WriteLine(Error);
                string input = Console.ReadLine();
            }
            return books;
        }






        /// <summary>
        /// Displays the comic book array as a table.
        /// </summary>
        public static void DisplayTable(ComicBook[] books)
        {
            Console.Clear();
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("                                      Comic Book Table                                  ");
            Console.WriteLine("  -------------------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-28}| {1,-11} | {2,-10} | {3,0} | {4,-14} | {5,0} |", "  | Title", "Publisher", "  Date", "Issue", "Marketvalue", "Bookvalue"));
            Console.WriteLine("  |{0,-25}|{1,-13}|{2,-12}|{3,-7}|{4,-16}|{5,-11}|", "  ----- ", " ---------", "   ----", " -----", " -----------", " ---------");
            foreach (ComicBook book in books)
            {
                book.DisplayComicBook();
            }
            Console.WriteLine("  -------------------------------------------------------------------------------------------");
            Console.WriteLine("  ");
        }




        /// <summary>
        /// Manages the input for the user inteface threw the console.        
        /// </summary>
        /// <returns> The choice of sort as a numeric value. </returns>
        public static void MenuInputManagement(ComicBook[] books)
        {                       
            String input; int inputinteger = 0;                                                    
            do
            {                
                Console.WriteLine("");
                Console.WriteLine("Pick one of these seven options ");
                Console.WriteLine("     1 Sort by Publisher Name (ascending)");
                Console.WriteLine("     2 Sort by Comic Title (ascending)");
                Console.WriteLine("     3 Sort by issue Number (ascending)");
                Console.WriteLine("     4 Sort by Cover date (ascending)");
                Console.WriteLine("     5 Sort by Cover Value (descending)");
                Console.WriteLine("     6 Sort by Market Value (descending)");
                Console.WriteLine("     7 Exit ");
                Console.Write(":");
                input = Console.ReadLine();                                
                try
                {                    
                    inputinteger = Convert.ToInt32(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Input was not a number. Please enter a number between 1 and 7.");                    
                };

                if (inputinteger > 0 && inputinteger <= 7)
                {
                    if (inputinteger == 7)
                    {
                        Console.WriteLine("Closing application.");
                    }
                    else
                    {
                        books = mySelectionSort(books, inputinteger);
                        DisplayTable(books);
                    }                                                                                                 
                }
                else
                {            
                    Console.WriteLine("Input has to be between 1 to 7. try again. \n");                        
                }
                
            } while ( inputinteger != 7);                         
        }




        /// <summary>
        /// Performs a selection sort on the ComicBooks Array.
        /// </summary>
        /// <param name="books">The comic books being sorted.</param>
        /// <param name="inputinteger"> The specified sort type. </param>
        /// <returns></returns>
        public static ComicBook[] mySelectionSort(ComicBook[] books, int inputinteger)
        {
            int startScan; int index; int minIndex; 
            ComicBook minValue;
            int SelectCompare = 0;
            for (startScan = 0; startScan < (books.Length - 1); startScan++)
            {
                minIndex = startScan;
                minValue = books[startScan];
                for (index = startScan + 1; index < books.Length; index++)
                {
                    SelectCompare++;
                    switch (inputinteger)
                    {
                        case 1:
                            if (books[index].GetPublisher().CompareTo(minValue.GetPublisher()) < 0)
                            {
                                minValue = books[index];
                                minIndex = index;
                            }
                            break;
                        case 2:
                            if (books[index].GetTitle().CompareTo(minValue.GetTitle()) < 0)
                            {
                                minValue = books[index];
                                minIndex = index;
                            }
                            break;
                        case 3:
                            if (books[index].GetIssue() < minValue.GetIssue())
                            {
                                minValue = books[index];
                                minIndex = index;
                            }
                            break;
                        case 4:
                            if (books[index].GetDate().CompareTo(minValue.GetDate()) < 0 )
                            {
                                minValue = books[index];
                                minIndex = index;
                            }
                            break;
                        case 5:
                            if (books[index].GetBookValue() > minValue.GetBookValue())
                            {
                                minValue = books[index];
                                minIndex = index;
                            }
                            break;
                        case 6:
                            if (books[index].GetMarketValue() > minValue.GetMarketValue())
                            {
                                minValue = books[index];
                                minIndex = index;
                            }
                            break;
                    }
                }
                books[minIndex] = books[startScan];
                books[startScan] = minValue;
            }
            return books;
        }



        /// <summary>
        /// Returns the numberic value of a month. Used in method getIssuearr.
        /// </summary>
        /// <param name="month">First three letters of a month starting with a capital.</param>
        /// <returns>The numeric value of a month for use in getIssuearr.</returns>
        public static int getmonthval(string month)
        {
            int val_month = 0;
            decimal v;
            switch (month)
            {
                case "Jan":
                    v = (1 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Feb":
                    v = (2 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Mar":
                    v = (3 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Apr":
                    v = (4 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "May":
                    v = (5 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Jun":
                    v = (6 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Jul":
                    v = (7 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Aug":
                    v = (8 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Sep":
                    v = (9 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Oct":
                    v = (10 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Nov":
                    v = (11 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                case "Dec":
                    v = (12 / 12) * 1000;
                    val_month = (int)Math.Truncate(v);
                    break;
                default:
                    Console.WriteLine("Error occured while trying to reconise date string.");
                    break;
            }
            return val_month;
        }


    }

}


