using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudIpcaMall.src.Data;
using CrudIpcaMall.src.Models;
using CrudIpcaMall.src.Repository;
using Microsoft.EntityFrameworkCore;

namespace CrudIpcaMall.src.Services
{
    public class UserService : UsersInterface
    {
        private readonly ContextOfDataBase _context;
        public UserService(ContextOfDataBase ctx){
            this._context = ctx;
        }
        public async Task<ResponseModel<List<UsersModel>>> ListarUsers()
        {
            ResponseModel<List<UsersModel>> response = new ResponseModel<List<UsersModel>>();
            try{
                var users = await this._context.users.ToListAsync();
                response.Data = users;
                response.message = "All users were collected";
                response.status = true;
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was something issue!\n {ex.Message}");
                response.status = false;
                response.message = "There was something issue!";
                return response;
            }
        }

        public Task<ResponseModel<UsersModel>> SearchUserById(int idUser)
        {
            throw new NotImplementedException();
        }
    }
}