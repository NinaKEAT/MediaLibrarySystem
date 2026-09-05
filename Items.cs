namespace MediaLibrarySystem
{
  // Add these classes to your namespace
  public class Book : MediaItem
  {
    private string _author = string.Empty;
    private int _pageCount;
    // TODO: Implement constructor with base class initialization
    public Book(string title, int year, string author, int pageCount) : base(title, year)
    {
      Author = author;
      PageCount = pageCount;
    }
    // TODO: Add Author and PageCount properties with validation
    public string Author
    {
      get => _author;
      set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Author cannot be empty.");
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
          throw new ArgumentException("Page count must be positive.");
        }
        _pageCount = value;
      }
    }
    // TODO: Override abstract method GetDisplayInfo()
    public override string GetDisplayInfo()
    {
      return $"Book: {Title} by {Author} ({Year}) - {PageCount} pages";
    }
    // TODO: Override virtual method GetBasicInfo() if needed
  }
  public class DVD : MediaItem
  {
    private string _director = string.Empty;
    private int _runtimeMinutes;
    // TODO: Implement similar structure for DVD
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
          throw new ArgumentException("Director cannot be empty.");
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
          throw new ArgumentException("Runtime must be positive.");
        }
        _runtimeMinutes = value;
      }
    }
    public override string GetDisplayInfo()
    {
      return $"DVD: {Title} directed by {Director} ({Year}) - {RuntimeMinutes} minutes";
    }
  }
  public class MusicAlbum : MediaItem
  {
    private string _artist = string.Empty;
    private int _trackCount;
    // TODO: Implement similar structure for MusicAlbum
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
          throw new ArgumentException("Artist cannot be empty.");
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
          throw new ArgumentException("Track count must be positive.");
        }
        _trackCount = value;
      }
    }
    public override string GetDisplayInfo()
    {
      return $"Music Album: {Title} by {Artist} ({Year}) - {TrackCount} tracks";
    }
  }
}