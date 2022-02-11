﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Core.Entities
{
    public class Contact
    {

        
        public long Id { get; set; }
        public string? PhoneNo { get; set; }
        public string? Name { get; set; }
        public List <ContactUser>? ContactUsers { get; set; }
      

    }
}
