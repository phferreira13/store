using MediatR;
using order.service.domain.Interfaces.Repositories;
using order.service.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.business.UseCases.Items
{
    public class GetAllItemsQuery : IRequest<IEnumerable<Item>>
    {
        internal class Handler(IItemRepository itemRepository) : IRequestHandler<GetAllItemsQuery, IEnumerable<Item>>
        {
            private readonly IItemRepository _itemRepository = itemRepository;

            public Task<IEnumerable<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_itemRepository.GetAll());
            }
        }
    }
}
