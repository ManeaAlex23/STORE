using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Data.Models.Base
{
    public class DeletableEntity : Entity, IDeletableEntity
    {
        public DateTime? DeletedOn { get; set; }

        public string DeletedBy { get; set; }

        public bool isDeleted { get; set; }
    }
}
