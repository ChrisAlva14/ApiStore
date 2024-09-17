using ApiStore.DTOs;
using ApiStore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Services.orders
{
    public class OrderServices : IOrderServices
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper _IMapper;

        public OrderServices(OnlineShopContext context, IMapper iMapper)
        {
            _context = context;
            _IMapper = iMapper;
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null)
            {
                return -1;
            }

            _context.Orders.Remove(order);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> PostOrder(OrderRequest orderRequest)
        {
            var order = _IMapper.Map<OrderRequest, Order>(orderRequest);

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<int> PutOrder(int orderId, OrderRequest orderRequest)
        {
            // Buscar la orden existente en la base de datos
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null)
            {
                throw new Exception("Order not found"); // Puedes manejar la excepción según lo necesites
            }

            // Actualizar la orden con los nuevos valores
            order.EstadoPedido = orderRequest.EstadoPedido;
            order.FechaPedido = orderRequest.FechaPedido; // Actualizar otros campos relevantes

            // Actualizar la orden en el contexto
            _context.Orders.Update(order);

            // Guardar los cambios en la base de datos
            return await _context.SaveChangesAsync();
        }

        public async Task<List<OrderResponse>> GetOrders()
        {
            // Obtener la lista de órdenes de la base de datos
            var orders = await _context.Orders.ToListAsync();

            // Mapear la lista de órdenes a OrderResponse usando AutoMapper
            var orderList = _IMapper.Map<List<Order>, List<OrderResponse>>(orders);

            return orderList;
        }

        public async Task<List<OrderResponse>> GetOrder()
        {
            var order = await _context.Orders.ToListAsync();

            var orderResponse = _IMapper.Map<List<Order>, List<OrderResponse>>(order);
            return orderResponse;
        }

        public async Task<OrderResponse> GetOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            // Usa AutoMapper para mapear el producto a ProductResponse
            var orderResponse = _IMapper.Map<Order, OrderResponse>(order);
            return orderResponse;
        }
    }
}
