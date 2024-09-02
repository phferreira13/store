using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using warehouse.service.domain.Interfaces.Repositories;
using warehouse.service.domain.Models;

namespace warehouse.service.business.UseCases.Items
{
    public class GetItemsQuery : IRequest<IEnumerable<Item>>
    {
        internal class Handler(IItemRepository itemRepository) : IRequestHandler<GetItemsQuery, IEnumerable<Item>>
        {
            public Task<IEnumerable<Item>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(itemRepository.GetItems());
            }
        }
    }
}
