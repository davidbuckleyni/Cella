using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Cella.Models.ViewModels;
using Cella.BL;
using Cella.Domain;

namespace WarehouseCrm.Web.Attribute
{

    public class AuthorizeActionFilter : Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    {

        List<CutomError> _customError;
        WarehouseBL _warehouseBL;
        public enum PermissionsEnum
        {
            Create,
            Update,
            Delete,
            View

        }
        private static readonly string[] _emptyArray = new string[0];

        private readonly string _permission;

        public AuthorizeActionFilter(string permission)
        {
            _permission = permission;
            _customError = new List<CutomError>();
            _warehouseBL = new WarehouseBL();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var routes = context.HttpContext.GetRouteData();

            bool isAuthorized = CheckUserPermission(context.HttpContext.User, _permission, context);

            if (!isAuthorized)
            {
                CustomErrorViewModel vm = new CustomErrorViewModel();
                vm.Errors = _customError;
                context.Result = new Microsoft.AspNetCore.Mvc.RedirectToActionResult("Error", "Home", _customError);

            }
        }

        private bool CheckUserPermission(ClaimsPrincipal user, string permission, AuthorizationFilterContext context)
        {
            // Logic for checking the user permission goes here. 
            bool isAuthorized = false;
            var controllerName = context.RouteData.Values["Controller"].ToString();
            var actionMethod = context.RouteData.Values["Action"].ToString();
            var db = context.HttpContext.RequestServices.GetRequiredService<CellaDBContext>();

            CustomErrorViewModel hasValidPermissions = _warehouseBL.UserHasValidPermissions(db.CellaUserPermmissions.ToList(), permission, controllerName, actionMethod);
            return hasValidPermissions.isAuthorized;
        }
    }

}

