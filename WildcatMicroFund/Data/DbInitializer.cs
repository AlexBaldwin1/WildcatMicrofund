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
            


            if (!context.Businesses.Any())
            {
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

            }
            if (!context.Ethnicities.Any())
            {

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

            }

            if (!context.Genders.Any())
            {
                // Genders not created
                //Gender
                var gender = new Gender[]
                {
                    new Gender{Description="Male"},
                    new Gender{Description="Female"},
                    new Gender{Description="Prefer to self-identify"},
                    new Gender{Description="Transgender"},
                    new Gender{Description="Non-Binary"},
                    new Gender{Description="Other"}

                };
                foreach (Gender g in gender)
                {
                    context.Genders.Add(g);
                }
                context.SaveChanges();
            }




            if (!context.Users.Any())
            {
                // Users
                var users = new User[]
    {
                new User{Email="billy@gmail.com",FirstName="William",LastName="Thorton",PhoneNumber="555-555-5123",EthnicityID=1,StreetAddress="1234 fake street",City="Shelbyville",State="Illinois",Zip="00123", GenderID=1}
    };

                foreach (User u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
            }

            var user1 = (from u in context.Users
                         where u.FirstName == "William"
                         select u).First<User>();
            var business1 = (from b in context.Businesses
                             where b.BusinessName == "Billy's Burgers"
                             select b).FirstOrDefault<Business>();

            if (!context.UserBusinesses.Any())
            {
                //No connection between the business and user
               
                // UserBusinesses
                var userBusinesses = new UserBusiness[]
                {
                    new UserBusiness{BusinessID = business1.ID,Business = business1, UserID = user1.ID, User = user1}
                };

                foreach (UserBusiness ub in userBusinesses)
                {
                    context.UserBusinesses.Add(ub);
                };
                context.SaveChanges();



                // User Roles
                /*var userRoles = new UserRole[]
                {
                    new UserRole{ID=user1.ID, RoleDescription="Admin"}
                 };
                foreach (UserRole ur in userRoles)
                {
                    context.UserRoles.Add(ur);
                }
                context.SaveChanges();*/

            }

            if (!context.Roles.Any())
            {
                // Roles
                var roles = new Role[]
                {
                    new Role{ RoleDescription="Admin"},
                    new Role{ RoleDescription="Intern"},
                    new Role{ RoleDescription="Mentor"},
                    new Role{ RoleDescription="Applicant"}

                 };
                foreach (Role r in roles)
                {
                    context.Roles.Add(r);
                }
                context.SaveChanges();


                // User Roles
                var userRoles = new UserRole[]
                {
                    new UserRole{User=user1, Role=roles[0]}
                 };
                foreach (UserRole ur in userRoles)
                {
                    context.UserRoles.Add(ur);
                }
                context.SaveChanges();

            }



            if (!context.Surveys.Any())            
            {

                // Add a survey code

                var surveyCode = new SurveyCode[]
                {
                    new SurveyCode{SurveyName = "Test Survey"}

                 };
                foreach (SurveyCode sc in surveyCode)
                {
                    context.SurveyCodes.Add(sc);
                }
                context.SaveChanges();

                
                var testSurveyCode = (from sc in context.SurveyCodes
                                      where sc.SurveyName == "Test Survey"
                                      select sc).FirstOrDefault<SurveyCode>();
                var survey = new Survey[]
                {
                    new Survey {SurveyCodeID = testSurveyCode.ID}
                };
                foreach (Survey s in survey)
                {
                    context.Surveys.Add(s);
                }
                context.SaveChanges();


                // QuestionTypes here
                var questionType = new QuestionType[]
                {
                    new QuestionType{QuestionTypeName = "Text Response"},
                    new QuestionType{QuestionTypeName = "Numeric Response"},
                    new QuestionType{QuestionTypeName = "Date Response"},
                    new QuestionType{QuestionTypeName = "Yes or No Response"},
                    new QuestionType{QuestionTypeName = "Single Selection Multiple Choice", QuestionTypeHasChoices = true },
                    new QuestionType{QuestionTypeName = "Multiple Selection Multiple Choice", QuestionTypeHasChoices = true }
                };
                foreach (QuestionType q in questionType)
                {
                    context.Add(q);
                }
                context.SaveChanges();

                // Question Types
                var question = new Question[]
                {
                    new Question{SurveyCodeID = testSurveyCode.ID, QuestionText= "What is your quest?", QuestionNumber= 1, QuestionTypeID = questionType[0].ID},
                    new Question{SurveyCodeID = testSurveyCode.ID, QuestionText= "What is the airspeed velocity of an unladen swallow?", QuestionNumber= 2, QuestionTypeID = questionType[1].ID},
                    new Question{SurveyCodeID = testSurveyCode.ID, QuestionText= "When was Monty Python and the Holy Grail Released?", QuestionNumber= 3, QuestionTypeID = questionType[2].ID},
                    new Question{SurveyCodeID = testSurveyCode.ID, QuestionText= "Are you on a quest", QuestionNumber= 4, QuestionTypeID = questionType[3].ID},
                    new Question{SurveyCodeID = testSurveyCode.ID, QuestionText= "What is the capital of Assyria in 705-612 BC?", QuestionNumber= 5, QuestionTypeID = questionType[4].ID},
                    new Question{SurveyCodeID = testSurveyCode.ID, QuestionText= "What are your favorite color?s", QuestionNumber= 6, QuestionTypeID = questionType[5].ID}
                };
                foreach (Question q in question)
                {
                    context.Add(q);
                }
                context.SaveChanges();

                // Choices
                var choices = new Choice[]
                {
                    // What is the capital of Assyria                    
                    new Choice{ChoiceText = "Nineveh", QuestionID = question[4].ID},
                    new Choice{ChoiceText = "Kalhu", QuestionID = question[4].ID},
                    new Choice{ChoiceText = "Harran", QuestionID = question[4].ID},
                    new Choice{ChoiceText = "Mesoptamia", QuestionID = question[4].ID},
                    new Choice{ChoiceText = "Blue", QuestionID = question[5].ID},
                    new Choice{ChoiceText = "Green", QuestionID = question[5].ID},
                    new Choice{ChoiceText = "Red", QuestionID = question[5].ID},
                    new Choice{ChoiceText = "Yellow", QuestionID = question[5].ID},
                    new Choice{ChoiceText = "Purple", QuestionID = question[5].ID},
                    new Choice{ChoiceText = "Teal", QuestionID = question[5].ID}

                };
                foreach(Choice c in choices)
                {
                    context.Add(c);

                }
                context.SaveChanges();                   
                   
             }









        }
    }
}
