using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_CleanArchitecture.Domain.Entities.Shared
{
    // record provides the Immutability => you can't change the values in the record after creation
    // record provide the value comparison
    // record is shorter than class
    public record Title(string value);
}
