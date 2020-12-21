using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Data.Models.Base
{
    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }

        
        public string CreatedBy { get; set; }

        public DateTime? ModefiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}
