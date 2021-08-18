using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public HasScopeRequirement(string _scope, string _issuer)
        {
            Scope = _scope ?? throw new ArgumentNullException(nameof(_scope));
            Issuer = _issuer ?? throw new ArgumentNullException(nameof(_issuer));
        }
    }
}