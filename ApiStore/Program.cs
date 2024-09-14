
using System.Reflection;
using ApiStore.DTOs;
using ApiStore.Models;
using Microsoft.EntityFrameworkCore;

using ApiStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ApiStore.Endponits;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<OnlineShopContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopConnection"))
);

builder.Services.AddDbContext<OnlineShopContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopConnection"))
    );


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/* PRODUCTO */

app.MapGet(
    "/api/products/",
    () =>
    {
        return "Lista de Productos";
    }
);

app.MapGet(
    "/api/products/{id}",
    (int id) =>
    {
        return $"Buscando producto con el Id: {id}";
    }
);

app.MapPost(
    "/api/products/",
    (ProductRequest product) =>
    {
        return $"Guardando producto con el  CategoriaId: {product.CategoriaId}";
    }
);

app.MapPut(
    "/api/products/{id}",
    (int id, ProductRequest product) =>
    {
        return $"Modificando producto con el Id: {id}";
    }
);

app.MapDelete(
    "/api/products/{id}",
    (int id) =>
    {
        return $"Eliminando producto con el Id: {id}";
    }
);

/* CATEGORIA */

app.MapGet(
    "/api/categories/",
    () =>
    {
        return "Lista de Categorias";
    }
);

app.MapGet(
    "/api/categories/{id}",
    (int id) =>
    {
        return $"Buscando Categoria con el Id: {id}";
    }
);

app.MapPost(
    "/api/categories/",
    (CategoryRequest category) =>
    {
        return $"Guardando categoria con el  CategoriaId: {category}";
    }
);

app.MapPut(
    "/api/categories/{id}",
    (int id, CategoryRequest category) =>
    {
        return $"Modificando categoria con el Id: {id}";
    }
);

app.MapDelete(
    "/api/categories/{id}",
    (int id) =>
    {
        return $"Eliminando categoria con el Id: {id}";
    }
);

/* ORDERDETAIL */

//app.MapGet(
//    "/api/orderDetails/",
//    () =>
//    {
//        return "Lista de detalle de ordenes";
//    }
//);

//app.MapGet(
//    "/api/orderDetails/{id}",
//    (int id) =>
//    {
//        return $"Buscando detalle de ordenes con el Id: {id}";
//    }
//);

//app.MapPost(
//    "/api/orderDetails/",
//    (OrderDetailRequest orderDetail) =>
//    {
//        return $"Guardando detalle de ordenes con el  Id: {orderDetail}";
//    }
//);

//app.MapPut(
//    "/api/orderDetails/{id}",
//    (int id, OrderDetailRequest orderDetail) =>
//    {
//        return $"Modificando detalle de ordenes con el Id: {id}";
//    }
//);

//app.MapDelete(
//    "/api/orderDetails/{id}",
//    (int id) =>
//    {
//        return $"Eliminando detalle de ordenes con el Id: {id}";
//    }
//);

app.UseEndpoints();

app.Run();
