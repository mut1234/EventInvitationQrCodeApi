using EventInvitationQrCodeApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EventInvitationQrCodeApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasData(
                    new User { UserId = 1, Name = "Ahmad", PhoneNumber = "079649321763", Email = "Ahmad3323@gmail.com", Address = "St 124", City = "Amman"},
                    new User { UserId = 2, Name = "Ali", PhoneNumber = "07964421763", Email = "Ali3323@gmail.com", Address = "St 1324", City = "Amman"},
                    new User { UserId = 3, Name = "Yaser", PhoneNumber = "079649351763", Email = "Yaser4323@gmail.com", Address = "St 1214", City = "Amman"},
                    new User { UserId = 4, Name = "khaled", PhoneNumber = "079649521763", Email = "khaled4323@gmail.com", Address = "St 1244", City = "Amman"},
                    new User { UserId = 5, Name = "mhmod", PhoneNumber = "079649321763", Email = "mhmod4323@gmail.com", Address = "St 1224", City = "Amman"},
                    new User { UserId = 6, Name = "mustafa", PhoneNumber = "079149321762", Email = "mustafa4323@gmail.com", Address = "St 1264", City = "Amman"}
                    );



            // many to many between Event and User - the user have many Event , each Event for many user.
            modelBuilder.Entity<User>()
         .HasMany(e => e.Event)
         .WithMany(e => e.User)
         .UsingEntity<UserEvent>(
             l => l.HasOne<Event>(e => e.Event).WithMany(e => e.UserEvent).HasForeignKey(e => e.UserId),
             r => r.HasOne<User>(e => e.User).WithMany(e => e.UserEvent).HasForeignKey(e => e.UserId));


            //one to many between user and QrCode - the user have many QrCode , each QrCode for 1 user.
            modelBuilder.Entity<User>()
                .HasMany(e => e.QrCode2)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.QrCode_User_Id);



        }

    }
}
