﻿using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;

namespace MagicVilla_VillaAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _db;
        public UserRepository(ApplicationDBContext db) 
        {
            _db = db;
        }
        public bool IsUniqueUser(string username)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            LocalUser user = new()
            {
                UserName = registerationRequestDTO.UserName,
                Password = registerationRequestDTO.Password,
                Name = registerationRequestDTO.Name,
                Role = registerationRequestDTO.Role
            };

            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
