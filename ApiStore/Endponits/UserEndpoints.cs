using ApiStore.DTOs;
using ApiStore.Services.Users;
using Microsoft.OpenApi.Models;

namespace ApiStore.Endponits
{
    public static class UserEndpoints
    {
        public static void Add(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/users").WithTags("Usuarios");

            // GET all Users
            group
                .MapGet(
                    "/",
                    async (IUserServices userServices) =>
                    {
                        var users = await userServices.GetUsers();
                        return Results.Ok(users);
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "OBTENER USUARIOS",
                    Description = "MUESTRA UNA LISTA DE TODOS LOS USUARIOS",
                });

            // GET user by ID
            group
                .MapGet(
                    "/{id}",
                    async (int id, IUserServices userServices) =>
                    {
                        var user = await userServices.GetUser(id);
                        return user is not null ? Results.Ok(user) : Results.NotFound();
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "OBTENER UN USUARIO POR ID",
                    Description = "OBTIENE UN USUARIO DADO SU ID",
                });

            // POST create a new user
            group
                .MapPost(
                    "/",
                    async (UserRequest user, IUserServices userServices) =>
                    {
                        var createdUserId = await userServices.PostUser(user);
                        return Results.Created($"api/users/{createdUserId}", user);
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "CREAR NUEVO USUARIO",
                    Description = "CREA UN NUEVO USUARIO CON LOS DATOS PROPORCIONADOS",
                });

            // PUT modified a new User
            group
                .MapPut(
                    "/{id}",
                    async (int id, UserRequest user, IUserServices userServices) =>
                    {
                        var isUpdated = await userServices.PutUser(id, user);

                        if (isUpdated == -1)
                            return Results.NotFound();
                        else
                            return Results.Ok(user);
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "MODIFICAR UN USUARIO",
                    Description = "ACTUALIZA UN USUARIO DADO SU ID",
                });

            // DELETE product by ID
            group
                .MapDelete(
                    "/{id}",
                    async (int id, IUserServices userServices) =>
                    {
                        var result = await userServices.DeleteUser(id);
                        if (result == -1)
                            return Results.NotFound();
                        else
                            return Results.NoContent();
                    }
                )
                .WithOpenApi(o => new OpenApiOperation(o)
                {
                    Summary = "ELIMINAR UN USUARIO",
                    Description = "ELIMINAR UN USUARIO DADO SU ID",
                });
        }
    }
}
