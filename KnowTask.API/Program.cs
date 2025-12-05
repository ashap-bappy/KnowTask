using KnowTask.SharedInfra.Mediator;
using User.API;
using User.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddControllers();

// Add mediator
builder.Services.AddAppMediator();

// Add modules Controllers and Services
builder.Services.AddUserApi(builder.Configuration) // add controllers/endpoints
                .ConfigureUserDependencyInjection(builder.Configuration); // configure dependency injection
    
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

app.UseAuthorization();

app.MapControllers();

app.Run();
