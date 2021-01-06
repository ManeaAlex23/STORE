
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Models;


namespace WebApiGames.Features.Games
{

    public class GameService : IGameService
    {
        private readonly UserDbContext data;
        public GameService(UserDbContext data)
        {
            this.data = data;
        }
        public async Task<int> Create(string title, string description, string imageUrl,string youtubeUrl, string agecategory, float price, bool disponibility, int units, string UserId)
        {
            var game = new GamesReq
            {
                Title = title,
                Description = description,
                ImageUrl = imageUrl,
                YoutubeUrl = youtubeUrl,
                AgeCategory = agecategory,
                Price = price,
                Disponibility = disponibility,
                NumberOfUnits = units,
              
                UserId = UserId
            };

            this.data.Add(game);

            await this.data.SaveChangesAsync();

            return game.Id;
        }

        public async Task<bool> DeleteGame(int id, string userId)
        {
            var game = await this.data
                         .Games
                         .Where(c => c.Id == id && c.UserId == userId)
                         .FirstOrDefaultAsync();

            if(game == null)
            {
                return false;
            }

            this.data.Games.Remove(game);

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GameListRequestModel>> GetGames(string userId)
                => await this.data
                        .Games
                        //.Where(c => c.UserId == userId) //If UserId exists in DB //UserId valid.
                        .OrderByDescending(c => c.Id)
                        .Select(c => new GameListRequestModel
                        {

                            Id = c.Id,
                            Title = c.Title,
                            Description = c.Description,
                            ImageUrl = c.ImageUrl,
                            YoutubeUrl = c.YoutubeUrl,
                            AgeCategory = c.AgeCategory,
                            Price = c.Price,
                            Disponibility = c.Disponibility,
                            NumberOfUnits = c.NumberOfUnits
                        })
                        .ToListAsync();

        public async Task<IEnumerable<GameListRequestModel>> GetSingleGame(int id)
                => await this.data
                            .Games
                            .Where(c => c.Id == id)
                            .Select(c => new GameListRequestModel
                            {
                                Id = c.Id,
                                Title = c.Title,
                                Description = c.Description,
                                ImageUrl = c.ImageUrl,
                                YoutubeUrl = c.YoutubeUrl,
                                AgeCategory = c.AgeCategory,
                                Price = c.Price,
                                Disponibility = c.Disponibility,
                                NumberOfUnits = c.NumberOfUnits

                            })
                            .ToListAsync();

        public async Task<bool> UpdateGame(int id, string title, string description, string imageUrl, string youtubeUrl, string agecategory, float price, bool disponibility, int units, string userId)
        {
            var game = await this.data
                    .Games
                    .Where(c => c.Id == id && c.UserId == userId)
                    .FirstOrDefaultAsync();

            if(game == null)
            {
                return false;
            }

            game.Title = title;

            game.Description = description;

            game.ImageUrl = imageUrl;

            game.YoutubeUrl = youtubeUrl;

            game.AgeCategory = agecategory;

            game.Price = price;

            game.Disponibility = disponibility;

            game.NumberOfUnits = units;

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
