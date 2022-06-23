using RapidPay.Database;
using RapidPay.Models;

namespace RapidPay.SeedData
{
    public static class UserSeedData
    {
        public static void AddUser(RapidPayContext context)
        {
            context.User.Add(new User() { Id = 1, UserName = "admin", Password = "admin" });
            context.SaveChanges();
        }
    }
}
