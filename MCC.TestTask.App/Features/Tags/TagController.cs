using System.Net;
using MCC.TestTask.App.Features.Tags.Dto;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MCC.TestTask.App.Services.Auth;

namespace MCC.TestTask.App.Features.Tags;

[Route("api/tag")]
public class TagController : ControllerBase
{
    private readonly TagService _tagService;
    private readonly UserAccessor _userAccessor;

    public TagController(TagService tagService, UserAccessor userAccessor)
    {
        _tagService = tagService;
        _userAccessor = userAccessor;
    }

    [HttpGet]
    public async Task<ActionResult<List<TagDto>>> GetTags()
    {
        return await _tagService.GetAllTagsAsync().ToActionResult();
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Guid>> CreateTag([FromBody] CreateTagModel model)
    {
        var userIdResult = _userAccessor.GetUserId();
        if (!userIdResult.IsSuccess)
            return Unauthorized();

        var createResult = await _tagService.CreateTag(model.Name, userIdResult.Value);
        return createResult.ToActionResult();
    }
}