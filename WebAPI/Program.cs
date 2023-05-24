global using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json.Serialization;
using Grpc.Net.Client;
using gRPCWebSocket;
using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Services.ConfigService;
using WebAPI.WebAPI.Services.NoteService;
using WebAPI.WebAPI.Services.ReadingService;
using WebAPI.WebAPI.Services.UserService;
using WebAPI.WebSocket.LogicImpl;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
// http://*:80
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IReadingService, ReadingService>();
builder.Services.AddScoped<IConfigService, ConfigService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
        options.HttpsPort = 443;
    });
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();


app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");

// Grpc


//172.17.0.2 -> Docker
//140.82.33.21 -> localhost
WebSocketLogicImpl webSocketLogicImpl = new WebSocketLogicImpl("http://localhost:4242");

app.Run();