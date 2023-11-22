using System;
using System.Collections.Generic;
namespace GoraYazilim.Entity;

public partial class DtoUser 
{
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserMail { get; set; }

        public string UserPassword { get; set; }

        public string UserRole { get; set; }
    }

