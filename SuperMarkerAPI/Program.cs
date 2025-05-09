using FluentValidation;
using SuperMarkerAPI;
using SuperMarket.Application.FluentValidation.Product;
using SuperMarket.Application.MappingProfiles;
using SuperMarket.Infrastructure;
using SuperMarket.Infrastructure.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
////
builder.Services.AddValidatorsFromAssemblyContaining<AddProductValidation>();
////
builder.Services.AddInfrastructureDI(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAppDI(builder.Configuration);
var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseMiddleware<GlobalValidationExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
