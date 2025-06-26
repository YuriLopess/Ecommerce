using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Mappers.Interfaces
{
    public interface IMapper<in TSource, out TDestination>
    {
        TDestination Map(TSource source);
        IEnumerable<TDestination> Map(IEnumerable<TSource> source);

    }
}
