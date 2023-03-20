using IydeParfume.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IydeParfume.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
               .ToTable("Users");

            //builder
            //.HasOne(u => u.Basket)
            //  .WithOne(b => b.User)
            //    .HasForeignKey<Basket>(u => u.UserId);
        }
    }
}
