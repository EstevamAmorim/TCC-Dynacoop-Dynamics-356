using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;


namespace Models.Models
{
    public class Opportunity
    {
        public IOrganizationService Service { get; set; }
        public string LogicalName = "opportunity";

        public Opportunity(IOrganizationService service)
        {
            this.Service = service;
        }

        public void Clone(Guid opportunityId)
        {
            QueryExpression retrieveOpportunityWithProducts = new QueryExpression(this.LogicalName);
            retrieveOpportunityWithProducts.ColumnSet.AddColumns("name", "parentcontactid", "parentaccountid", "purchasetimeframe", 
                                                                 "transactioncurrencyid", "budgetamount", "purchaseprocess", "msdyn_forecastcategory", 
                                                                 "description", "currentsituation", "customerneed", "proposedsolution");
            retrieveOpportunityWithProducts.Criteria.AddCondition("opportunityid", ConditionOperator.Equal, opportunityId);

            Entity opportunity = Service.RetrieveMultiple(retrieveOpportunityWithProducts).Entities.FirstOrDefault();
            Entity clonedOpportunity = new Entity(this.LogicalName);

            clonedOpportunity["name"] = opportunity["name"];
            clonedOpportunity["parentcontactid"] = opportunity["parentcontactid"];
            clonedOpportunity["parentaccountid"] = opportunity["parentaccountid"];
            clonedOpportunity["purchasetimeframe"] = opportunity["purchasetimeframe"];
            clonedOpportunity["transactioncurrencyid"] = opportunity["transactioncurrencyid"];
            clonedOpportunity["budgetamount"] = opportunity["budgetamount"];
            clonedOpportunity["purchaseprocess"] = opportunity["purchaseprocess"];
            clonedOpportunity["msdyn_forecastcategory"] = opportunity["msdyn_forecastcategory"];
            clonedOpportunity["description"] = opportunity["description"];
            clonedOpportunity["currentsituation"] = opportunity["currentsituation"];
            clonedOpportunity["customerneed"] = opportunity["proposedsolution"];

            this.Service.Create(clonedOpportunity);
        }

        
    }
}
