using System;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace MediaLibrarySystem
{
  class MediaLibraryManager
  {
    // Implementation for managing the media library can go here
    private MediaLibrary _mediaLibrary;

    public MediaLibraryManager(MediaLibrary mediaLibrary)
    {
      ArgumentNullException.ThrowIfNull(mediaLibrary, nameof(mediaLibrary));
      _mediaLibrary = mediaLibrary;

      LoadDataFromJson("data.json");
    }

    public void LoadDataFromJson(string filePath)
    {
      string jsonData = File.ReadAllText(filePath);
      using JsonDocument document = JsonDocument.Parse(jsonData);
      foreach (JsonElement item in document.RootElement.EnumerateArray())
      {
        string? category = item.GetProperty("category").GetString();
        if (string.IsNullOrEmpty(category))
        {
          throw new ArgumentException("Category is missing or empty in the JSON data.");
        }
        else
        {
          switch (category.ToLower())
          {
            case "book":
              _mediaLibrary.AddItem(new Book(
                item.GetProperty("title").GetString() ?? throw new ArgumentException("Title is missing for a book."),
                item.GetProperty("year").GetInt32(),
                item.GetProperty("author").GetString() ?? throw new ArgumentException("Author is missing for a book."),
                item.GetProperty("pageCount").GetInt32()
              ));
              break;
            case "dvd":
              _mediaLibrary.AddItem(new DVD(
                item.GetProperty("title").GetString() ?? throw new ArgumentException("Title is missing for a DVD."),
                item.GetProperty("year").GetInt32(),
                item.GetProperty("director").GetString() ?? throw new ArgumentException("Director is missing for a DVD."),
                item.GetProperty("runtimeMinutes").GetInt32()
              ));
              break;
            case "musicalbum":
              _mediaLibrary.AddItem(new MusicAlbum(
                item.GetProperty("title").GetString() ?? throw new ArgumentException("Title is missing for a music album."),
                item.GetProperty("year").GetInt32(),
                item.GetProperty("artist").GetString() ?? throw new ArgumentException("Artist is missing for a music album."),
                item.GetProperty("trackCount").GetInt32()
              ));
              break;
            default:
              throw new ArgumentException($"Unknown category: {category}");
          }
        }

      }
    }

    public int DisplayMenu()
    {
      // Implementation for displaying the menu can go here
      Console.WriteLine("\nMedia Library Menu:");
      Console.WriteLine("1. Display all media items");
      Console.WriteLine("2. Add a new media item");
      Console.WriteLine("3. Search for a media item");
      Console.WriteLine("4. Get detailed report");
      Console.WriteLine("5. Exit");

      Console.Write("\nEnter your choice: ");
      int choice;
      while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
      {
        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
        Console.Write("\nEnter your choice: ");
      }
      return choice;
    }

    public void GetSelectedOption(int choice)
    {
      try
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
            Console.WriteLine("Media item added successfully.");
            break;
          case 3:
            // Search for a media item
            string searchTerm = ReadRequiredString("Enter the term to search for: ");
            var searchResults = _mediaLibrary.SearchItems(searchTerm);
            Console.WriteLine("\nSearch Results:");
            if (searchResults.Count == 0)
            {
              Console.WriteLine("No media items found matching the search term.");
            }
            else
            {
              foreach (var item in searchResults)
              {
                Console.WriteLine(item.GetDisplayInfo());
              }
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
      catch (ArgumentException ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
      }
    }

    private static string ReadRequiredString(string prompt)
    {
      while (true)
      {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
          return input.Trim();
        }
        Console.WriteLine("Input is required. Please try again.");
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

      MediaItem newItem;

      switch (categoryChoice)
      {
        case 1:
          // Create a new Book
          string bookTitle = ReadRequiredString("Enter the title: ");
          int bookYear = ReadRequiredInt("Enter the year of publication: ", 1800, DateTime.Now.Year);
          string bookAuthor = ReadRequiredString("Enter the author: ");
          int bookPages = ReadRequiredInt("Enter the number of pages: ", 1, int.MaxValue);
          newItem = new Book(bookTitle, bookYear, bookAuthor, bookPages);
          break;
        case 2:
          // Create a new DVD
          string dvdTitle = ReadRequiredString("Enter the title: ");
          int dvdYear = ReadRequiredInt("Enter the year of release: ", 1800, DateTime.Now.Year);
          string dvdDirector = ReadRequiredString("Enter the director: ");
          int dvdDuration = ReadRequiredInt("Enter the duration in minutes: ", 1, int.MaxValue);
          newItem = new DVD(dvdTitle, dvdYear, dvdDirector, dvdDuration);
          break;
        case 3:
          // Create a new Music Album
          string albumTitle = ReadRequiredString("Enter the title: ");
          int albumYear = ReadRequiredInt("Enter the year of release: ", 1800, DateTime.Now.Year);
          string albumArtist = ReadRequiredString("Enter the artist: ");
          int albumTracks = ReadRequiredInt("Enter the number of tracks: ", 1, int.MaxValue);
          newItem = new MusicAlbum(albumTitle, albumYear, albumArtist, albumTracks);
          break;
        default:
          throw new InvalidOperationException("Invalid media category choice.");
      }
      AddMediaItemToJson(newItem);
      return newItem;
    }

    private void AddMediaItemToJson(MediaItem item, string filePath = "data.json")
    {
      JsonDocument document;
      if (File.Exists(filePath))
      {
        string jsonData = File.ReadAllText(filePath);
        if (!string.IsNullOrWhiteSpace(jsonData))
        {
          document = JsonDocument.Parse(jsonData);
        }
        else
        {
          document = JsonDocument.Parse("[]");
        }
      }
      else
      {
        document = JsonDocument.Parse("[]");
      }
      List<JsonElement> items = new List<JsonElement>();
      foreach (JsonElement element in document.RootElement.EnumerateArray())
      {
        items.Add(element);
      }
      JsonObject newJsonItem;
      if (item is Book book)
      {
        newJsonItem = new JsonObject
        {
          ["category"] = "book",
          ["title"] = book.Title,
          ["year"] = book.Year,
          ["author"] = book.Author,
          ["pageCount"] = book.PageCount
        };
      }
      else if (item is DVD dvd)
      {
        newJsonItem = new JsonObject
        {
          ["category"] = "dvd",
          ["title"] = dvd.Title,
          ["year"] = dvd.Year,
          ["director"] = dvd.Director,
          ["runtimeMinutes"] = dvd.RuntimeMinutes
        };
      }
      else if (item is MusicAlbum album)
      {
        newJsonItem = new JsonObject
        {
          ["category"] = "musicAlbum",
          ["title"] = album.Title,
          ["year"] = album.Year,
          ["artist"] = album.Artist,
          ["trackCount"] = album.TrackCount
        };
      }
      else
      {
        throw new InvalidOperationException("Invalid media item type.");
      }
      items.Add(JsonSerializer.Deserialize<JsonElement>(newJsonItem.ToJsonString()));
      string updatedJson = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
      File.WriteAllText(filePath, updatedJson);
      document.Dispose();
    }

    private static int ReadRequiredInt(string prompt, int minValue, int maxValue)
    {
      while (true)
      {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int result) && result >= minValue && result <= maxValue)
        {
          return result;
        }
        Console.WriteLine($"Invalid number. Please enter a value between {minValue} and {maxValue}.");
      }
    }


  }
}