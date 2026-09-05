namespace MediaLibrarySystem
{
  public class MediaLibrary
  {
    private List<MediaItem> _mediaItems;

    public MediaLibrary()
    {
      _mediaItems = new List<MediaItem>();
    }

    // TODO: Implement AddItem method that accepts any MediaItem
    public void AddItem(MediaItem item)
    {
      // Add validation and implementation
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item), "Media item cannot be null.");
      }
      _mediaItems.Add(item);
    }

    // TODO: Implement DisplayAllItems using polymorphism
    public void DisplayAllItems()
    {
      // Use polymorphic method calls to display all items
      foreach (var item in _mediaItems)
      {
        Console.WriteLine(item.GetDisplayInfo());
      }
    }

    // TODO: Implement FindByTitle method
    public MediaItem FindByTitle(string title)
    {
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
  }

}