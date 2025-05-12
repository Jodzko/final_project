using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.BusinessLogic.Services.Interfaces
{
    public interface IJwtService
    {
        public string GetJwtToken(string username, string role);

    }
}
