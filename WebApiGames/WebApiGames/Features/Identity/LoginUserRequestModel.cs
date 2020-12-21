using System.ComponentModel.DataAnnotations;


namespace WebApiGames.Features.Identity
{
    /*  [Table("AspNetUsers")]*/
    public class LoginUserRequestModel
    {
        [Required]
        public string UserName { get; set; }

       
        [Required]
        public string Password { get; set; }
    }
}
