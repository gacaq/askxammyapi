using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burguers.Askxammy.Api.Entities.Dtos
{
    /// <summary>
    /// Entidad DTO para guardar y devolver desde la api el objeto Client
    /// </summary>
    public class ClientDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
