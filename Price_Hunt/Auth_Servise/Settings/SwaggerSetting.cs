namespace Auth_Servise.Settings
{
    public class SwaggerSetting
    {
        public static void AddConfig(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Auth Servis",
                Contact = new OpenApiContact
                {
                    Name = "JustKaneri",
                    Url = new Uri("https://github.com/JustKaneri")
                }
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        }
    }
}
