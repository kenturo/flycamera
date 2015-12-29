using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using FlyEntity;
using FlyEntity.DataAccess;
using FlyEntity.Repositry;
using FlyEntity.Utilities;

namespace Flycamera.Api
{
    public class CustomRoleProvider: RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            IRepositryCustomers<Fly_Customer> User = new CustomerDAO();
            return new String[] { this.getRoleName(User.RoleIsAdmin(username)) };
        }

        string getRoleName(bool isAdmin)
        {
            if (isAdmin)
            {
                return RoleUser.ADMIN;
            }
            else
            {
                return RoleUser.CUSTOMER;
            }

        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}