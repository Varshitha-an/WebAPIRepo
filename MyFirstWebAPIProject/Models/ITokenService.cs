using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebAPIProject.Models
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}
