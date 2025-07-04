using Ecommerce.Infrastructure.CrossCutting.Extensions.Ioc;
using Ecommerce.Infrastructure.CrossCutting.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RavenDbSettings>(builder.Configuration.GetSection("RavenDbSettings"));
builder.Services.AddRavenDb();
builder.Services.AddControllers();
builder.Services.AddDomainServices();
builder.Services.AddMappers();
builder.Services.AddRepositories();
builder.Services.AddAplicationServices();

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
