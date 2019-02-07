using CollectionApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Restier.Providers.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Query;

namespace CollectionApp.App_Start
{

    public class AppRestierApi : EntityFrameworkApi<ApplicationDbContext>
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

        #region Auto-completion of the fields Creation, LastUpdate, LastUpdateUser

        protected void OnInsertingAccount(Account model)
        {
            model.Creation = DateTime.UtcNow;
            model.LastUpdateUser = HttpContext.Current.User.Identity.Name;
            model.LastUpdate = DateTime.UtcNow;
        }

        protected void OnInsertingCashCentre(CashCentre model)
        {
            model.Creation = DateTime.UtcNow;
            model.LastUpdateUser = HttpContext.Current.User.Identity.Name;
            model.LastUpdate = DateTime.UtcNow;
        }

        protected void OnInsertingCashPoint(CashPoint model)
        {
            model.Creation = DateTime.UtcNow;
            model.LastUpdateUser = HttpContext.Current.User.Identity.Name;
            model.LastUpdate = DateTime.UtcNow;
        }

        protected void OnInsertingCity(City model)
        {
            model.Creation = DateTime.UtcNow;
            model.LastUpdateUser = HttpContext.Current.User.Identity.Name;
            model.LastUpdate = DateTime.UtcNow;
        }

        protected void OnInsertingClient(Client model)
        {
            model.Creation = DateTime.UtcNow;
            model.LastUpdateUser = HttpContext.Current.User.Identity.Name;
            model.LastUpdate = DateTime.UtcNow;
        }

        protected void OnUpdatingClientTocc(ClientTocc model)
        {
            model.Creation = DateTime.UtcNow;
            model.LastUpdateUser = HttpContext.Current.User.Identity.Name;
            model.LastUpdate = DateTime.UtcNow;
        }

        protected void OnInsertingCurrency(Currency model)
        {
            model.Creation = DateTime.UtcNow;
            model.LastUpdateUser = HttpContext.Current.User.Identity.Name;
            model.LastUpdate = DateTime.UtcNow;
        }

        protected void OnInsertingDenomination(Denomination model)
        {
            model.Creation = DateTime.UtcNow;
            model.LastUpdateUser = HttpContext.Current.User.Identity.Name;
            model.LastUpdate = DateTime.UtcNow;
        }

        protected void OnInsertingTests(Test model)
        {
            model.Date = DateTime.UtcNow;
        }

        protected void OnInsertingClisubfml(Clisubfml model)
        {
            model.Creation = DateTime.UtcNow;
            model.LastUpdate = DateTime.UtcNow;
            model.LastUpdateUser = HttpContext.Current.User.Identity.Name;
        }

        #endregion

        protected void OnDeleteClientTocc(ClientTocc model)
        {
            var cashPoints = model.CashPoints;
            var accounts = model.Accounts;
        }
    }
}