namespace MediaLibrarySystem
{
  // Add these classes to your namespace
  public class Book : MediaItem
  {
    private string _author = string.Empty;
    private int _pageCount;
    public Book(string title, int year, string author, int pageCount) : base(title, year)
    {
      Author = author;
      PageCount = pageCount;
    }
    public string Author
    {
      get => _author;
      set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Author cannot be empty.", nameof(value));
        }
        _author = value;
      }
    }
    public int PageCount
    {
      get => _pageCount;
      set
      {
        if (value <= 0)
        {
          throw new ArgumentException("Page count must be positive.", nameof(value));
        }
        _pageCount = value;
      }
    }
    public override string GetDisplayInfo()
    {
      return $"Book: {Title} by {Author} ({Year}) - {PageCount} pages";
    }
    public override double GetEstimatedValue()
    {
      double baseValue = base.GetEstimatedValue();
      double pageBonus = PageCount > 300 ? 5.0 : 0.0;
      return baseValue + pageBonus;
    }
    public override string GetCategoryInfo()
    {
      return "Book";
    }
    public override string GetShortDescription()
    {
      return $"Book: {Title} by {Author}";
    }
    public override List<string> GetSearchableTerms()
    {
      return new List<string> { Title, Author };
    }
  }

  public class DVD : MediaItem
  {
    private string _director = string.Empty;
    private int _runtimeMinutes;
    public DVD(string title, int year, string director, int runtimeMinutes) : base(title, year)
    {
      Director = director;
      RuntimeMinutes = runtimeMinutes;
    }
    public string Director
    {
      get => _director;
      set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Director cannot be empty.", nameof(value));
        }
        _director = value;
      }
    }
    public int RuntimeMinutes
    {
      get => _runtimeMinutes;
      set
      {
        if (value <= 0)
        {
          throw new ArgumentException("Runtime must be positive.", nameof(value));
        }
        _runtimeMinutes = value;
      }
    }
    public override string GetDisplayInfo()
    {
      return $"DVD: {Title} directed by {Director} ({Year}) - {RuntimeMinutes} minutes";
    }
    public override double GetEstimatedValue()
    {
      double baseValue = base.GetEstimatedValue();
      double runtimeBonus = RuntimeMinutes > 120 ? 3.0 : 0.0;
      return baseValue + runtimeBonus;
    }
    public override string GetCategoryInfo()
    {
      return "DVD";
    }
    public override string GetShortDescription()
    {
      return $"DVD: {Title} directed by {Director}";
    }
    public override List<string> GetSearchableTerms()
    {
      return new List<string> { Title, Director };
    }
  }

  public class MusicAlbum : MediaItem
  {
    private string _artist = string.Empty;
    private int _trackCount;
    public MusicAlbum(string title, int year, string artist, int trackCount) : base(title, year)
    {
      Artist = artist;
      TrackCount = trackCount;
    }
    public string Artist
    {
      get => _artist;
      set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Artist cannot be empty.", nameof(value));
        }
        _artist = value;
      }
    }
    public int TrackCount
    {
      get => _trackCount;
      set
      {
        if (value <= 0)
        {
          throw new ArgumentException("Track count must be positive.", nameof(value));
        }
        _trackCount = value;
      }
    }
    public override string GetDisplayInfo()
    {
      return $"Music Album: {Title} by {Artist} ({Year}) - {TrackCount} tracks";
    }
    public override double GetEstimatedValue()
    {
      double baseValue = base.GetEstimatedValue();
      double trackBonus = TrackCount > 12 ? 4.0 : 0.0;
      return baseValue + trackBonus;
    }
    public override string GetCategoryInfo()
    {
      return "Music Album";
    }
    public override string GetShortDescription()
    {
      return $"Music Album: {Title} by {Artist}";
    }
    public override List<string> GetSearchableTerms()
    {
      return new List<string> { Title, Artist };
    }
  }
}