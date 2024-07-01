using SocialMedia.Domain.Models;
using SocialMedia.Domain.Services;

namespace SocialMedia.Tests;

public class FriendSuggestionServiceTests
{
    [Fact]
    public void SuggestFriends_WhenCalled_ReturnsListOfUserIds()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Friends = new List<User>
                {
                    new User { Id = 2, Name = "Friend1", Friends = new List<User> { new User { Id = 3, Name = "Friend2" } } }
                }
        };

        var friendSuggestionService = new FriendSuggestionService();

        // Act
        var suggestedFriends = friendSuggestionService.SuggestFriends(user);

        // Assert
        Assert.NotEmpty(suggestedFriends);
    }

    [Fact]
    public void SuggestFriends_WhenUserHasNoFriends_ReturnsEmptyList()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Friends = new List<User>()
        };

        var friendSuggestionService = new FriendSuggestionService();

        // Act
        var suggestedFriends = friendSuggestionService.SuggestFriends(user);

        // Assert
        Assert.Empty(suggestedFriends);
    }
}