using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

const string myCorsPolicy = "_myCorsPolicy";
const string clientHost = "https://localhost:44332";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    // CORS policy to allow call from client SPA:

    options.AddPolicy(name: myCorsPolicy,
        b =>
        {
            b.WithOrigins(clientHost)
                .AllowAnyMethod()
                .WithHeaders("authorization", "content-type");
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myCorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
