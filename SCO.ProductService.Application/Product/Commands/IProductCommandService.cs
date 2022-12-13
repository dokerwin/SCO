using SCO.ProductService.Application.DTOs.Read.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.ProductService.Application.Commands
{
    public interface IProductCommandService
    {
        public bool DecreaseQtInStorage(decimal qt);
    }
}
