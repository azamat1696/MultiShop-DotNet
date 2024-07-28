using Multishop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;
    public UpdateAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAddressCommand updateAddressCommand)
    {
        var value = await _repository.GetByIdAsync(updateAddressCommand.AddressId);
        value.City = updateAddressCommand.City;
        value.Details = updateAddressCommand.Details;
        value.District = updateAddressCommand.District;
        value.UserId = updateAddressCommand.UserId;
        await _repository.UpdateAsync(value);
    }
}