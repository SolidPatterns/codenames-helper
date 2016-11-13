using System;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNamesHelper.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleType Role { get; set; }
    }
}
