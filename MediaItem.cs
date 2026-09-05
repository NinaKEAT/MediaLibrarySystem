namespace MediaLibrarySystem
{
  public abstract class MediaItem
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
        throw new ArgumentException("Title cannot be empty.");
      }
    }
    protected void ValidateYear(int year)
    {
      if (year < 1800 || year > DateTime.Now.Year)
      {
        throw new ArgumentException($"Year must be between 1800 and {DateTime.Now.Year}.");
      }
    }
    public MediaItem()
    {
      _mediaId = _nextMediaId++;
    }
    public abstract string GetDisplayInfo();
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