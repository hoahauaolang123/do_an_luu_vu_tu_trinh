using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Helper.user;
using server.Interfaces;
using server.Models;
using server.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace server.Services
{
    public class ManageUserService : IManageUserService
    {
        private readonly ShopDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ManageUserService(UserManager<AppUser> userManager,ShopDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<bool> ChangeStatusUser(UserChangeStatusRequest request)
        {
            var user = await _context.Users.Where(x => x.Id == request.id).FirstOrDefaultAsync();
            user.status = request.status;
            _context.Entry(user).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async  Task<bool> CreateUser(CreateUser request)
        {
            var testUserExist = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (testUserExist == null)
            {
                var user = new AppUser()
                {
                    displayname = request.UserName,
                    Email = request.Email,
                    UserName = request.Email,
                    birthDay = DateTime.Now,
                };
                var result = await _userManager.CreateAsync(user, request.PassWord);
                if (result.Succeeded)
                {
                    var userRole = _context.Roles.FirstOrDefault(x => x.Id == Guid.Parse(request.RoleId));
                    await _userManager.AddToRoleAsync(user, userRole.Name);
                    return true;
                }
            }
            return false;
        }

        public async Task<List<UserViewModel>> GetUserDisplayList(string id)
        {
            var data = await _context.Users.Where(x => x.Id != Guid.Parse(id)).Select(y => new UserViewModel
            {
                id = y.Id,
                address = y.address,
                avatar = y.avatar,
                birthDay = y.birthDay,
                displayname = y.displayname,
                email = y.Email,
                gender = y.gender,
                Orders = y.Orders,
                phone = y.phone,
                status = y.status,
                userType = y.UserName.Contains("facebook") ? "Facebook User":"User"
            }).ToListAsync();
            return data;
        }

        public async Task<List<UserViewModel>> SearchUser(SearchUserRequest request)
        {
            var query = _context.Users.Where(x => x.Id != Guid.Parse(request.currentUserId)).AsQueryable();
            if (!string.IsNullOrEmpty(request.keyWord))
            {
                query = query.Where(x => x.displayname.ToLower().Contains(request.keyWord.ToLower()));
            }
            if(request.status != null)
            {
                query = query.Where(x => x.status == request.status);
            }
            return await query.Select(y => new UserViewModel
            {
                id = y.Id,
                address = y.address,
                avatar = y.avatar,
                birthDay = y.birthDay,
                displayname = y.displayname,
                email = y.Email,
                gender = y.gender,
                Orders = y.Orders,
                phone = y.phone,
                status = y.status,
                userType = y.UserName.Contains("facebook") ? "Facebook User" : "User"
            }).ToListAsync();
        }
    }
}
