using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiGames.Features.Games;
using WebApiGames.Infrastructure;
using WebApiGames.Infrastructure.Services;

namespace WebApiGames.Features
{

    public class GamesController : ApiController
    {
        private readonly IGameService gameService;
        private readonly ICurrentUserService currentUser;

        public GamesController(
            IGameService gameService,
            ICurrentUserService currentUser)
        {
            this.gameService = gameService;
            this.currentUser = currentUser;
        }

        [Authorize]
        [HttpGet]
        

        public async Task<IEnumerable<GameListRequestModel>> GetGames()
        {
            var userId = this.currentUser.GetId();

            var games = await this.gameService.GetGames(userId);

            return games;
            
        }


        [Authorize]
        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult> DeleteGame(int id)
        {
            var userId = this.User.GetId();

            var deleted = await this.gameService.DeleteGame(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }
            return Ok();

        }


        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create(CreateGameRequestModel model) 
        {
            var userId = this.currentUser.GetId();

            var Id = await this.gameService.Create(
                        model.Title,
                        model.Description,
                        model.ImageUrl,
                        model.YoutubeUrl,
                        model.AgeCategory,
                        model.Price,
                        model.Disponibility,
                        model.NumberOfUnits,
                        userId
                        );

            return Created(nameof(this.Create), Id);
        }

        [Authorize]
        [HttpPut]

        public async Task<ActionResult> UpdateGame(GameUpdateRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var updated = await this.gameService.UpdateGame(
                                    model.Id,
                                    model.Title,
                                    model.Description,
                                    model.ImageUrl,
                                    model.YoutubeUrl,
                                    model.AgeCategory,
                                    model.Price,
                                    model.Disponibility,
                                    model.NumberOfUnits,
                                    userId);


            if (!updated)
            {
                return BadRequest();
            }
            return Ok();
        }


      

      
    }
}
