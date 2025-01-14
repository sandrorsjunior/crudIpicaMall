using CrudIpcaMall.src.Data;
using CrudIpcaMall.src.DTO;
using CrudIpcaMall.src.Models;
using CrudIpcaMall.src.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudIpcaMall.src.Services
{
    public class UserService : UsersInterface
    {
        private readonly ContextOfDataBase _context;
        public UserService(ContextOfDataBase ctx)
        {
            this._context = ctx;
        }

        public async Task<ResponseModel<UsersModel>> CreateNewUser(UsersCreateDTO user)
        {
            ResponseModel<UsersModel> response = new ResponseModel<UsersModel>();
            var newUser = new UsersModel();

            try
            {


                newUser.Name = user.Name;
                newUser.Email = user.Email;
                newUser.Birthday = user.Birthday;
                newUser.Role = user.Role;

                await this._context.AddAsync(newUser);
                await this._context.SaveChangesAsync();

                var newRegister = new RegistersModel
                {
                    _dateCreation = DateTime.UtcNow,
                    UserId = newUser.Id,
                    Users = newUser,
                    task = "creation_new_user"
                };

                var PasswordEncryptation = new EncryptionsModel
                {
                    Password = user.Password,
                    Salt = user.Salt,
                    UserId = newUser.Id,
                    UsersModel = newUser
                };

                await this._context.AddAsync(PasswordEncryptation);
                await this._context.AddAsync(newRegister);
                await this._context.SaveChangesAsync();

                response.Data = newUser;
                response.message = $"New user created\n {user.Email}";
                response.status = true;
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was something issue while we were trying to create a new User!\n {ex.Message}");
                response.status = false;
                response.message = "There was something issue while we were trying to create a new User!";
                return response;
            }
        }

        public async Task<ResponseModel<List<UsersModel>>> ListarUsers()
        {
            ResponseModel<List<UsersModel>> response = new ResponseModel<List<UsersModel>>();
            try
            {
                var users = await this._context.users.Include(u => u.userRegister).Include(p => p.Password).ToListAsync();
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
            try
            {
                var user = await this._context.users.FirstOrDefaultAsync(usr => usr.Id == idUser);
                if (user == null)
                {
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

        public async Task<ResponseModel<EncryptedDataDTO>> Login(LoginDTO login)
        {
            ResponseModel<EncryptedDataDTO> response = new ResponseModel<EncryptedDataDTO>();

            try
            {
                var user = await this._context.users.FirstOrDefaultAsync(usr => usr.Email == login.email);
                if (user == null)
                {
                    response.message = $"The user:{login.email} wasn't found";
                    response.status = false;
                    return response;
                }

                var encrypt = await this._context.encryptions.FirstOrDefaultAsync(en => en.UserId == user.Id);

                if (encrypt == null)
                {
                    response.message = $"The Password wasn't found";
                    response.status = false;
                    return response;
                }
                
                var enryptDataResponse = new EncryptedDataDTO();
                enryptDataResponse.userId = user.Id;
                enryptDataResponse.email = user.Email;
                enryptDataResponse.salt = encrypt.Salt;
                enryptDataResponse.password = encrypt.Password;

                response.Data = enryptDataResponse;
                response.message = $"The user:{login.email} was collected";
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