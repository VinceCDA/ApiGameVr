using ApiGameVr.Application.Features.Users.Commands.Create;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace ApiGameVr.Test.ArchitectureTests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetUserListShouldReturnOk()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetAsync("/user", TestContext.Current.CancellationToken);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task CreatingUserShouldReturnUserOk()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.PostAsJsonAsync("/user/create", 
                new CreateUserCommand { Email = "test@test.fr", Pseudo = "test" }, 
                cancellationToken: TestContext.Current.CancellationToken
                );
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
