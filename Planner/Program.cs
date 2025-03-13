using Planner.Infra.Data.Data;
using Planner.Infra.IoC.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Conex�o com o banco de dados
builder.Services.AddDbContextConfig(builder.Configuration);

// Inje��o de depend�ncias
builder.Services.AddDependencyInjectorConfig();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

{
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<PlannerDbContext>();
    dbContext.Database.EnsureCreated();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
