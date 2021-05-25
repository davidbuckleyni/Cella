using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

using Cella.Models;
using NToastNotify;
using SharedResourceLib.Lng;
using Microsoft.AspNetCore.Http;
using Cella.Models.ViewModels;
using Cella.BL;
using System.Text;
using WarehouseCrm.Web.Helpers;
using Microsoft.Extensions.Configuration;
using Cella.Domain;
using Cella.Models.Permissions;

namespace Warehouse.Web.Controllers {
    public class BaseController : Controller {

        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> roleManager;
        private IHttpContextAccessor _httpContextAccessor;
        private CellaDBContext _context;
        private WarehouseBL _warehouseBL;
        private readonly IToastNotification _toast;
        private readonly IConfiguration _config;

        public enum NotificationType {
            error,
            success,
            warning,
            info
        }
        public BaseController(CellaDBContext context ,IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;

            roleManager = roleMgr;
            _context = context;
            _toast = toast;
            _userManager = userManager;
            _config = config;

            _warehouseBL = new WarehouseBL();
            GetUserId();
            GetApplicationUser();
            SetStoreId();
            SetupThemeCookie();

        }
        public void SetupThemeCookie()
        {
            try
            {
                IEnumerable<string> values;

                
                _httpContextAccessor.HttpContext.Request.Headers.Add("cookie", "theme=Default");
              
                _httpContextAccessor.HttpContext.Response.Headers.Add("theme","frontend");
            }catch(Exception)
            {


            }


        }
        protected new internal ViewResult View()
        {
            base.View();
            var rd = this.RouteData;
            string currentController = rd.Values["controller"].ToString();
            string currentAction = rd.Values["action"].ToString();
            string themeName = _config["Theme"];

            var viewName = ThemeViewExtensions.GetViewPath(currentController, currentAction,themeName);

            return base.View(viewName, (object)null);

        }

        public Guid StoreId { get; set; }
        public void SetStoreId()
        {
            StoreId = new Guid("5E7ACB67-39F5-46CA-903A-0C5A16320BCD");
        }
        public void Alert(string message, NotificationType notificationType) {
            var msg = "<script language='javascript'>swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
            TempData["notification"] = msg;
        }
        public ApplicationUser AppUser { get; set; }
        public void GetApplicationUser()
        {

            if (_httpContextAccessor.HttpContext.User.Identity.Name != null)
            {
                AppUser = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result;

                 
            }

        }
        public Guid UserId { get; set; }


        
        public List<CellaUserPermmissions> UserHasPermssions(string permissionListcommaSep,string controllerName)
        {

            var permissionsList = _context.CellaUserPermmissions.Where(w=>w.UserId==UserId.ToString() && w.isAcitve==true && w.isDeleted==false).ToList();
            CustomErrorViewModel hasValidPermissions = _warehouseBL.UserHasValidPermissions(permissionsList, permissionListcommaSep, controllerName, "");

            return hasValidPermissions.Permissions;
            

        }
        protected void GetUserId()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.Name != null)
            {
                var userId = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result.Id;

                Guid.TryParse(userId, out Guid userIdResult);
                UserId = userIdResult;
            }

        }

        /// <summary>
        /// Sets the information for the system notification.
        /// </summary>
        /// <param name="message">The message to display to the user.</param>
        /// <param name="notifyType">The type of notification to display to the user: Success, Error or Warning.</param>
        public void Message(string message, NotificationType notifyType) {
            TempData["Notification2"] = message;

            switch (notifyType) {
                case NotificationType.success:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;
                case NotificationType.error:
                    TempData["NotificationCSS"] = "alert-box errors";
                    break;
                case NotificationType.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;

                case NotificationType.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }
    }
}
