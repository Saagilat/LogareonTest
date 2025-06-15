using Task1.Services.Interfaces;
using Task1.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов в контейнер DI
builder.Services.AddControllers();
builder.Services.AddSingleton<IReportBuilder, ReportBuilder>();
builder.Services.AddSingleton<IReporter, Reporter>();
builder.Services.AddSingleton<ReportService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// После var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers();

app.Run();