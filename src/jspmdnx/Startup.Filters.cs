namespace jspmdnx
{
    using System.Collections.Generic;
    using Microsoft.AspNet.Hosting;
    using Microsoft.AspNet.Mvc.Filters;
    using NWebsec.Mvc.HttpHeaders;

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
