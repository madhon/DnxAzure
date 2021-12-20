namespace jspmdnx
{
    public static class SecurityHeadersExtensions
    {
        public static IApplicationBuilder AddCustomSecurityHeaders(this IApplicationBuilder app)
        {
            var policyCollection = new HeaderPolicyCollection()
                .AddDefaultSecurityHeaders()
                .AddContentSecurityPolicy(p =>
                {
                    p.AddScriptSrc()
                        .Self()
                        .UnsafeInline()
                        .From("https://unpkg.com")
                        .From("https://ajax.googleapis.com")
                        .From("https://cdnjs.cloudflare.com")
                        .WithNonce()
                        .WithHashTagHelper();


                    p.AddStyleSrc() // style-src 'self' 'strict-dynamic'
                        .Self()
                        .StrictDynamic()
                        .From("https://unpkg.com")
                        .From("https://code.getmdl.io")
                        .From("https://fonts.googleapis.com")
                        .From("https://maxcdn.bootstrapcdn.com")
                        .From("https://cdnjs.cloudflare.com")
                        .WithNonce()
                        .WithHashTagHelper();
                });
            
            app.UseSecurityHeaders(policyCollection);
            
            return app;
        }


    }
}
