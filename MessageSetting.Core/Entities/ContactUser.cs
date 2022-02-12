using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Core.Entities
{
    public class ContactUser
    {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public long UserId { get; set; }
        public long UserType { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual User User { get; set; }


    }
}
