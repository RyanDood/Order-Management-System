using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.entity
{
    internal class Users
    {
        int userId;
        string username;
        string password;
        string role;

        public Users(int userId, string username, string password,string role)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public int UserID
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }

        public override string ToString()
        {
            return $"User ID::{UserID}\t User Name::{UserName}\t Password::{Password}\t Role::{Role}\t";
        }
    }
}
