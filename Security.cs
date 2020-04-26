using System;
using System.Collections.Generic;
using System.Text;

namespace TechNetWikiProxyDesignPattern
{
    /// <summary>
    /// Stub class to represent the current authenticated user - in an asp.net application this can be retrieved using IHttpAccessor
    /// </summary>
    internal static class Security
    {
        public static User CurrentUser;
    }

    internal class User
    {
        public string UserName { get; set; }
        public Role Role { get; set; }
    }

    internal enum Role
    {
        Admin,
        User
    }
}
