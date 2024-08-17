using System.Text.Json;
using ChatterBox.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace ChatterBoxTests.Controllers
{
    public class TestUserController
    {
        [Fact]
        public async Task Post_RegisterUser_OnSuccess_ReturnStatusCode200()
        {

            //Arrange
            var userController = new UserController();
            var httpContext = new DefaultHttpContext();
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "UserAuthToken.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            using (JsonDocument doc = JsonDocument.Parse(jsonContent))
            {
                string token = doc.RootElement.GetProperty("token").GetString();
                httpContext.Request.Headers["Authentication"] = "Bearer " + token; //Add Users Auth Token for Testing.

                //Act
                var result = (OkObjectResult) await userController.Register();

                //Assert
                result.StatusCode.Should().Be(200);
            }
        }
    }
}
