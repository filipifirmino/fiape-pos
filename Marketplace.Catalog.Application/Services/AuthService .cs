using System.Security.Authentication;
using Marketplace.Catalog.Application.interfaces;
using Marketplace.Catalog.Domain.Dtos;
using Marketplace.Catalog.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Marketplace.Catalog.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly ILogger<AuthService> _logger;

    // Simulação de senhas - em produção seria hash + salt
     private readonly Dictionary<string, string> _passwords = new()
    {
        { "admin", "admin123" },
        { "user", "user123" }
    };
    public AuthService (ITokenService tokenService, ILogger<AuthService> logger)
    {
        _tokenService = tokenService;
        _logger = logger;
    }
    public async Task<LoginResponse> AuthenticateAsync(LoginRequest request)
    {
        try
        {
            _logger.LogInformation("Tentativa de autenticação para usuário: {Username}", request.Email);

            if (!ValidateCredentials(request.Email, request.Password))
            {
                _logger.LogWarning("Credenciais inválidas para usuário: {Username}", request.Email);
                return null;
            }

            var user = new User{Email = "teste@teste.com", FirstName = "Teste da silva"}; // Buscar usuario na base
            var token = _tokenService.GenerateToken(user);
            var expirationMinutes = 60; // Configurável via appsettings

            var response = new LoginResponse
            {
                Token = token,
                Username = user.FirstName,
                ExpiresIn = expirationMinutes * 60, // em segundos
                ExpiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes)
            };

            _logger.LogInformation("Usuário autenticado com sucesso: {Username}", request.Email);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro durante autenticação do usuário: {Username}", request.Email);
            throw new AuthenticationException("Erro interno durante autenticação");
        }
    }

    public bool ValidateCredentials(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return false;

        return _passwords.TryGetValue(username, out var storedPassword) && 
               storedPassword == password;
    }

    public async Task<User> ValidateTokenAsync(string token)
    {
        try
        {
            return await _tokenService.ValidateTokenAsync(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro durante validação do token");
            return null;
        }
    }
}
