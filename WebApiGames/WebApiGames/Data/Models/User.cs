

namespace WebApiGames.Features
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using WebApiGames.Data.Models.Base;
    using WebApiGames.Models;

    public class User : IdentityUser, IEntity
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModefiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public IEnumerable<GamesReq> Games { get; } = new HashSet<GamesReq>();

    }
}
