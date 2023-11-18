using Application.Common.Interfaces;
using Domain.UserAggregation;
using ErrorOr;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<Guid>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }

        public async Task<ErrorOr<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUserResult = await _identityService.CreateUserAsync(request.Email, request.Password);

            if (createUserResult.IsError)
            {
                return createUserResult;
            }

            _context.Users.Add(new User(createUserResult.Value, request.Email));

            _context.SaveChanges();

            return createUserResult;
        }
    }
}
