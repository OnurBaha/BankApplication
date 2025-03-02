using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Security.Entities;
using System.Security.Cryptography;
using System.Text;
using BankingCreditSystem.Application.Features.Auth.Dtos;
using BankingCreditSystem.Core.Security;
using System.Security;

namespace BankingCreditSystem.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisterResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } = "Customer"; // Varsayılan olarak Customer

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;

        public RegisterCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Email kontrolü
            var existingUser = await _userRepository.GetAsync(u => u.Email == request.Email);
            if (existingUser != null)
                throw new SecurityException("Email already exists.");

            // Şifre hash'leme
            byte[] passwordSalt, passwordHash;
            CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            // Yeni kullanıcı oluşturma
            var user = new User(
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                role: request.Role,
                passwordSalt: passwordSalt,
                passwordHash: passwordHash
            );

            // Kullanıcıyı kaydetme
            var createdUser = await _userRepository.AddAsync(user);

            // Token oluşturma
            var token = await _tokenHelper.CreateToken(createdUser);

            return new RegisterResponse
            {
                AccessToken = token,
                UserId = createdUser.Id,
                Email = createdUser.Email,
                Role = createdUser.Role
            };
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
} 