
namespace WebApiGames.Features.Identity
{
    using System.ComponentModel.DataAnnotations;

  /*  [Table("AspNetUsers")]*/
    public class RegisterUserRequestModel
    {

        [Required]
        public string UserName { get; set; }


        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

      
        [Required]
        public string Password { get; set; }

        
        

    }
}
