namespace MediaLibrarySystem
{
  // Add this interface to your namespace
  public interface IDisplayable
  {
    string GetDisplayInfo();
    string GetShortDescription();
  }
  public interface ISearchable
  {
    bool MatchesSearch(string searchTerm);
    List<string> GetSearchableTerms();
  }

  public abstract class MediaItem : IDisplayable, ISearchable
  {
    private string _title = string.Empty;
    private int _year;
    private readonly int _mediaId;
    private static int _nextMediaId = 1;
    protected MediaItem(string title, int year)
    {
      _mediaId = _nextMediaId++;
      Title = title;
      Year = year;
    }
    public string Title
    {
      get => _title;
      set { ValidateTitle(value); _title = value; }
    }
    public int Year
    {
      get { return _year; }
      set { ValidateYear(value); _year = value; }
    }
    public int MediaId => _mediaId;
    protected void ValidateTitle(string title)
    {
      if (string.IsNullOrWhiteSpace(title))
      {
        throw new ArgumentException("Title cannot be empty.", nameof(title));
      }
    }
    protected void ValidateYear(int year)
    {
      if (year < 1800 || year > DateTime.Now.Year)
      {
        throw new ArgumentException($"Year must be between 1800 and {DateTime.Now.Year}.", nameof(year));
      }
    }
    public MediaItem()
    {
      _mediaId = _nextMediaId++;
    }
    public abstract string GetDisplayInfo();
    public abstract string GetShortDescription();
    public virtual bool MatchesSearch(string searchTerm)
    {
      if (string.IsNullOrWhiteSpace(searchTerm))
      {
        throw new ArgumentException("Search term cannot be empty.", nameof(searchTerm));
      }
      return GetSearchableTerms().Any(term => term.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
    public abstract List<string> GetSearchableTerms();
    public virtual string GetBasicInfo()
    {
      return $"ID: {MediaId}, Title: {Title}, Year: {Year}";
    }
    // Add to MediaItem base class
    public virtual double GetEstimatedValue()
    {
      // Default implementation based on age
      int age = DateTime.Now.Year - Year;
      return Math.Max(5.0, 25.0 - (age * 2.0)); // Basic depreciation
    }
    public virtual string GetCategoryInfo()
    {
      return "General Media Item";
    }
  }
}