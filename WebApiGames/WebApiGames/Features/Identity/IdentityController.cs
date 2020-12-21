namespace WebApiGames.Features
{

 
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;
    using WebApiGames.Features.Identity;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;

        public IdentityController(
            UserManager<User> userManager,
            IIdentityService identityService,
            IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(Register))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.UserEmail            
                                
            };
            var result = await this.userManager.CreateAsync(user,model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
               
            }

            return Ok();
        }
        
        [HttpPost]
        [Route(nameof(Login))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginUserRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user,model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

           var token =  this.identityService.GenerateJwtToken(user.Id,model.UserName,this.appSettings.Secret);
         


            return new LoginResponseModel
            {
                Token = token
            };
            
           
        }
     
    }
}
