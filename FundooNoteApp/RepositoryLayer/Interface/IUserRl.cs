using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRl
    {
        public UserEntity RegisterUser(UserRegistration userRegistration);
        public string Login(UserLogin userLogin);
        public bool ForgotPassword(ForgotPasswordModel forgotPasswordModel);
        public bool ResetPassword(string email, PasswordResetModel passwordResetModel);
    }
}
