using Aplication.Interfaces.IApplicationStatusType;
using Aplication.Interfaces.ICategory;
using Aplication.Interfaces.IClient;
using Aplication.Interfaces.IExperience;
using Aplication.Interfaces.IOffer;
using Aplication.Interfaces.IOfferCategory;
using Aplication.Interfaces.IStudyLevel;
using Aplication.UseCase.Services.SApplicationStatusType;
using Aplication.UseCase.Services.SCategory;
using Aplication.UseCase.Services.SClient;
using Aplication.UseCase.Services.SExperience;
using Aplication.UseCase.Services.SOffer;
using Aplication.UseCase.Services.SOfferCategory;
using Aplication.UseCase.Services.SStudyLevel;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Infrastructure.Client;
using Infrastructure.Command;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IOfferCommand, OfferCommand>();
builder.Services.AddScoped<IOfferQuery, OfferQuery>();
builder.Services.AddScoped<IOfferQueryServices, OfferQueryServices>();
builder.Services.AddScoped<IOfferCommandServices, OfferCommandServices>();

builder.Services.AddScoped<ICategoryQuery, CategoryQuery>();
builder.Services.AddScoped<ICategoryQueryServices, CategoryQueryServices>();

builder.Services.AddScoped<IExperienceQuery, ExperienceQuery>();
builder.Services.AddScoped<IExperienceQueryServices, ExperienceQueryServices>();

builder.Services.AddScoped<IStudyLevelQuery, StudyLevelQuery>();
builder.Services.AddScoped<IStudyLevelQueryServices, StudyLevelQueryServices>();

builder.Services.AddScoped<IApplicationStatusTypeQuery, ApplicationStatusTypeQuery>();
builder.Services.AddScoped<IApplicationStatusTypeQueryServices, ApplicationStatusTypeQueryServices>();

builder.Services.AddScoped<IOfferCategoryCommand, OfferCategoryCommand>();
builder.Services.AddScoped<IOfferCategoryQuery, OfferCategoryQuery>();
builder.Services.AddScoped<IOfferCategoryCommandServices, OfferCategoryCommandServices>();
builder.Services.AddScoped<IOfferCategoryQueryServices, OfferCategoryQueryServices>();

builder.Services.AddScoped<IClientGeorefArApiServices, ClientGeorefArApiServices>();

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IClientGeorefArApi, ClientGeorefArApi>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
