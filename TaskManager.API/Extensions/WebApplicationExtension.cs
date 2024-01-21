namespace TaskManager.API.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication Load(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.UseHttpsRedirection();

            return app;
        }
    }
}
