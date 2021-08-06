using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.IServices
{
    public interface IConverter<I,T> where I:class where T:class
    {
        T Convert(I i);
        I Convert(T t);
    }
}
