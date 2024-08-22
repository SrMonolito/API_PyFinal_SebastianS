using API_PyFinal_SebastianS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//se agrega el codigo que permite la inyeccion de la cadena de conexiom contenida en appsettings.json

//1. Obtenemos el valor de la cadena de conexion en appsettings
var CnnStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CnnStr"));
//2. Como en la cadena de conexion se elimino el password lo vamos a incluir en el codigo fuente
CnnStrBuilder.Password = "PyFinal";
//3. Creamos un string con la info de la cadena de conexion
string cnnStr = CnnStrBuilder.ConnectionString;
//4. Se asigna el valor de la cadena de conexion al DbContext que esta en models
builder.Services.AddDbContext<ProyectoProgra6Context>(options => options.UseSqlServer(cnnStr));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
