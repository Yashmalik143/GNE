using AutoMapper;
using DataAccess.Context;
using DataAccess.DataAccessRepo;
using DataAccess.Helper;
using DataAccess.IDataAcces;
using Microsoft.EntityFrameworkCore;
using Services.Mapper;
using Services.ServicesInterface;
using Services.ServicesRepo;
using System.Collections.Generic;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataAccess.Context.GneProjectContext>(options => options.UseSqlServer(builder.
   Configuration.GetConnectionString("DefaultConnection")
, dbOpt => dbOpt.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));

IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<ICurrencServices, CurrencyServices>();
builder.Services.AddScoped<ICurrency,CurrencyRepo>();
builder.Services.AddScoped<ICategoryTypeServices, CategoryTypeServices>();
builder.Services.AddScoped<ICategory, CategoryRepo>();
builder.Services.AddScoped<ICounterPartyServices, CounterPartyServices>();
builder.Services.AddScoped<ICounterParty, CounterPartyRepo>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddScoped<IThresholdServices, ThresholdServices>();
builder.Services.AddScoped<IThreshold, ThresholdRepo>();
builder.Services.AddScoped<IGnEReceivedServices, GnEReveicedServices>();
builder.Services.AddScoped<IGnEReceived, GnEReceived>();
builder.Services.AddTransient<IGnEGiven, GnEGiven>();
builder.Services.AddTransient<IGnEGivenServices, GnEGivenServices>();
builder.Services.AddTransient<IHelper, HelperRepo>();
builder.Services.AddTransient<IApprovalDetailService, AprovalDetailsServices>();
builder.Services.AddTransient<IApprovalDetail, ApprovalDetailRepo>();
builder.Services.AddTransient<IApprovalLevel, ApprovalLevelRepo>();

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
