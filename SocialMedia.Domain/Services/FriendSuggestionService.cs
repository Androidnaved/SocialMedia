using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using SocialMedia.Domain.Models;

namespace SocialMedia.Domain.Services
{
    public class FriendSuggestionService : IFriendSuggestionService
    {
        public List<int> SuggestFriends(User user)
        {
            var suggestedFriends = new HashSet<User>();

            var randonNumber = new Random().Next(1, user.Friends.Count == 0 ? 1 : user.Friends.Count);
            var friend = user.Friends.Where(_ => _.Id == randonNumber).FirstOrDefault();

            if (friend == null)
            {
                friend = user.Friends.FirstOrDefault();
            }
            
            if (friend == null) return new List<int>();
            var suggestedFriendsIdList = friend.Friends.Where(_ => _.Id != user.Id).Select(_ => _.Id).ToList();

            return suggestedFriendsIdList;
        }
    }
}
