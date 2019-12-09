using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA6 //Constructor class for book object
{
    class Book
    {

        public string cwid { get; set; } //genereates getters and setters for all these variables
        public string isbn { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string cover { get; set; }
        public string genre { get; set; }
        public int length { get; set; }
        public int copies { get; set; }
        public string _id { get; set; }

        public Book(string cwid, string isbn, string title, string author, string cover, string genre, int length, int copies, string id) //main constructor. Requires all information
        {
            this.cwid = cwid;
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.cover = cover;
            this.genre = genre;
            this.length = length;
            this.copies = copies;
            _id = id;
        }

        public Book() //defailt constructor, with no variables. Used when making a new book
        {

        }

        public override string ToString()
        {
            return this.title;
        }
    }
}
