using GameStoreBlazor.Models;

namespace GameStoreBlazor.Clients
{
    public class GamesClient
    {
        private readonly List<GameSummary> games =
        [
            new()
            {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99M,
            ReleaseDate = new DateOnly(1992, 7, 15)
            },
            new()
            {
            Id = 2,
            Name = "The Legend of Zelda: Ocarina of Time",
            Genre = "Adventure",
            Price = 29.99M,
            ReleaseDate = new DateOnly(1998, 11, 21)
             },
            new()
            {
            Id = 3,
            Name = "Super Mario World",
            Genre = "Platformer",
            Price = 14.99M,
            ReleaseDate = new DateOnly(1990, 11, 21)
            }
        ];
        
        public event Action? OnGamesUpdated;
       
        private readonly Genre[] genres = new GenresClient().GetGenres();
        public GameSummary[] GetGames() => games.ToArray();

        public void AddGame(GameDetails game)
        {
            ArgumentException.ThrowIfNullOrEmpty(game.GenreId);
            var genre = genres.Single(g => g.Id == int.Parse(game.GenreId));

            var gameSummary = new GameSummary()
            {
                 Id = games.Count +1,
                 Name = game.Name,
                 Genre = genre.Name,
                 Price = game.Price,
                 ReleaseDate = game.ReleaseDate,
            };

            games.Add(gameSummary);
            OnGamesUpdated?.Invoke();
        }
    }
}
