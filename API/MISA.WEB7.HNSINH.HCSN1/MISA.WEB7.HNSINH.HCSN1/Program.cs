using MISA.WEB7.HNSINH.HCSN1.BL;
using MISA.WEB7.HNSINH.HCSN1.DL;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFixedAssetBL, FixedAssetBL>();
builder.Services.AddScoped<IFixedAssetDL, FixedAssetDL>();
builder.Services.AddScoped<IDepartmentBL, DepartmentBL>();
builder.Services.AddScoped<IDepartmentDL, DepartmentDL>();
builder.Services.AddScoped<IFixedAssetCategoryBL, FixedAssetCategoryBL>();
builder.Services.AddScoped<IFixedAssetCategoryDL, FixedAssetCategoryDL>();
builder.Services.AddScoped(typeof(BaseBL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*");
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));

var app = builder.Build();

//app cors
app.UseCors("corsapp");
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
