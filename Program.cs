var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger at https://aka.ms/aspnet/swagger
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath); // 啟用 XML 註解檔案
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "課程管理系統 API",
        Version = "v1",
        Description = "提供課程與學生的 CRUD 功能"
    });
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "課程管理系統 API v1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

