using ASAP.API.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Extensions
{
    public class Converter<I, T> : IConverter<I, T>
        where I : class
        where T : class
    {
        private readonly IMapper _mapper;
        public Converter(IMapper mapper)
        {
            _mapper = mapper;
        }
        public T Convert(I i)
        {
            return _mapper.Map<T>(i);
        }

        public I Convert(T t)
        {
            return _mapper.Map<I>(t);
        }
    }
}
