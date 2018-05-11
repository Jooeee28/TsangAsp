using System.Collections.Generic;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo
{
    public class ManageUsersViewModel
    {
        public IEnumerable<ApplicationUser> Administrators { get; set; }
        public IEnumerable<ApplicationUser> Everyone { get; set; }
    }
}