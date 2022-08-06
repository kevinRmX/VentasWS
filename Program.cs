var builder = WebApplication.CreateBuilder(args);
String MiCors = "MiCors";
// Add services to the container.
builder.Services.AddCors(options =>
{
    
    options.AddPolicy(name: MiCors,
        builder =>
        {
        builder.WithHeaders("*");
            builder.WithOrigins("*");
            builder.WithMethods("*");
        });
});
builder.Services.AddControllers();
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

app.UseCors(MiCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
