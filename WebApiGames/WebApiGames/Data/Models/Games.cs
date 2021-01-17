using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApiGames.Data.Models.Base;
using WebApiGames.Features;


namespace WebApiGames.Models
{
    public class GamesReq : DeletableEntity,IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]

        public string YoutubeUrl { get; set; }

        [Required]

        public int NumberofLikes { get; set; }

        [Required]
        public int NumberofDislikes { get; set; }

        [Required]
        public string AgeCategory { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public bool Disponibility { get; set; }

        [Required]
        public int NumberOfUnits { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
