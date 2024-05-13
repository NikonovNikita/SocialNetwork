using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories;

public interface IUserRepository
{
    int Create(UserEntity userEntity);
    UserEntity FindByEmail(string email);
    IEnumerable<UserEntity> FindAll();
    UserEntity FindById(int id);
    int Update(UserEntity userEntity);
    int DeleteById(int id);
}
