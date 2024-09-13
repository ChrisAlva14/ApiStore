using ApiStore.DTOs;

namespace ApiStore.Services.OrderDetails
{
    public interface IOrderDetailServices
    {
        Task<int> PostOrderDetail(OrderDetailRequest OrderDetail);
        Task<List<OrderDetailResponse>> GetOrderDetails();
        Task<OrderDetailResponse> GetOrderDetail(int Id);
        Task<int> PutOrderDetail(int Id, OrderDetailRequest orderDetail);
        Task<int> DeleteOrderDetail(int Id);

    }
}
