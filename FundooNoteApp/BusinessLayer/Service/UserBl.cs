using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBl : IUserBl
    {
        IUserRl iUserRl;
        public UserBl(IUserRl iUserRl)
        {
            this.iUserRl = iUserRl;
        }

        public UserEntity RegisterUser(UserRegistration userRegistration)
        {
            try
            {
                return iUserRl.RegisterUser(userRegistration);  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
