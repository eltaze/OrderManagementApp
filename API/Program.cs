using API;
using API.Hcon;

var builder = WebApplication.CreateBuilder(args);

RegistrationServices.ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapHub<ConHub>("/Connection");
app.MapControllers();
app.Run();

