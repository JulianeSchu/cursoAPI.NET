using JornadaAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DepoimentosConnection");

builder.Services.AddDbContext<JornadaContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("Jornada",
        policy =>
        {
            policy.WithOrigins("https://www.figma.com/proto/1qD4hmpnvxoeHRC1cbWKgR/Angular_-Componentizac%CC%A7a%CC%83o-e-Design-com-Angular-Material-_-Jornada-Milhas?type=design&node-id=4-6408&scaling=min-zoom&page-id=0%3A1")
            .AllowAnyHeader().AllowAnyMethod();
            });
});

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
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

app.UseCors("Jornada");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
