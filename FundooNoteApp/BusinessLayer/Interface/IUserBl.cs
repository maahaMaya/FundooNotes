using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBl
    {
        public UserEntity RegisterUser(UserRegistration userRegistration);
        public string Login(UserLogin userLogin);
        public bool ForgotPassword(ForgotPasswordModel forgotPasswordModel);
        public bool ResetPassword(string email, PasswordResetModel passwordResetModel);
    }
}
