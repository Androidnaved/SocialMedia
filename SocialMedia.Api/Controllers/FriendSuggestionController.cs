using Microsoft.AspNetCore.Mvc;
using SocialMedia.Domain;
using SocialMedia.Domain.Services;
using System.Text.Json;

namespace SocialMedia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendSuggestionController : ControllerBase
{
    private readonly IFriendSuggestionService _friendSuggestionService;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<FriendSuggestionController> _logger;

    public FriendSuggestionController(IFriendSuggestionService friendSuggestionService, IUserRepository userRepository, ILogger<FriendSuggestionController> logger)
    {
        _friendSuggestionService = friendSuggestionService;
        _userRepository = userRepository;
        _logger = logger;
    }

    [HttpGet("{userId}")]
    public IActionResult GetSuggestedFriends(int userId)
    {
        try
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            var suggestionIds = _friendSuggestionService.SuggestFriends(user);
            if (suggestionIds.Count == 0)
            {
                return NoContent();
            }

            var s = _userRepository.GetUserList(suggestionIds).Select(_ => _.Name);
            return Ok(s);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occurred while getting friend suggestions.", ex);
            return StatusCode(500, "Internal server error");
        }
    }
}