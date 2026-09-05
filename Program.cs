using System;
using System.Collections.Generic;
namespace MediaLibrarySystem
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to the Media Library Management System!");
      Console.WriteLine("=============================================");

      // TODO: Add your media library logic here
      Book myBook = new Book("The Great Gatsby", 1925, "F. Scott Fitzgerald", 218);
      DVD myDVD = new DVD("Inception", 2010, "Christopher Nolan", 148);
      MusicAlbum myAlbum = new MusicAlbum("Thriller", 1982, "Michael Jackson", 9);

      Console.WriteLine(myBook.GetDisplayInfo());
      Console.WriteLine(myDVD.GetDisplayInfo());
      Console.WriteLine(myAlbum.GetDisplayInfo());

      Console.WriteLine("Thank you for using the Media Library System!");
      Console.ReadLine(); // Keep console open
    }
  }
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
  }

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
