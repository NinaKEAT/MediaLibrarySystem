using System;
using System.Collections.Generic;
namespace MediaLibrarySystem
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("===============================================");
      Console.WriteLine("Welcome to the Media Library Management System!");
      Console.WriteLine("===============================================\n");

      // TODO: Add your media library logic here
      Book myBook = new Book("The Great Gatsby", 1925, "F. Scott Fitzgerald", 218);
      Book mySecondBook = new Book("1984", 1949, "George Orwell", 328);
      DVD myDVD = new DVD("Inception", 2010, "Christopher Nolan", 148);
      DVD mySecondDVD = new DVD("The Matrix", 1999, "Lana Wachowski, Lilly Wachowski", 136);
      MusicAlbum myAlbum = new MusicAlbum("Thriller", 1982, "Michael Jackson", 9);
      MusicAlbum mySecondAlbum = new MusicAlbum("Back in Black", 1980, "AC/DC", 10);

      MediaLibrary myLibrary = new MediaLibrary();
      myLibrary.AddItem(myBook);
      myLibrary.AddItem(mySecondBook);
      myLibrary.AddItem(myDVD);
      myLibrary.AddItem(mySecondDVD);
      myLibrary.AddItem(myAlbum);
      myLibrary.AddItem(mySecondAlbum);

      // myLibrary.DisplayAllItems();

      // Example of finding an item by title
      MediaItem foundItem = myLibrary.FindByTitle("Inception");
      if (foundItem != null)
      {
        Console.WriteLine("Found item: " + foundItem.GetDisplayInfo());
      }
      else
      {
        Console.WriteLine("Item not found.");
      }
      myLibrary.GetDetailedReport();

      Console.WriteLine("\n===============================================");
      Console.WriteLine("Thank you for using the Media Library System!");
      Console.WriteLine("===============================================");
      Console.ReadLine(); // Keep console open
    }
  }
}
