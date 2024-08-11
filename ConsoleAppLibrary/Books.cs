﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibrary
{
    public class Books
    {  // declaring datamembers of books
        public string ISBN {  get; set; }
        public string Title {  get; set; }
      //  public string Name { get; set; }
        public string  Author {  get; set; }
        public decimal Price { get; set; }
        
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsAvailable {  get; set; }
        
    }
}
