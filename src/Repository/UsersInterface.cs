using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudIpcaMall.src.DTO;
using CrudIpcaMall.src.Models;

namespace CrudIpcaMall.src.Repository
{
    public interface UsersInterface
    {
        Task<ResponseModel<List<UsersModel>>> ListarUsers();
        Task<ResponseModel<UsersModel>> SearchUserById(int idUser);
        Task<ResponseModel<UsersModel>> CreateNewUser(UsersDTO newUser);
    }
}