using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WildcatMicroFund.Data.Context;
using WildcatMicroFund.Data.Models;

namespace WildcatMicroFund.Data
{
    public class DbInitializer
    {
        public static void Initialize(WildcatMicroFundDatabaseContext context)
        {
            context.Database.EnsureCreated();
            //context.Businesses.Remove((from b in context.Businesses select b).FirstOrDefault<Business>());

            if (context.Users.Any())
            {
                // Database is created return
                return;
            }


            // Businesses
            var businesses = new Business[]
            {
                new Business {BusinessName="Billy's Burgers"}
            };

            foreach (Business b in businesses)
            {
                context.Businesses.Add(b);
            }
            context.SaveChanges();


            //Ethicity
            var ethicity = new Ethnicity[]
            {
                new Ethnicity{EthnicityDescription="African American/Black"},
                new Ethnicity{EthnicityDescription="Asian"},
                new Ethnicity{EthnicityDescription="Pacific Islander"},
                new Ethnicity{EthnicityDescription="White"},
                new Ethnicity{EthnicityDescription="Hispanic/Latinx"},
                new Ethnicity{EthnicityDescription="Alaskan Native"},
                new Ethnicity{EthnicityDescription="Prefer not to share"}

            };
            foreach (Ethnicity e in ethicity)
            {
                context.Ethnicities.Add(e);
            }
            context.SaveChanges();

            // Users
            var users = new User[]
{
                new User{Email="billy@gmail.com",FirstName="William",LastName="Thorton",PhoneNumber="555-555-5123",EthnicityID=1,StreetAddress="1234 fake street",City="Shelbyville",State="Illinois",Zip="00123"}
};

            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            // Get the ids that were created to connect them together.
            var user1 = (from u in context.Users
                        where u.FirstName == "William"
                        select u).First<User>();
            var business1 = (from b in context.Businesses
                            where b.BusinessName == "Billy's Burgers"
                            select b).FirstOrDefault<Business>();


            // UserBusinesses
            var userBusinesses = new UserBusiness[]
            {
                new UserBusiness{BusinessID = business1.ID, UserID = user1.ID}
            };

            foreach(UserBusiness ub in userBusinesses)
            {
                context.UserBusinesses.Add(ub);
            };
            context.SaveChanges();


            // User Roles
            var userRoles = new UserRole[]
            {
                new UserRole{ID=user1.ID, RoleDescription="Admin"}
             };
            foreach (UserRole ur in userRoles)
            {
                context.UserRoles.Add(ur);
            }
            context.SaveChanges();

            



        }
    }
}
