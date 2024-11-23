using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace PushNotification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        public IActionResult PushNotification([FromBody] NotificationDto dto)
        {

            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    {"Test notification","sent" }
                },
                Token = dto.FcmToken,
                Notification = new Notification()
                {
                    Title = dto.Title,
                    Body = dto.Body
                }
            };


            try
            {

                string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
