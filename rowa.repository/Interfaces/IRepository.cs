using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rowa.repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        virtual Task<int> Add(T newItem)
    }
}
