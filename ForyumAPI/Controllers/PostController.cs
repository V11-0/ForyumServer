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
    private readonly IUserRepository _userRepository;

    public PostController(IPostRepository repository, IUserRepository userRepository) {
        _repository = repository;
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task CreatePost(PostCreationDTO postDto) {
        Post post = PostCreationDTO.toPost(postDto);
        await _repository.Insert(post);
    }

    [HttpGet]
    public async Task<IEnumerable<PostFeedDTO>> GetFeed(PostOrdenation orderBy) {
        var token = GetTokenFromHeader();
        var user = await _userRepository.GetUserByToken(token);

        return await _repository.GetFeed(user.Id, orderBy);
    }
}