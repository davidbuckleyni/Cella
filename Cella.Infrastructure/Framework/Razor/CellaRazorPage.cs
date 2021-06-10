using Cella.Infrastructure.Framework.Localization;
using Cella.Infrastructure.Interface.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Infrastructure.Framework
{
    public abstract class CellaRazorPage<TModel> : Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
    {
        private ILocalizationService _localizationService;
        private Localizer _localizer;




        /// <summary>
        /// Get a localized resources
        /// </summary>
        public Localizer T
        {
            get
            {


                if (_localizer == null)
                {
                    _localizer = (format, args) =>
                    {
                        var resFormat = _localizationService.GetResourceAsync(format).Result;
                        if (string.IsNullOrEmpty(resFormat))
                        {
                            return new LocalizedString(format);
                        }
                        return new LocalizedString((args == null || args.Length == 0)
                            ? resFormat
                            : string.Format(resFormat, args));
                    };
                }
                return _localizer;
            }
        }

    }


    /// <summary>
    /// Web view page
    /// </summary>
    public abstract class CellaRazorPage : CellaRazorPage<dynamic>
    {
    }
}
