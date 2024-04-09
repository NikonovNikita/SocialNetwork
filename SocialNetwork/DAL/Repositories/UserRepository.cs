using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories;

internal class UserRepository : BaseRepository, IUserRepository
{
    public int Create(UserEntity userEntity)
    {
        return Execute(@"insert into users (firstname,lastname,password,email)
                                        values (:firstname,:lastname,:password,:email)", userEntity);
    }

    public int DeleteById(int id)
    {
        return Execute("delete from users where id = :id_p", new {id_p = id});
    }

    public IEnumerable<UserEntity> FindAll()
    {
        return Query<UserEntity>("select * from users");
    }

    public UserEntity FindByEmail(string email)
    {
        return QueryFirstOrDefault<UserEntity>("select * from users where email = :email_p", new {email_p = email});
    }

    public UserEntity FindById(int id)
    {
        return QueryFirstOrDefault<UserEntity>("select * from user where id = :id_p", new {id_p = id});
    }

    public int Update(UserEntity userEntity)
    {
        return Execute(@"update users set firstname = :firstname, lastname = :lastname, password = :password, email = :email,
        photo = :photo, favourite_movie = :favourite_movie, favourite_book = :favourite_book", userEntity);
    }
}
