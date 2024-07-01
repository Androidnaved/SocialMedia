using SocialMedia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain;

public interface IUserRepository
{
    User GetUserById(int userId);

    List<User> GetUserList(List<int> userIdList);
}
