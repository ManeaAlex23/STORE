
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiGames.Features.Games
{
   public interface IGameService
    {
        public Task<int> Create(string title, string description, string imageUrl,string youtubeUrl,string agecategory, float price, bool disponibility,int units, string UserId);

        public Task<IEnumerable<GameListRequestModel>> GetGames(string userId);


        public Task<bool> UpdateGame(int id, string title, string description, string imageUrl, string youtubeUrl, string agecategory, float price, bool disponibility, int units, string userId);

        public Task<bool> DeleteGame(int id, string userId);
    }
}
