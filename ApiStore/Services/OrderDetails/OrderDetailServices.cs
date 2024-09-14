using ApiStore.DTOs;
using ApiStore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Services.OrderDetails
{
    public class OrderDetailServices : IOrderDetailServices
    {
        private readonly OnlineShopContext _db;
        private readonly IMapper _mapper;

        public OrderDetailServices(OnlineShopContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteOrderDetail(int Id)
        {
            var orderDetail = await _db.OrderDetails.FindAsync(Id);
            if (orderDetail == null)
                return -1;

            _db.OrderDetails.Remove(orderDetail);

            return await _db.SaveChangesAsync();
        }

        public async Task<OrderDetailResponse> GetOrderDetail(int Id)
        {
            var orderDetail = await _db.OrderDetails.FindAsync(Id);
            var OrderDetailResponse = _mapper.Map<OrderDetail, OrderDetailResponse>(orderDetail);

            return OrderDetailResponse;
        }

        public async Task<List<OrderDetailResponse>> GetOrderDetails()
        {
            var orderDetails = await _db.OrderDetails.ToListAsync();
            var orderDetailsList = _mapper.Map<List<OrderDetail>, List<OrderDetailResponse>>(orderDetails);

            return orderDetailsList;
        }

        public async Task<int> PostOrderDetail(OrderDetailRequest OrderDetail)
        {
            var OrderDetailRequest = _mapper.Map<OrderDetailRequest, OrderDetail>(OrderDetail);
            await _db.OrderDetails.AddAsync(OrderDetailRequest);
            await _db.SaveChangesAsync();
            return OrderDetailRequest.Id;
        }

        public async Task<int> PutOrderDetail(int Id, OrderDetailRequest orderDetail)
        {
            var entity = await _db.OrderDetails.FindAsync(Id);
            if (entity == null)
                return -1;

            entity.Precio = orderDetail.Precio;
            entity.Order = orderDetail.Order;
            entity.Product = orderDetail.Product;
            entity.Cantidad = orderDetail.Cantidad;
            entity.ProductId = orderDetail.ProductId;
            entity.OrderId = orderDetail.OrderId;

            _db.OrderDetails.Update(entity);

            return await _db.SaveChangesAsync();
        }
    }
}
