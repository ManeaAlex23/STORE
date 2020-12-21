using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Data.Models.Base
{
    interface IDeletableEntity :IEntity
    {
         DateTime? DeletedOn { get; set; }

         string DeletedBy { get; set; }

         bool isDeleted { get; set; }
    }
}
