using MessageSetting.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSetting.Infra.Data
{
    public class MessageSettingDbContext : DbContext
    {
        public MessageSettingDbContext(DbContextOptions<MessageSettingDbContext> options) : base(options)
        {
        }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Contact>()
        //        .HasMany(n => n.ContactUsers)
        //        .WithOne(a => a.Contact)
        //        .HasForeignKey(x => x.ContactId);
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUser> ContactUsers { get; set; }




    }
}
