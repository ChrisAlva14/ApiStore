using ApiStore.DTOs;
using ApiStore.Services.OrderDetails;
using ApiStore.Services.Products;
using Microsoft.OpenApi.Models;

namespace ApiStore.Endpoints
{
    public static class ProductEndpoints
    {
        public static void Add(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/products").WithTags("Productos");

            // GET all products
            group
                .MapGet(
                    "/",
                    async (IProductServices productServices) =>
                    {
                        var products = await productServices.GetProducts();
                        return Results.Ok(products);
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "OBTENER PRODUCTOS",
                    Description = "MUESTRA UNA LISTA DE TODOS LOS PRODUCTOS",
                });

            // GET product by ID
            group
                .MapGet(
                    "/{id}",
                    async (int id, IProductServices productServices) =>
                    {
                        var product = await productServices.GetProduct(id);
                        return product is not null ? Results.Ok(product) : Results.NotFound();
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "OBTENER PRODUCTO POR ID",
                    Description = "OBTIENE UN PRODUCTO DADO SU ID",
                });

            // POST create a new product
            group
                .MapPost(
                    "/",
                    async (ProductRequest product, IProductServices productServices) =>
                    {
                        var createdProductId = await productServices.PostProduct(product);
                        return Results.Created($"api/products/{createdProductId}", product);
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "CREAR NUEVO PRODUCTO",
                    Description = "CREA UN NUEVO PRODUCTO CON LOS DATOS PROPORCIONADOS",
                });

            // PUT modified a new product
            group
                .MapPut(
                    "/{id}",
                    async (int id, ProductRequest product, IProductServices productServices) =>
                    {
                        var isUpdated = await productServices.PutProduct(id, product);

                        if (isUpdated == -1)
                            return Results.NotFound(); // 404 Not Found: El recurso solicitado no existe
                        else
                            return Results.Ok(product); // 200 OK: La solicitud se realizó correctamente y devuelve el detalle de ordenes
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "MODIFICAR PRODUCTO",
                    Description = "ACTUALIZA UN PRODUCTO DADO SU ID",
                });

            // DELETE product by ID
            group
                .MapDelete(
                    "/{id}",
                    async (int id, IProductServices productServices) =>
                    {
                        var result = await productServices.DeleteProduct(id);
                        if (result == -1)
                            return Results.NotFound(); // 404 Not Found: El recurso solicitado no existe
                        else
                            return Results.NoContent(); // 204 No Content: Recurso Eliminado.
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "ELIMINAR PRODUCTO",
                    Description = "ELIMINAR UN PRODUCTO DADO SU ID",
                });
        }
    }
}
