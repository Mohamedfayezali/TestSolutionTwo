using MediatR;
using System.Text.Json.Serialization;

namespace TestSolution.Application.Commend
{
    public class UpdateUserCommand : IRequest<Guid?>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Address { get; set; }
    }
}
