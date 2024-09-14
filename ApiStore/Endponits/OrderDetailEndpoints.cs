using ApiStore.DTOs;
using ApiStore.Models;
using ApiStore.Services.OrderDetails;
using ApiStore.Services.Products;
using Microsoft.OpenApi.Models;

namespace ApiStore.Endponits
{
    public static class OrderDetailEndpoints
    {
        public static void Add(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/orderDetails").WithTags("orderDetails");

            group.MapGet("/", async (IOrderDetailServices orderDetailServices) => {
                var orderDetails = await orderDetailServices.GetOrderDetails();
                // 200 OK: La solicitud se realizó correctamente
                // Y devuelve la lista de detalle de ordenes
                return Results.Ok(orderDetails);
            })
            .WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Obtener Detalle de Ordenes",
                Description = "Muestra una lista de todos los detalles de ordenes."
            });

            group.MapGet("/{id}", async (int id, IOrderDetailServices OrderDetailServices) => {
                var orderDetail = await OrderDetailServices.GetOrderDetail(id);
                if (orderDetail == null)
                    return Results.NotFound(); // 404 Not Found: El recurso solicitado no existe
                else
                    return Results.Ok(orderDetail); // 200 OK: La solicitud se realizó correctamente y devuelve el detalle de ordenes

            }).WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Obtener Detalle de Ordenes",
                Description = "Busca un detalle de ordenes por id."
            });

            group.MapPost("/", async (OrderDetailRequest orderDetail, IOrderDetailServices orderDetailServices) =>
            {
                if (orderDetail == null)
                    return Results.BadRequest(); // 400 Bad Request: La solicitud no se pudo procesar, error de formato

                var id = await orderDetailServices.PostOrderDetail(orderDetail);
                // 201 Created: El recurso se creó con éxito, se devuelve la ubicación del recurso creado
                return Results.Created($"/api/orderDetails/Id", orderDetail);
            }).WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Crear Detalle de Ordenes",
                Description = "Crear un nuevo detalle de ordenes."
            });


            group.MapPut("/{id}", async (int id, OrderDetailRequest orderDetail, IOrderDetailServices orderDetailServices) =>
            {

                var result = await orderDetailServices.PutOrderDetail(id, orderDetail);
                if (result == -1)
                    return Results.NotFound(); // 404 Not Found: El recurso solicitado no existe
                else
                    return Results.Ok(orderDetail); // 200 OK: La solicitud se realizó correctamente y devuelve el detalle de ordenes
            }).WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Modificar Detalle de Ordenes",
                Description = "Actualiza un detalle de ordenes existente."
            });

            group.MapDelete("/{id}", async (int id, IOrderDetailServices orderDetailServices) =>
            {

                var result = await orderDetailServices.DeleteOrderDetail(id);
                if (result == -1)
                    return Results.NotFound(); // 404 Not Found: El recurso solicitado no existe
                else
                    return Results.NoContent(); // 204 No Content: Recurso Eliminado.
            }).WithOpenApi(o => new OpenApiOperation(o)
            {
                Summary = "Eliminar Detalle de Ordenes",
                Description = "Eliminar detalle de ordenes existente."
            });
        }
    }


}
        

       

