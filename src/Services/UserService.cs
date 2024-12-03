using CrudIpcaMall.src.Data;
using CrudIpcaMall.src.DTO;
using CrudIpcaMall.src.Models;
using CrudIpcaMall.src.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudIpcaMall.src.Services
{
    public class UserService : UsersInterface
    {
        private readonly ContextOfDataBase _context;
        public UserService(ContextOfDataBase ctx){
            this._context = ctx;
        }

        public async Task<ResponseModel<UsersModel>> CreateNewUser(UsersDTO newUser)
        {
            ResponseModel<UsersModel> response = new ResponseModel<UsersModel>();
            var user = new UsersModel();
            try{
                user.Email = newUser.Email;
                user.Name = newUser.Name;
                this._context.Add(user);
                await this._context.SaveChangesAsync();

                response.Data = user;
                response.message = $"New user created\n {newUser.Email}";
                response.status = true;
                return response;
            }
            catch (Exception ex){
                Console.WriteLine($"There was something issue while we were trying to create a new User!\n {ex.Message}");
                response.status = false;
                response.message = "There was something issue while we were trying to create a new User!";
                return response;
            }
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

        public async Task<ResponseModel<UsersModel>> SearchUserById(int idUser)
        {
            ResponseModel<UsersModel> response = new ResponseModel<UsersModel>();
            try{
                var user = await this._context.users.FirstOrDefaultAsync(usr => usr.Id == idUser);
                if(user==null){
                    response.message = $"The user ID:{idUser} wasn't found";
                    response.status = false;
                    return response;
                }
                response.Data = user;
                response.message = $"The user ID:{idUser} was collected";
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
    }
}