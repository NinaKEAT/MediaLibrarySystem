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

      Console.WriteLine("Thank you for using the Media Library System!");
      Console.ReadLine(); // Keep console open
    }
  }
  abstract class MediaItem
  {
    private string _title = string.Empty;
    private int _year;
    private readonly int _mediaId;
    private static int _nextMediaId = 1;

    public string Title
    {
      get { return _title; }
      set { _title = value; }
    }

    public int Year
    {
      get { return _year; }
      set { _year = value; }
    }

    public int MediaId
    {
      get { return _mediaId; }
    }

    protected void ValidateTitle()
    {
      if (string.IsNullOrWhiteSpace(_title))
      {
        throw new ArgumentException("Title cannot be empty.");
      }
    }
    protected void ValidateYear()
    {
      if (_year < 1800 || _year > DateTime.Now.Year)
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
}
