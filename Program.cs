using System;
using System.Collections.Generic;
namespace MediaLibrarySystem
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("===============================================");
      Console.WriteLine("Welcome to the Media Library Management System!");
      Console.WriteLine("===============================================\n");

      MediaLibrary myLibrary = new MediaLibrary();
      MediaLibraryManager manager = new MediaLibraryManager(myLibrary);

      int choice = manager.DisplayMenu();
      manager.GetSelectedOption(choice);

      Console.WriteLine("\n===============================================");
      Console.WriteLine("Thank you for using the Media Library System!");
      Console.WriteLine("===============================================");
      Console.ReadLine(); // Keep console open
    }
}
}
