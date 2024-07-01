using SocialMedia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Services
{
    public interface IFriendSuggestionService
    {
        List<int> SuggestFriends(User user);
    }
}
