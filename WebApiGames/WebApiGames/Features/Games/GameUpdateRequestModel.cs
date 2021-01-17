using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Features.Games
{
    public class GameUpdateRequestModel
    {
        public int Id { get; set; }


        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string YoutubeUrl { get; set; }

        public int NumberofLikes { get; set; }

        public int NumberofDislikes { get; set; }

        public string AgeCategory { get; set; }
      
        public float Price { get; set; }
        
        public bool Disponibility { get; set; }
       
        public int NumberOfUnits { get; set; }

    }
}
