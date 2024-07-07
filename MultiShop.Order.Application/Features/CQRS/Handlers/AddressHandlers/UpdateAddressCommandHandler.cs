using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand updateAddress)
        {
            var values=await _repository.GetByIdAsync(updateAddress.AddressId);
            values.Detail = updateAddress.Detail;
            values.District = updateAddress.District;
            values.City = updateAddress.City;
            values.UserId= updateAddress.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}
