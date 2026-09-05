namespace MediaLibrarySystem
{
  class MediaLibraryManager
  {
    // Implementation for managing the media library can go here
    private MediaLibrary _mediaLibrary;

    public MediaLibraryManager(MediaLibrary mediaLibrary)
    {
      _mediaLibrary = mediaLibrary;

      // Example of pre-loading media items into the library
      _mediaLibrary.AddItem(new Book("The Hobbit", 1937, "J.R.R. Tolkien", 310));
      _mediaLibrary.AddItem(new Book("To Kill a Mockingbird", 1960, "Harper Lee", 281));
      _mediaLibrary.AddItem(new Book("The Great Gatsby", 1925, "F. Scott Fitzgerald", 218));
      _mediaLibrary.AddItem(new Book("1984", 1949, "George Orwell", 328));
      _mediaLibrary.AddItem(new Book("Brave New World", 1932, "Aldous Huxley", 311));
      _mediaLibrary.AddItem(new Book("Fahrenheit 451", 1953, "Ray Bradbury", 194));
      
      _mediaLibrary.AddItem(new DVD("The Lord of the Rings: The Fellowship of the Ring", 2001, "Peter Jackson", 178));
      _mediaLibrary.AddItem(new DVD("The Lord of the Rings: The Two Towers", 2002, "Peter Jackson", 179));
      _mediaLibrary.AddItem(new DVD("The Lord of the Rings: The Return of the King", 2003, "Peter Jackson", 201));
      _mediaLibrary.AddItem(new DVD("Interstellar", 2014, "Christopher Nolan", 169));
      _mediaLibrary.AddItem(new DVD("Inception", 2010, "Christopher Nolan", 148));
      _mediaLibrary.AddItem(new DVD("The Matrix", 1999, "Lana Wachowski, Lilly Wachowski", 136));
      _mediaLibrary.AddItem(new MusicAlbum("Abbey Road", 1969, "The Beatles", 17));
      _mediaLibrary.AddItem(new MusicAlbum("Hotel California", 1976, "Eagles", 9));
      _mediaLibrary.AddItem(new MusicAlbum("Led Zeppelin IV", 1971, "Led Zeppelin", 8));
      _mediaLibrary.AddItem(new MusicAlbum("The Dark Side of the Moon", 1973, "Pink Floyd", 10));
      _mediaLibrary.AddItem(new MusicAlbum("Thriller", 1982, "Michael Jackson", 9));
      _mediaLibrary.AddItem(new MusicAlbum("Back in Black", 1980, "AC/DC", 10));
    }

    public int DisplayMenu()
    {
      // Implementation for displaying the menu can go here
      Console.WriteLine("Media Library Menu:");
      Console.WriteLine("1. Display all media items");
      Console.WriteLine("2. Add a new media item");
      Console.WriteLine("3. Search for a media item");
      Console.WriteLine("4. Get detailed report");
      Console.WriteLine("5. Exit");

      Console.Write("Enter your choice: ");
      int choice;
      while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
      {
        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
        Console.Write("Enter your choice: ");
      }
      return choice;
    }

    public void GetSelectedOption(int choice)
    {
      switch (choice)
      {
        case 1:
          // Display all media items
          Console.WriteLine("\nAll Media Items:");
          _mediaLibrary.DisplayAllItems();
          break;
        case 2:
          // Add a new media item
          _mediaLibrary.AddItem(CreateMediaItem());
          break;
        case 3:
          // Search for a media item
          Console.Write("Enter the title to search for: ");
          string searchTerm = Console.ReadLine();
          var searchResults = _mediaLibrary.SearchItems(searchTerm);
          Console.WriteLine("\nSearch Results:");
          foreach (var item in searchResults)
          {
            Console.WriteLine(item.GetDisplayInfo()); 
          }
          break;
        case 4:
          // Get detailed report
          _mediaLibrary.GetDetailedReport();
          break;
        case 5:
          // Exit
          break;
        default:
          Console.WriteLine("Invalid choice.");
          break;
      }
    }

    public MediaItem CreateMediaItem()
    {
      Console.WriteLine("New media item category :");
      Console.WriteLine("1. Book");
      Console.WriteLine("2. DVD");
      Console.WriteLine("3. Music Album");
      Console.Write("Enter your choice: ");
      int categoryChoice;
      while (!int.TryParse(Console.ReadLine(), out categoryChoice) || categoryChoice < 1 || categoryChoice > 3)
      {
        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
        Console.Write("Enter your choice: ");
      }
      switch (categoryChoice)
      {
        case 1:
          // Create a new Book
          Console.Write("Enter the title: ");
          string bookTitle = Console.ReadLine() ?? string.Empty;
          Console.Write("Enter the year of publication: ");
          int bookYear = int.Parse(Console.ReadLine());
          Console.Write("Enter the author: ");
          string bookAuthor = Console.ReadLine() ?? string.Empty;
          Console.Write("Enter the number of pages: ");
          int bookPages = int.Parse(Console.ReadLine());
          return new Book(bookTitle, bookYear, bookAuthor, bookPages);
        case 2:
          // Create a new DVD
          Console.Write("Enter the title: ");
          string dvdTitle = Console.ReadLine() ?? string.Empty;
          Console.Write("Enter the year of release: ");
          int dvdYear = int.Parse(Console.ReadLine());
          Console.Write("Enter the director: ");
          string dvdDirector = Console.ReadLine() ?? string.Empty;
          Console.Write("Enter the duration in minutes: ");
          int dvdDuration = int.Parse(Console.ReadLine());
          return new DVD(dvdTitle, dvdYear, dvdDirector, dvdDuration);
        case 3:
          // Create a new Music Album
          Console.Write("Enter the title: ");
          string albumTitle = Console.ReadLine() ?? string.Empty;
          Console.Write("Enter the year of release: ");
          int albumYear = int.Parse(Console.ReadLine());
          Console.Write("Enter the artist: ");
          string albumArtist = Console.ReadLine() ?? string.Empty;
          Console.Write("Enter the number of tracks: ");
          int albumTracks = int.Parse(Console.ReadLine());
          return new MusicAlbum(albumTitle, albumYear, albumArtist, albumTracks);
      }

      // Further implementation for creating the selected media item can go here
      return null; // Placeholder return statement
    }



  }
}