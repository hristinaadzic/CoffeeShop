﻿using CoffeeShop.DataAccess;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CoffeeShop.Api.Core
{
    public class JwtManager
    {
        private readonly Context _context;
        private readonly JwtSettings _settings;

        public JwtManager(Context context, JwtSettings settings)
        {
            _settings = settings;
            _context = context;
        }

        public string MakeToken(string email, string password)
        {
            var user = _context.Users.Include(x => x.UseCases).FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            BCrypt.Net.BCrypt.GenerateSalt(13);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var valid = BCrypt.Net.BCrypt.Verify(password, passwordHash);

            if (!valid)
            {
                throw new UnauthorizedAccessException();
            }

            var useCases = _context.UserUseCases.Where(x => x.UserId == user.Id).Select(x => x.UseCaseId);

            var actor = new JwtUser
            {
                Id = user.Id,
                UseCaseIds = user.UseCases.Select(x => x.UseCaseId).ToList(),
                Identity = user.Email,
                Email = user.Email
            };

            var claims = new List<Claim> // Jti : "",
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _settings.Issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.UseCaseIds)),
                new Claim("Email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_settings.Minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
