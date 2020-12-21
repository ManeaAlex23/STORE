using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Data.Models.Base
{
    public interface IEntity
    {
         DateTime CreatedOn { get; set; }

        
         string CreatedBy { get; set; }

         DateTime? ModefiedOn { get; set; }

         string ModifiedBy { get; set; }
    }
}
