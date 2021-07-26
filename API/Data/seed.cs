using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class seed
    {
        public static async Task seedusers(DataContext context){
            if(await context.Users.AnyAsync()) return;

            var userData=await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users=JsonSerializer.Deserialize<List<AppData>>(userData);
            foreach(var user in users)
            {
                using var hmac=new HMACSHA512();
                user.username=user.username.ToLower();
                user.passwordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.passwordSalt=hmac.Key;
                context.Users.Add(user);
            }
        await context.SaveChangesAsync();
        }
         
    }
}