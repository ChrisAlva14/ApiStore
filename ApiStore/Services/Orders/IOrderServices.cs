using ApiStore.DTOs;

namespace ApiStore.Services.orders
{
    public interface IOrderServices
    {
        Task<int> PostOrder(OrderRequest order);

        Task<List<OrderResponse>> GetOrder();

        Task<OrderResponse> GetOrder(int orderId);

        Task<int> PutOrder(int orderId, OrderRequest order);

        Task<int> DeleteOrder(int orderId);
    }
}

