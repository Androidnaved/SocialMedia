using SocialMedia.Domain.Models;
using SocialMedia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users;

        static UserRepository()
        {
            Users = new List<User>
            {
                new User { Id = 1, Name = "Alice" },
                new User { Id = 2, Name = "Bob" },
                new User { Id = 3, Name = "Charlie" },
                new User { Id = 4, Name = "Dave" },
                new User { Id = 5, Name = "Eve" },
                new User { Id = 6, Name = "Frank" },
                new User { Id = 7, Name = "Grace" },
                new User { Id = 8, Name = "Hank" },
                new User { Id = 9, Name = "Ivy" },
                new User { Id = 10, Name = "Jack" }
            };

            // Establishing friendships (for simplicity, making everyone friends with next user in the list)
            Users[0].Friends.Add(Users[1]);
            Users[1].Friends.Add(Users[2]);
            Users[2].Friends.Add(Users[3]);
            Users[3].Friends.Add(Users[4]);
            Users[4].Friends.Add(Users[5]);
            Users[5].Friends.Add(Users[6]);
            Users[6].Friends.Add(Users[7]);
            Users[7].Friends.Add(Users[8]);
            Users[8].Friends.Add(Users[9]);
            Users[9].Friends.Add(Users[0]);
        }

        public User GetUserById(int userId)
        {
            return Users.SingleOrDefault(_ => _.Id == userId);
        }

        
        public List<User> GetUserList(List<int> userIdList)
        {
            // write a query which returns a list of users based on userIdList

            return Users.Where(_ => userIdList.Contains(_.Id)).ToList();
        }

    }
}
