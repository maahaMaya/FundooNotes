using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRl : IUserRl
    {
        FundooContext fundooContext;

        public UserRl(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public UserEntity RegisterUser(UserRegistration userRegistration)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = userRegistration.FirstName;
                userEntity.LastName = userRegistration.LastName;
                userEntity.Email = userRegistration.Email;
                userEntity.Password = userRegistration.Password;
                fundooContext.UserDetails.Add(userEntity);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                var result = fundooContext.UserDetails.Where(x => x.Email == userLogin.Email && x.Password == userLogin.Password).FirstOrDefault();
                if(result != null)
                {
                    return "Loging Sucessful";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
