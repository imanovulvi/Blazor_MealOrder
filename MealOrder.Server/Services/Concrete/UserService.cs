using AutoMapper;
using Meal.Shared.DTOs;
using Meal.Shared.Tools;
using MealOrder.Server.Services.Abstractions;
using MealOrder.ServerData.Context;
using MealOrder.ServerData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace MealOrder.Server.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly MealContext context;
        private readonly IConfiguration configuration;

        public UserService(IMapper mapper, MealContext context, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.context = context;
            this.configuration = configuration;
        }
        public async Task CreateAsync(UserDTO userDTO)
        {
            await context.Users.AddAsync(mapper.Map<User>(userDTO));
            await context.SaveChangesAsync();
        }



        public async Task<bool> DeleteAsync(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
                throw new Exception("Melumat tapilmadi");

            context.Users.Remove(user);
            return await context.SaveChangesAsync() > 0;
        }



        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsAktiv);
            if (user is null)
                throw new Exception("Melumat tapilmadi");

            return mapper.Map<UserDTO>(user);
        }



        public List<UserDTO> GetAllList()
        {
            var user = context.Users.Where(x => x.IsAktiv).ToList();
            if (user is null)
                throw new Exception("Melumat tapilmadi");

            return mapper.Map<List<UserDTO>>(user);
        }

        public async Task UpdateAsync(UserDTO userDTO)
        {
            context.Users.Update(mapper.Map<User>(userDTO));
            await context.SaveChangesAsync();
        }

        public async Task<UserLoginResponseDTO> LoginAsync(UserLoginRequestDTO requestDTO)
        {
            EncriptionPassword encription = new EncriptionPassword();

            User user = await context.Users.FirstOrDefaultAsync(x => x.Email == requestDTO.Email && x.Password == encription.Password(requestDTO.Password));
            if (user is null)
                throw new Exception("Sifre ve ya password yanlis");
            List<Claim> clamis = new List<Claim> {
                new Claim("Id",user.Id.ToString()),
            new Claim("Email",user.Email),
            new Claim("Name",user.Name)
            };


            JwtSecurityToken jwtSecurity = new JwtSecurityToken(
                issuer: configuration["JWTBearer:ValidIssuer"],
                audience: configuration["JWTBearer:ValidAudience"],
                expires: DateTime.Now.AddDays(int.Parse(configuration["JWTBearer:Expire"])),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTBearer:Key"])), SecurityAlgorithms.HmacSha256),
              claims: clamis
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            UserLoginResponseDTO userLoginResponse = new UserLoginResponseDTO();
            userLoginResponse.Token = handler.WriteToken(jwtSecurity);
            userLoginResponse.User = mapper.Map<UserDTO>(user);

            return userLoginResponse;
        }
    }
}
