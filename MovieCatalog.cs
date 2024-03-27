using System;
using System.Collections.Generic;

class MovieCatalog
{
    Dictionary<int, Movie> movies = new Dictionary<int, Movie>();
    int nextMovieId = 1;

    public void AddMovie(string title, int releaseYear, string genre)
    {
        movies[nextMovieId] = new Movie(nextMovieId, title, releaseYear, genre);
        nextMovieId++;
    }

    public Movie GetMovie(int movieId)
    {
        if (movies.ContainsKey(movieId))
        {
            return movies[movieId];
        }
        else
        {
            return null;
        }
    }

    public void ListMovies()
    {
        Console.WriteLine("Movie Catalog:");
        foreach (var movie in movies.Values)
        {
            Console.WriteLine(movie);
        }
    }
}

class Movie
{
    public int Id { get; }
    public string Title { get; }
    public int ReleaseYear { get; }
    public string Genre { get; }

    public Movie(int id, string title, int releaseYear, string genre)
    {
        Id = id;
        Title = title;
        ReleaseYear = releaseYear;
        Genre = genre;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Title: {Title}, Release Year: {ReleaseYear}, Genre: {Genre}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        MovieCatalog catalog = new MovieCatalog();

        // Adding movies
        catalog.AddMovie("The Shawshank Redemption", 1994, "Drama");
        catalog.AddMovie("The Godfather", 1972, "Crime");
        catalog.AddMovie("The Dark Knight", 2008, "Action");

        // Retrieving movie information
        Console.WriteLine("Retrieving movie information:");
        Movie movie = catalog.GetMovie(2); // Get movie with ID 2
        if (movie != null)
        {
            Console.WriteLine(movie);
        }
        else
        {
            Console.WriteLine("Movie not found.");
        }

        // Listing all movies
        Console.WriteLine("\nListing all movies:");
        catalog.ListMovies();
    }
}
