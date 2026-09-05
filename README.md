# Media Library System

A C# console application for managing a personal media collection — books, DVDs, and music albums — with menu-driven CRUD operations, search, reporting, and persistence to a local JSON file.

## Features

- **Interactive menu** — a simple numbered menu loop lets you:
  1. Display all media items
  2. Add a new media item
  3. Search for a media item
  4. Get a detailed report
  5. Exit
- **Three media categories**, each modeled as its own class inheriting from a shared `MediaItem` base:
  - **Book** — Title, Year, Author, Page Count
  - **DVD** — Title, Year, Director, Runtime (minutes)
  - **MusicAlbum** — Title, Year, Artist, Track Count
- **Search** — find items by matching search term across the collection.
- **Detailed report** — a summary report generated from the current library contents.
- **JSON persistence** — the library is loaded from and saved back to `data.json` on startup and whenever a new item is added, so your collection survives between runs.
- **Input validation** — required strings and integers (with min/max bounds, e.g. publication year) are validated at the console prompt, re-prompting on invalid input rather than crashing.

## Project Structure

```
MediaLibrarySystem/
├── Program.cs                    # Entry point — runs the main menu loop
├── MediaItem.cs                  # Base class shared by Book, DVD, and MusicAlbum
├── Items.cs                      # Book, DVD, and MusicAlbum class definitions
├── MediaLibrary.cs               # In-memory collection: add, search, display, report
├── MediaLibraryManager.cs        # Menu logic, user input handling, JSON load/save
├── MediaLibrarySystem.csproj
└── data.json                      # Persisted media items (loaded on startup)
```

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Run the app

```bash
git clone https://github.com/NinaKEAT/MediaLibrarySystem.git
cd MediaLibrarySystem
dotnet run
```

On startup, the app loads any existing items from `data.json` and presents the main menu. Choose an option by entering its number (1–5).

### Sample data format

New items are appended to `data.json` in this shape:

```json
[
  {
    "category": "book",
    "title": "Example Title",
    "year": 2020,
    "author": "Jane Doe",
    "pageCount": 320
  },
  {
    "category": "dvd",
    "title": "Example Movie",
    "year": 2019,
    "director": "John Smith",
    "runtimeMinutes": 118
  },
  {
    "category": "musicAlbum",
    "title": "Example Album",
    "year": 2021,
    "artist": "Some Artist",
    "trackCount": 12
  }
]
```

## Tech Stack

- C# / .NET console application
- `System.Text.Json` for reading and writing the local data file

## Development Notes

This project was developed with the assistance of GitHub Copilot, which helped scaffold the `MediaItem` class hierarchy (Book, DVD, MusicAlbum), the menu-driven console loop, JSON load/save logic, and input validation helpers for required strings and bounded integers.