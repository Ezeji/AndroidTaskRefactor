using ShellLoginSample.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellLoginSample.Repository
{
    public interface IAuthentication
    {
        string SignupUser(RegisterUser registerUser);
        string LoginUser(LoginUser loginUser);
    }
}
