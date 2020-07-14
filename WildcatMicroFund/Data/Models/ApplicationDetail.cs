using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WildcatMicroFund.Data.Context;
using WildcatMicroFund.Data.Models;


namespace WildcatMicroFund.Data.Models
{
    public class ApplicationDetail
    {

        
        public int ID { get; set; }
        
        [DisplayName("The name of your concept.")]
        public string Concept { get; set; }
        
        [DisplayName("The status of your concept.")]
        public int ConceptStatusID { get; set; }
        public ConceptStatus ConceptStatus { get; set; }

        [DisplayName("Have you generated any Sales?")]
        public bool SalesGenerated { get; set; }

        [DisplayName("If your have generated sales describe sales over the past several months")]
        public string SalesGeneratedInformation { get; set; }

        [DisplayName("What is your business stage?")]
        public int BusinessStageID { get; set; } 
        public BusinessStage BusinessStage { get; set; }

        [DisplayName("Concept: Clearly articulate your compelling business idea")]
        public string BusinessIdeaDescription { get; set; }
        
        [DisplayName("Do you have a prototype or intellectual property?")]
        public bool HasPrototypeOrIntellectualProperty { get; set; }

        [DisplayName("If you have prototype or intellectual property please explain.")]
        public string PrototypeDescription { get; set; }

        [DisplayName("Business type")]
        public int BusinessTypeID { get; set; }
        public BusinessType BusinessType { get; set; }
        
        [DisplayName("Market Opportunity (Pain/Gain) (> 150 words, 20%). Describe the problem(pain) your customer is experiencing or benefit(gain) that your customer is seeking. How significant is the problem / opportunity and how did you determined that.")]
        public string MarketOpportunity { get; set; }

        [DisplayName("Evidence your solution is a viable business opportunity (>150 words, 15%) How does your solution satisfy the pain (problem) or gain (desire)? How did you determine this is a real problem or need for your potential customer(s) ? (Quantify) It's helpful to ask at least 10 potential customers to indicate that there is a 'legitimate' need. Please upload drawings, graphics or pictures of your proposed solution(product or service) if you have them.")]
        public string EvidenceOfViableOpportunity { get; set; }

        [DisplayName("Customers (>150 words, 15%) Describe each essential customer group for your solution in terms of age, education, income, etc.Estimate the size and growth rate of each customer group.How you arrived at this number.Please provide data sources.")]
        public string CustomerDescription { get; set; }

        [DisplayName("Marketing & Sales (>150 words, 10%). What is your game plan for making sales? Describe and quantify the various ways you will make sales to your potential customer groups ?")]
        public string MarketingAndSales { get; set; }

        [DisplayName("Business Costs (>150 words, 10%). What Start-up and ongoing costs do you expect? (Name and amount)")]
        public string BusinessCosts{ get; set; }

        [DisplayName("Competition (>150 words, 10%). Name and describe other businesses that are competing for your customers' attention and dollars. Why do they have a competitive advantage? What are their weaknesses? What sets your product/ service apart from other choices(Differentiation)?")]
        public string  CompetitionDescription{ get; set; }

        [DisplayName("You and Your Team (.150 words, 20%) Describe your current team and their relevant experience What essential skills are you missing? What experiences do you have that demonstrate that you can do this.")]
        public string TeamDescription { get; set; }

        [DisplayName("Your Specific Request (>150 words)How much, for what, and when will you complete this activity ?")]
        public string SpecificRequest { get; set; }
    }
}
