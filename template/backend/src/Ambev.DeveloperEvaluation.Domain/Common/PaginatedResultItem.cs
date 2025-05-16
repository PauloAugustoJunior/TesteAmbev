using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public class PaginatedResultItem<T>
{
    public T? Data { get; set; }
}
