using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

            if (!context.ApplicationStatuses.Any())
            {
                var applicationStatuses = new ApplicationStatus[]
                {
                    new ApplicationStatus{Description = "Applicantion in work"},
                    new ApplicationStatus{Description = "Application Approved"},
                    new ApplicationStatus{Description = "Business assigned to mentor"},
                    new ApplicationStatus{Description = "Mentor approved for grant review"},
                    new ApplicationStatus{Description = "Grant review in progrss"},
                    new ApplicationStatus{Description = "Business 'In Process' of using funds"},
                    new ApplicationStatus{Description = "Business in round 2+"},
                    new ApplicationStatus{Description = "Business exited from WMF"},


                };

                foreach (ApplicationStatus a in applicationStatuses)
                {
                    context.ApplicationStatuses.Add(a);
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
                    new Role{ RoleDescription="Applicant"},
                    new Role{ RoleDescription="Judge"},
                    new Role{ RoleDescription="Manager"}

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

            if (!context.ConceptStatuses.Any())
            {
                var conceptstatuses = new ConceptStatus[]
                {
                    new ConceptStatus{ConceptStatusDescription = "Concept"},
                    new ConceptStatus{ConceptStatusDescription ="Already Started" },
                };

                foreach(ConceptStatus cs in conceptstatuses)
                {
                    context.ConceptStatuses.Add(cs);
                }
                context.SaveChanges();
            }


            if (!context.BusinessStages.Any())
            {
                var businessStages = new BusinessStage[]
                {
                    new BusinessStage{BusinessStageDescription = "Ideation"},
                    new BusinessStage{BusinessStageDescription ="Pre-revenue" },
                    new BusinessStage{BusinessStageDescription ="Early Revenue" },
                    new BusinessStage{BusinessStageDescription ="Revenue Growth" }
                };
                foreach (BusinessStage bs in businessStages)
                {
                    context.BusinessStages.Add(bs);
                }
                context.SaveChanges();
            }

            if (!context.BusinessTypes.Any())
            {
                var businessTypes = new BusinessType[]
                {
                    new BusinessType{BusinessTypeDescription = "Product"},
                    new BusinessType{BusinessTypeDescription = "Service" },
                    new BusinessType{BusinessTypeDescription = "Tech" },
                };

                foreach (BusinessType bt in businessTypes)
                {
                    context.BusinessTypes.Add(bt);
                }
                context.SaveChanges();
            }


            /*
             * Old survey system
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


                        // Application Survey
                        if (false)
                        {
                            // Add a survey code

                            var surveyCode = new SurveyCode[]
                            {
                                new SurveyCode{SurveyName = "Idea Application"}

                             };
                            foreach (SurveyCode sc in surveyCode)
                            {
                                context.SurveyCodes.Add(sc);
                            }
                            context.SaveChanges();


                            var IdeaApplicationSurveyCode = (from sc in context.SurveyCodes
                                                  where sc.SurveyName == "Idea Application"
                                                  select sc).FirstOrDefault<SurveyCode>();


                            // Get the reference QuestionID 
                            int TextQuestionTypeID = context.QuestionTypes
                                   .Where(q => q.QuestionTypeName == "Text Response")
                                   .Select(q => q.ID).FirstOrDefault<int>();
                            int NumericQuestionTypeID = context.QuestionTypes
                               .Where(q => q.QuestionTypeName == "Numeric Response")
                               .Select(q => q.ID).FirstOrDefault<int>();
                            int DateQuestionTypeID = context.QuestionTypes
                               .Where(q => q.QuestionTypeName == "Date Response")
                               .Select(q => q.ID).FirstOrDefault<int>();
                            int YesOrNoQuestionTypeID = context.QuestionTypes
                               .Where(q => q.QuestionTypeName == "Yes or No Response")
                               .Select(q => q.ID).FirstOrDefault<int>();
                            int SingleSelectionQuestionTypeID = context.QuestionTypes
                               .Where(q => q.QuestionTypeName == "Single Selection Multiple Choice")
                               .Select(q => q.ID).FirstOrDefault<int>();
                            int MultipleSelectionQuestionTypeID = context.QuestionTypes
                               .Where(q => q.QuestionTypeName == "Multiple Selection Multiple Choice")
                               .Select(q => q.ID).FirstOrDefault<int>();



                            // Idea Application Questions
                            var question = new Question[]
                            {
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID, QuestionText= "What is the name of your concept", 
                                    QuestionNumber= 1, 
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID, 
                                    QuestionText= "What is the status of your concept's development?", 
                                    QuestionNumber= 2, 
                                    QuestionTypeID = SingleSelectionQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "Have you generated any sales",
                                    QuestionNumber= 3,
                                    QuestionTypeID = YesOrNoQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID, QuestionText= "If your have generated sales describe sales over the pas several months",
                                    QuestionNumber= 4,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "What is your business stage?",
                                    QuestionNumber= 5,
                                    QuestionTypeID = SingleSelectionQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID, QuestionText= "Clearly articulate your complelling business idea",
                                    QuestionNumber= 6,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "Do you have a prototype or intellectual property?",
                                    QuestionNumber= 7,
                                    QuestionTypeID = YesOrNoQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "If you have a prototype or intellectual property please explain.",
                                    QuestionNumber= 8,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "What is the business type?",
                                    QuestionNumber= 9,
                                    QuestionTypeID = SingleSelectionQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "Market opportunity (Pain/Gain) (greater than 150 words, 20%). Describe the problem (pain) your customer is experiencing or benefit (gain) that your customer is 	seeking. How significant is the problem/opportunity and how did you determined that.",
                                    QuestionNumber= 10,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "Evidence your solution is a viable business opportunity (>150 words, 15%) How does your solution satisfy the pain (problem) or gain (desire)? How did you determine this is a real problem or need for your potential customer(s) ? (Quantify) It's helpful to ask at least 10 potential customers to indicate that there is a 'legitimate' need. Please upload drawings, graphics or pictures of your proposed solution(product or service) if you have them.",
                                    QuestionNumber= 11,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "Customers (>150 words, 15%) Describe each essential customer group for your solution in terms of age, education, income, etc.Estimate the size and growth rate of each customer group.How you arrived at this number.Please provide data sources.",
                                    QuestionNumber= 12,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "Marketing & Sales (>150 words, 10%). What is your game plan for making sales? Describe and quantify the various ways you will make sales to your potential customer groups ?",
                                    QuestionNumber = 13,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "Business Costs (>150 words, 10%). What Start-up and ongoing costs do you expect? (Name and amount)",
                                    QuestionNumber = 14,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "Competition (>150 words, 10%). Name and describe other businesses that are competing for your customers' attention and dollars. Why do they have a competitive advantage? What are their weaknesses? What sets your product/ service apart from other choices(Differentiation)?",
                                    QuestionNumber = 15,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "You and Your Team (.150 words, 20%) Describe your current team and their relevant experience What essential skills are you missing? What experiences do you have that demonstrate that you can do this.",
                                    QuestionNumber= 16,
                                    QuestionTypeID = TextQuestionTypeID},
                                new Question{
                                    SurveyCodeID = IdeaApplicationSurveyCode.ID,
                                    QuestionText= "Your Specific Request (>150 words)How much, for what, and when will you complete this activity ?",
                                    QuestionNumber= 17,
                                    QuestionTypeID = TextQuestionTypeID}

                            };
                            foreach (Question q in question)
                            {
                                context.Add(q);
                            }
                            context.SaveChanges();

                            var choices = new Choice[]
                           {
                                // What is the capital of Assyria                    
                                new Choice{ChoiceText = "Ideation - Formation (process of creating team and formulating idea)", QuestionID = question[1].ID},
                                new Choice{ChoiceText = "Pre-revenue - company formed, team working to create prototype product or service", QuestionID = question[1].ID},
                                new Choice{ChoiceText = "Early Revenue (<$10,000)", QuestionID = question[1].ID},
                                new Choice{ChoiceText = "Revenue Growth (>$10,000)", QuestionID = question[1].ID},
                                new Choice{ChoiceText = "Product", QuestionID = question[4].ID},
                                new Choice{ChoiceText = "Service", QuestionID = question[4].ID},
                                new Choice{ChoiceText = "Tech", QuestionID = question[4].ID},


                           };
                            foreach (Choice c in choices)
                            {
                                context.Add(c);

                            }
                            context.SaveChanges();

                        }
            */





        }
    }
}
