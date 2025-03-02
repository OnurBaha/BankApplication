using BankingCreditSystem.Application.Features.Auth.Dtos;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Security;
using MediatR;
using System.Security;

namespace BankingCreditSystem.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;

        public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(u => u.Email == request.Email);
            if (user == null)
                throw new SecurityException("User not found.");

            // Burada şifre doğrulaması yapılmalı (hash kontrolü)
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                throw new SecurityException("Invalid password.");

            var token = await _tokenHelper.CreateToken(user);

            return new LoginResponse
            {
                AccessToken = token,
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role
            };
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
} 