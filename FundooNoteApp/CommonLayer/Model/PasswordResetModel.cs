using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class PasswordResetModel
    {
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
