﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTO.Author
{
    public class AuthorCreateDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Bio { get; set; }
    }
}
