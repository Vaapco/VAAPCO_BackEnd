using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaapcoBE.BL.DTO;

namespace VaapcoBE.BL.Interface
{
    public interface IUserManagementService
    {
        public Task<Tuple<bool, List<string>>> RegisterUser(RegisterUserBL userDetails, bool isAdmin = true);
        public Task<IList<string>> GetRoles(string email);
        public Task<bool> LoginUser(string email, string password);
    }
}
