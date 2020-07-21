using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellLoginSample.Repository
{
    public interface IRegisterUsersDB
    {
        SQLiteConnection DbConnection();
    }
}
