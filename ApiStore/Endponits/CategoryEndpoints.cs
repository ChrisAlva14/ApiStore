using ApiStore.DTOs;
using ApiStore.Services.Categories;
using Microsoft.OpenApi.Models;

namespace ApiStore.Endponits
{
    public static class CategoryEndpoints
    {
        public static void Add(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/categories").WithTags("Categorias");

            group
                .MapGet(
                    "/",
                    async (ICategoryServices categoryServices) =>
                    {
                        var categories = await categoryServices.GetCategorys();
                        return Results.Ok(categories);
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "OBTENER CATEGORÍAS",
                    Description = "MUESTRA UNA LISTA DE TODOS LAS CATEGORÍAS",
                });

            group
                .MapGet(
                    "/{id}",
                    async (int id, ICategoryServices categoryServices) =>
                    {
                        var category = await categoryServices.GetCategory(id);
                        return category is not null ? Results.Ok(category) : Results.NotFound();
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "OBTENER UNA CATEGORÍA POR ID",
                    Description = "OBTIENE UNA CATEGORÍA DADO SU ID",
                });

            group
                .MapPost(
                    "/",
                    async (CategoryRequest category, ICategoryServices categoryServices) =>
                    {
                        var createdCategoryId = await categoryServices.PostCategory(category);
                        return Results.Created($"/api/categories{createdCategoryId}", category);
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "CREAR UNA NUEVA CATEGORÍA",
                    Description = "CREA UNA NUEVA CATEGORÍA CON LOS DATOS PROPORCIONADOS",
                });

            group
                .MapPut(
                    "/{id}",
                    async (int id, CategoryRequest category, ICategoryServices categoryServices) =>
                    {
                        var isUpdated = await categoryServices.PutCategory(id, category);

                        if (isUpdated == -1)
                            return Results.NotFound();
                        else
                            return Results.Ok(category);
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "MODIFICAR UNA CATEGORÍA",
                    Description = "ACTUALIZA UNA CATEGORÍA DADO SU ID",
                });

            group
                .MapDelete(
                    "/{id}",
                    async (int id, ICategoryServices categoryServices) =>
                    {
                        var result = await categoryServices.DeleteCategory(id);
                        if (result == -1)
                            return Results.NotFound();
                        else
                            return Results.NoContent();
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "ELIMINAR UNA CATEGORÍA",
                    Description = "ELIMINAR UNA CATEGORÍA DADO SU ID",
                });
        }
    }
}
