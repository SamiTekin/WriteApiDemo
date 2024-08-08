using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories.EFCore.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName);
            builder.Property(u => u.UserSurname);
            builder.Property(u => u.Email);
            builder.Property(u => u.Password);                
            builder.HasData(
                new User { Id = 1, UserName = "Sami", UserSurname = "Tekin", Email = "sami@gmail.com", Password = "1", UserRole = true },
                new User { Id = 2, UserName = "Volkan", UserSurname = "Kızılkaya", Email = "volkan@gmail.com", Password = "1", UserRole = true },
                new User { Id = 3, UserName = "Ümit", UserSurname = "Yeşiltaş", Email = "umut@gmail.com", Password = "1", UserRole = true }
            );
        }
    }
}