if (typeof (TCC) == "undefined") { TCC = {} }
if (typeof (TCC.Opportunity) == "undefined") { TCC.Opportunity = {} }

TCC.Opportunity = {
    CloneOpportunityOnClick: function () {
        alert("sss");

        var execute_new_CloneOpportunity_Request = {
            entity: { entityType: "opportunity", id: Xrm.Page.data.entity.getId() }, 

            getMetadata: function () {
                return {
                    boundParameter: "entity",
                    parameterTypes: {
                        entity: { typeName: "mscrm.opportunity", structuralProperty: 5 }
                    },
                    operationType: 0, operationName: "new_CloneOpportunity"
                };
            }
        };

        Xrm.WebApi.online.execute(execute_new_CloneOpportunity_Request).then(
            function success(response) {
                if (response.ok) {
                    TCC.Opportunity.DynamicsAlert("Opportunity Clone Done!", "Opportunity Clone");
                }

                Xrm.Utility.closeProgressIndicator();
            }
        ).then(function (responseBody) {
            var result = responseBody;
            console.log(result);
            var success = result["Success"]; 
        }).catch(function (error) {
            console.log(error.message);
            Xrm.Utility.closeProgressIndicator();
        });
    },
    DynamicsAlert: function (alertText, alertTitle) {
        var alertStrings = {
            confirmButtonLaber: "OK",
            text: alertText,
            title: alertTitle
        };

        var alertOptions = {
            heigth: 120,
            width: 200
        };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
    }
}