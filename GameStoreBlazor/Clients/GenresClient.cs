using GameStoreBlazor.Models;

namespace GameStoreBlazor.Clients
{
    public class GenresClient
    {
        private readonly Genre[] genres =
            [
                   new()
                   {
                        Id = 1,
                        Name = "Fighting"
                   },
                    new()
                    {
                        Id = 2,
                        Name = "Adventure"
                    },
                    new()
                    {
                        Id = 3,
                        Name = "RPG"
                    },
                    new()
                    {
                        Id = 4,
                        Name = "Shooter"
                    },
                    new()
                    {
                        Id = 5,
                        Name = "Sports"
                    }

        ];


        public Genre[] GetGenres() => genres;
    }



}
