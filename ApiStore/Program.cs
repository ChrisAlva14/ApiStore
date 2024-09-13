<<<<<<< HEAD
using System.Reflection;
using ApiStore.DTOs;
using ApiStore.Models;
using Microsoft.EntityFrameworkCore;
=======
using ApiStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
>>>>>>> 5e183b8 (cambios servicios order detail)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
builder.Services.AddDbContext<OnlineShopContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopConnection"))
);
=======
builder.Services.AddDbContext<OnlineShopContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopConnection"))
    );
>>>>>>> 5e183b8 (cambios servicios order detail)

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

app.Run();
