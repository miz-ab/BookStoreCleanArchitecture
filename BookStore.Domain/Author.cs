using BookStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class Author : BaseDomainEntity
    {  
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Bio { get; set; }
    }
}
