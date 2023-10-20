using Crop_Dealer.Model;
using Crop_Dealer.Repository;
using Crop_Dealer.Repository.AdminUser;
using Crop_Dealer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CropDealContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
#region dependency
//repository dependency
builder.Services.AddScoped<ISendEmail, SendEmail>();
builder.Services.AddScoped<IAllDealer, AllDealer>();
builder.Services.AddScoped<IAllFarmer, AllFarmer>();
builder.Services.AddScoped<IDeleteFarmer, Deletefarmers>();
builder.Services.AddScoped<IDeleteDealer, Deletedealer>();
builder.Services.AddScoped<IDeleteBankDetails,DeleteBankDetails>();
builder.Services.AddScoped<IDealerRepo, DealerRepo>();
builder.Services.AddScoped<IFarmerRepo, FarmerRepo>();
builder.Services.AddScoped<ILogin_Reg, Login_Reg>();
builder.Services.AddScoped<IInvoiceRepo, InvoiceRepo>();
builder.Services.AddScoped<ICropRepository,CropRepository>();
builder.Services.AddScoped<IAdminRepo,AdminRepo>();

//services dependency
builder.Services.AddScoped<AdminServices,AdminServices>();
builder.Services.AddScoped<AuthenticationServices,AuthenticationServices>();
builder.Services.AddScoped<DealerServices, DealerServices>();
builder.Services.AddScoped<FarmerServices,FarmerServices>();
#endregion


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "RATH DEALERS", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
