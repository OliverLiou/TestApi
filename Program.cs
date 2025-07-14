var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger at https://aka.ms/aspnet/swagger
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

