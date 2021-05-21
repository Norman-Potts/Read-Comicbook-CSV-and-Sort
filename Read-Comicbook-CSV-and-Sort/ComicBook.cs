using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Read_Comicbook_CSV_and_Sort
{

    /// <summary>
    ///     Class ComicBook stores the information for a given ComicBook.   
    ///     Class ComicBook is used in lab 1 of Advanced Programming in .NET. 
    /// 
    /// </summary>
    class ComicBook
    {
        private string publisher_;
        private string title_;
        private int issue_;
        private string date_;
        private decimal bookValue_;
        private decimal marketValue_;


        /// <summary>
        /// Stores a comicbook.
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="title"></param>
        /// <param name="issue"></param>
        /// <param name="date"></param>
        /// <param name="bookvalue"></param>
        /// <param name="marketValue"></param>
        public ComicBook(string publisher, string title, int issue, string date, decimal bookvalue, decimal marketValue)
        {
            SetPublisher( publisher );
            SetTitle( title );
            SetIssue( issue );
            SetDate( date );
            SetBookValue( bookvalue );
            SetMarketValue( marketValue );
        }

 
        /// <summary>
        ///  Gets the publisher.
        /// </summary>
        /// <returns></returns>
        public string GetPublisher()
        {
            return publisher_;
        }
           

        /// <summary>
        ///  Gets the title.
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return title_;
        }


        /// <summary>
        ///  Gets the issue.
        /// </summary>
        /// <returns></returns>
        public int GetIssue()
        {
            return issue_;
        }


        /// <summary>
        ///  Gets the date.
        /// </summary>
        /// <returns></returns>
        public string GetDate()
        {
            return date_;
        }


        /// <summary>
        ///  Gets the book value.
        /// </summary>
        /// <returns></returns>
        public decimal GetBookValue()
        {
            return bookValue_;
        }


        /// <summary>
        ///  Gets the market value.
        /// </summary>
        /// <returns></returns>
        public decimal GetMarketValue()
        {
            return marketValue_;
        }
            

        /// <summary>
        ///  Displays the comic book information.
        /// </summary>
        public void DisplayComicBook()
        {     
           Console.WriteLine("  | {0,-24}| {1,-12}| {2,-11}| {3,-6}|{4,15:C} |{5,10:C} |", GetTitle(), GetPublisher(), GetDate(), GetIssue(), GetMarketValue(), GetBookValue());           
        }
            
   
        /// <summary>
        ///  Sets the publisher variable.
        /// </summary>
        /// <param name="publisher"></param>
        public void SetPublisher(string publisher)
        {
            publisher_ = publisher;
        }


        /// <summary>
        ///  Sets the title.
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            title_ = title;
        }
            
   
        /// <summary>
        ///  Sets the issue.
        /// </summary>
        /// <param name="issue"></param>
        public void SetIssue(int issue)
        {
            issue_ = issue;
        }


        /// <summary>
        ///  Sets the date.
        /// </summary>
        /// <param name="date"></param>
        public void SetDate(string date)
        {
            date_ = date;
        }
        

        /// <summary>
        ///  Sets the book value.
        /// </summary>
        /// <param name="bookValue"></param>
        public void SetBookValue(decimal bookValue)
        {
            bookValue_ = bookValue;
        }
        

        /// <summary>
        /// Sets market value.
        /// </summary>
        /// <param name="marketValue"></param>
        public void SetMarketValue(decimal marketValue)
        {
            marketValue_ = marketValue;
        }
        
    }
    
}
