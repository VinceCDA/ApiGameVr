using ApiGameVr.Application.Features.Users.Commands.Create;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ApiGameVr.Test
{
    public class AdminUserControllerTests
    {
        [Fact]
        public async Task CreatingAdminUserShouldReturnUserOk()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var requestData = new { email = "test3@test.fr", password = "Azerty12345!" };
            var response = await client.PostAsJsonAsync("/admin/register",
                requestData,
                cancellationToken: TestContext.Current.CancellationToken
                );
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            await using var application2 = new WebApplicationFactory<Program>();
            using var client2 = application2.CreateClient();
            var response2 = await client.PostAsJsonAsync("/admin/login",
                requestData,
                cancellationToken: TestContext.Current.CancellationToken
                );
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }
    }
}
