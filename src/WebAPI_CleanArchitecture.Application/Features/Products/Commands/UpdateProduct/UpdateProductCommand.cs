using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Entities.Products.DTOs;

namespace WebAPI_CleanArchitecture.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(UpdateProductDto Dto) : ICommand;
}
