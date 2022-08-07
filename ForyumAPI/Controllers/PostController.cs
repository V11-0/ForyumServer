using ApplicationCore.Models;
using ForyumAPI.Controllers.Base;
using ForyumAPI.Models;
using ForyumAPI.Models.DTO;
using ForyumAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForyumAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PostController : AppBaseController {

    private readonly IPostRepository _repository;

    public PostController(IPostRepository repository, IUserRepository userRepository): base(userRepository) {
        _repository = repository;
    }

    [HttpPost]
    public async Task CreatePost(PostCreationDTO postDto) {
        Post post = PostCreationDTO.toPost(postDto);
        await _repository.Insert(post);
    }

    [HttpGet]
    public async Task<IEnumerable<PostFeedDTO>> GetFeed(PostOrdenation orderBy) {
        var userId = await GetUserIdFromToken();
        return await _repository.GetFeed(userId, orderBy);
    }

    [HttpPost]
    [Route("Comment")]
    public async Task CreateComment(CommentCreationDTO comment) {
        await _repository.CreateComment(comment.toComment());
    }

    [HttpGet]
    [Route("{postId}/Comment")]
    public async Task<IEnumerable<CommentDTO>> GetComments(int postId) {
        return await _repository.GetComments(postId);
    }
}