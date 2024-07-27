using order.service.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.service.domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Item? GetById(Guid itemId);
    }
}
