using System;

namespace Calculator.Api.DTOs
{
    public abstract class ApiResponse<T>
    {
        public T Data { get; set; }

        //public IList<Errors>
    }
}
