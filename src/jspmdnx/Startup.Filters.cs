namespace jspmdnx
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Filters;
    using NWebsec.AspNetCore.Mvc;

    public partial class Startup
    {
        private static void ConfigureSecurityFilters(IHostingEnvironment environment,
            ICollection<IFilterMetadata> filters)
        {
            filters.Add(new XContentTypeOptionsAttribute());
            filters.Add(new XDownloadOptionsAttribute());
            filters.Add(
               new XFrameOptionsAttribute()
               {
                   Policy = XFrameOptionsPolicy.Deny
               });
        }
    }
}
