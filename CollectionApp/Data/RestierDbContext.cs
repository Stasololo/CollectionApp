using CollectionApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Restier.Providers.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.OData.Query;

namespace CollectionApp.Data
{
    public class RestierDbContext : EntityFrameworkApi<ApplicationDbContext>
    {
        protected override IServiceCollection ConfigureApi(IServiceCollection services)
        {
            Func<IServiceProvider, ODataValidationSettings> validationSettingFactory = sp => new ODataValidationSettings
            {
                MaxAnyAllExpressionDepth = 6,
                MaxExpansionDepth = 6
            };

            return base.ConfigureApi(services)
                .AddSingleton(validationSettingFactory);
        }

        //protected void OnInsertingRiskOwners(RiskOwners riskOwners)
        //{
        //    riskOwners.ApplicationEntity = new ApplicationEntity()
        //    {
        //        ApplicationEntityHistories = new List<ApplicationEntityHistory>()
        //        {

        //        }
        //    };

        //    riskOwners.ApplicationEntity.ApplicationEntityHistories.Add(new ApplicationEntityHistory()
        //    {
        //        DataState = new DataState()
        //        {
        //            CreatedBy = Thread.CurrentPrincipal.Identity.Name,
        //            CreatedOn = ConvertTo(DateTime.Now)
        //        }
        //    });

        //    riskOwners.DataState = new DataState()
        //    {
        //        CreatedBy = Thread.CurrentPrincipal.Identity.Name,
        //        CreatedOn = ConvertTo(DateTime.Now)
        //    };
        //}

    }
}