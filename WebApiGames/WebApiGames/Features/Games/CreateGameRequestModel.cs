using System.ComponentModel.DataAnnotations;


namespace WebApiGames.Features.Games
{
    public class CreateGameRequestModel
    {


        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string YoutubeUrl { get; set; }

        [Required]
        public string AgeCategory { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public bool Disponibility { get; set; }

        [Required]
        public int NumberOfUnits { get; set; }




    }
}
