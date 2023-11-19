using ErrorOr;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        public Task<ErrorOr<Guid>> CreateUserAsync(Guid id, string userName, string password);
    }
}
