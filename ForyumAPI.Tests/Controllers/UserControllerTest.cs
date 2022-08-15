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
    public async Task CreateUser_Valid_User()
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
    public async Task CreateUser_EmailExists_Conflict()
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
    public async Task CreateUser_UsernameAndEmailExists_Conflict()
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
    public async Task Login_Valid_Session()
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
    public async Task Login_Invalid_Unauthorized()
    {
        var repoMock = new Mock<IUserRepository>();

        var controller = new UserController(repoMock.Object);
        var userLogin = new UserLoginDTO();

        var result = (await controller.Login(userLogin)).Result;

        Assert.IsInstanceOfType(result, typeof(UnauthorizedResult));
    }
}
