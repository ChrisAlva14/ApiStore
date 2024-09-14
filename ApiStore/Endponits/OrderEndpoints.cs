using ApiStore.DTOs;
using ApiStore.Services.orders;
using Microsoft.OpenApi.Models;

namespace ApiStore.Endponits
{
    public static class OrderEndpoints
    {
        public static void Add(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/orders").WithTags("orders");

            // Obtener todos los pedidos
            group.MapGet("/", async (IOrderServices orderServices) =>
            {
                var orders = await orderServices.GetOrder();
                return Results.Ok(orders); // 200 OK: La solicitud se realizó correctamente y devuelve la lista de pedidos
            })
            .WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Obtener Pedidos",
                Description = "Muestra una lista de todos los pedidos."
            });

            // Obtener un pedido por ID
            group.MapGet("/{id}", async (int id, IOrderServices orderServices) =>
            {
                var order = await orderServices.GetOrder(id);
                if (order == null)
                    return Results.NotFound(); // 404 Not Found: El recurso solicitado no existe
                else
                    return Results.Ok(order); // 200 OK: La solicitud se realizó correctamente y devuelve el pedido
            })
            .WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Obtener Pedido por ID",
                Description = "Busca un pedido por su ID."
            });

            // Crear un nuevo pedido
            group.MapPost("/", async (OrderRequest order, IOrderServices orderServices) =>
            {
                if (order == null)
                    return Results.BadRequest(); // 400 Bad Request: La solicitud no se pudo procesar

                var id = await orderServices.PostOrder(order);
                return Results.Created($"/api/orders/{id}", order); // 201 Created: El recurso se creó con éxito
            })
            .WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Crear Pedido",
                Description = "Crea un nuevo pedido."
            });

            // Actualizar un pedido existente
            group.MapPut("/{id}", async (int id, OrderRequest order, IOrderServices orderServices) =>
            {
                var result = await orderServices.PutOrder(id, order);
                if (result == -1)
                    return Results.NotFound(); // 404 Not Found: El recurso solicitado no existe
                else
                    return Results.Ok(order); // 200 OK: La solicitud se realizó correctamente y devuelve el pedido actualizado
            })
            .WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Actualizar Pedido",
                Description = "Actualiza un pedido existente."
            });

            // Eliminar un pedido
            group.MapDelete("/{id}", async (int id, IOrderServices orderServices) =>
            {
                var result = await orderServices.DeleteOrder(id);
                if (result == -1)
                    return Results.NotFound(); // 404 Not Found: El recurso solicitado no existe
                else
                    return Results.NoContent(); // 204 No Content: Recurso Eliminado
            })
            .WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Eliminar Pedido",
                Description = "Elimina un pedido existente."
            });
        }

    }
}
