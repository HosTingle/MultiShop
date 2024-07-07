using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetail)
        {
           var values=await _repository.GetByIdAsync(getOrderDetail.Id);
            return new GetOrderDetailByIdQueryResult
            {
                ProductAmount = values.ProductAmount,
                ProductName = values.ProductName,
                OrderDetailId = values.OrderDetailId,
                OrderingId = values.OrderingId,
                ProductId = values.ProductId,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice,
            };
        }

        public Task Handle()
        {
            throw new NotImplementedException();
        }
    }
}
