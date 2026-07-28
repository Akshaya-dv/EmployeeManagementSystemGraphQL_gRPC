using Grpc.Core;
using Notification;

namespace EmployeeManagement.Notification.Services
{
    public class NotificationServiceImpl : NotificationService.NotificationServiceBase
    {
        public override Task<NotificationReply> SendWelcome(
            NotificationRequest request,
            ServerCallContext context)
        {
            Console.WriteLine(
                $"Welcome email sent to {request.Name} ({request.Email})");

            return Task.FromResult(new NotificationReply
            {
                Message = "Notification Sent Successfully"
            });
        }
    }
}