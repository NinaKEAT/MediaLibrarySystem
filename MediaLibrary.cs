namespace MediaLibrarySystem
{
  public class MediaLibrary
  {
    private readonly List<MediaItem> _mediaItems = new List<MediaItem>();
    public void AddItem(MediaItem item)
    {
      ArgumentNullException.ThrowIfNull(item, nameof(item));
      if (_mediaItems.Any(existingItem => existingItem.MediaId == item.MediaId))
      {
        throw new InvalidOperationException($"Item ID {item.MediaId} already exists in the library.");
      }
      _mediaItems.Add(item);
    }

    public void DisplayAllItems()
    {
      foreach (var item in _mediaItems)
      {
        Console.WriteLine(item.GetDisplayInfo());
      }
    }

    public MediaItem? FindByTitle(string title)
    {
      if (string.IsNullOrWhiteSpace(title))
      {
        throw new ArgumentException("Title cannot be empty.", nameof(title));
      }
      // Search through collection and return matching item
      foreach (var item in _mediaItems)
      {
        if (item.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
        {
          return item;
        }
      }
      return null;
    }
    public void GetDetailedReport()
    {
      double totalEstimatedValue = 0.0;
      Console.WriteLine("\nDetailed Media Library Report:");
      foreach (var item in _mediaItems)
      {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(item.GetDisplayInfo());
        Console.WriteLine($"Category: {item.GetCategoryInfo()}");
        double estimatedValue = item.GetEstimatedValue();
        Console.WriteLine($"Estimated Value: ${estimatedValue:F2}");
        totalEstimatedValue += estimatedValue;
      }
      Console.WriteLine(new string('=', 40));
      Console.WriteLine($"Total Estimated Value: ${totalEstimatedValue:F2}");
    }
    public List<MediaItem> SearchItems(string searchTerm)
    {
      if (string.IsNullOrWhiteSpace(searchTerm))
      {
        throw new ArgumentException("Search term cannot be empty.", nameof(searchTerm));
      }
      List<MediaItem> results = new List<MediaItem>();
      foreach (var item in _mediaItems)
      {
        if (item.MatchesSearch(searchTerm))
        {
          results.Add(item);
        }
      }
      return results;
    }
    public void GetDisplaySummary()
    {
      Console.WriteLine("\nMedia Library Summary:");
      foreach (var item in _mediaItems)
      {
        Console.WriteLine(item.GetDisplayInfo());
        Console.WriteLine(item.GetShortDescription());
      }
    }
  }

}