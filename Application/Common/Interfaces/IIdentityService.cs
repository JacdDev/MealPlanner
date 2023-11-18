using ErrorOr;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        public Task<ErrorOr<Guid>> CreateUserAsync(string username, string password);
    }
}
