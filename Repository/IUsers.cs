using _3DModels.Models;
using System.Collections.Generic;

namespace _3DModels.Repository
{
    public interface Iusers
    {
        List<Users> GetAllusers();
        Users GetusersById(int user_id);
        void Createusers(Users Users);
        void Updateusers(Users Users);
        void Deleteusers(int user_id);
    }
}
