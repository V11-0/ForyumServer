using ApplicationCore.Models;
using ForyumAPI.Controllers;
using ForyumAPI.Models.DTO;
using ForyumAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ForyumAPI.Tests.Controllers;

[TestClass]
public class UserControllerTests
{
    [TestMethod]
    public async Task CreateUser_Valid_ReturnsUser()
    {
        var repoMock = new Mock<IUserRepository>();
        repoMock.Setup(repo => repo.CheckForUsername(It.IsAny<string>()).Result)
            .Returns(false);
        repoMock.Setup(repo => repo.CheckForEmail(It.IsAny<string>()).Result)
            .Returns(false);
        repoMock.Setup(repo => repo.Insert(It.IsAny<User>()).Result)
            .Returns(new User());

        var controller = new UserController(repoMock.Object);
        var user = new UserCreationDTO();

        var result = (await controller.CreateUser(user)).Result;

        Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
    }

    [TestMethod]
    public async Task CreateUser_UsernameExists_Conflict()
    {
        var repoMock = new Mock<IUserRepository>();
        repoMock.Setup(repo => repo.CheckForUsername(It.IsAny<string>()).Result)
            .Returns(true);
        repoMock.Setup(repo => repo.CheckForEmail(It.IsAny<string>()).Result)
            .Returns(false);

        var controller = new UserController(repoMock.Object);
        var user = new UserCreationDTO();

        var result = (await controller.CreateUser(user)).Result;

        Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
    }

    [TestMethod]
    public async Task CreateUser_EmailExists_ReturnsConflict()
    {
        var repoMock = new Mock<IUserRepository>();
        repoMock.Setup(repo => repo.CheckForUsername(It.IsAny<string>()).Result)
            .Returns(false);
        repoMock.Setup(repo => repo.CheckForEmail(It.IsAny<string>()).Result)
            .Returns(true);

        var controller = new UserController(repoMock.Object);
        var user = new UserCreationDTO();

        var result = (await controller.CreateUser(user)).Result;

        Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
    }

    [TestMethod]
    public async Task CreateUser_UsernameAndEmailExists_ReturnsConflict()
    {
        var repoMock = new Mock<IUserRepository>();
        repoMock.Setup(repo => repo.CheckForUsername(It.IsAny<string>()).Result)
            .Returns(true);
        repoMock.Setup(repo => repo.CheckForEmail(It.IsAny<string>()).Result)
            .Returns(true);

        var controller = new UserController(repoMock.Object);
        var user = new UserCreationDTO();

        var result = (await controller.CreateUser(user)).Result;

        Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
    }

    [TestMethod]
    public async Task Login_ValidUser_ReturnsSession()
    {
        var repoMock = new Mock<IUserRepository>();
        repoMock
            .Setup(repo => repo.Login(It.IsAny<UserLoginDTO>(), It.IsAny<string?>()).Result)
            .Returns(new Session());

        var controller = new UserController(repoMock.Object);
        var userLogin = new UserLoginDTO();

        var result = await controller.Login(userLogin);

        Assert.IsInstanceOfType(result, typeof(ActionResult<Session>));
    }

    [TestMethod]
    public async Task Login_InvalidUser_ReturnsUnauthorized()
    {
        var repoMock = new Mock<IUserRepository>();

        var controller = new UserController(repoMock.Object);
        var userLogin = new UserLoginDTO();

        var result = (await controller.Login(userLogin)).Result;

        Assert.IsInstanceOfType(result, typeof(UnauthorizedResult));
    }

    [TestMethod]
    public async Task GetUserById_ValidId_ReturnsUser() {
        var repoMock = new Mock<IUserRepository>();

        repoMock.Setup(
            repo => repo.GetUserDTO(It.IsAny<int>()).Result)
            .Returns(new UserBasicDTO("username", "Brazil", ""));

        var controller = new UserController(repoMock.Object);
        var id = 1;

        var result = await controller.GetUserById(id);

        Assert.IsInstanceOfType(result, typeof(ActionResult<UserBasicDTO>));
    }

    [TestMethod]
    public async Task GetUserById_InvalidId_ReturnsNotFound() {
        var repoMock = new Mock<IUserRepository>();

        var controller = new UserController(repoMock.Object);
        var id = 1;

        var result = (await controller.GetUserById(id)).Result;

        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
}
