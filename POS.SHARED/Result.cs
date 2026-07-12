using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.SHARED
{
    public class Result<T>
    {
        public bool IsSuccess { get; set;  }

        public T Data { get; set; }

        public string Messages { get; set; }

        public string ErrorMessages { get; set; }

        public static Result<T> Success(T Data , string message) => new Result<T> { Data = Data , Messages = message , IsSuccess = true };

        public static Result<T> Failure(string message, string err) => new Result<T> { Messages = message, ErrorMessages = err, IsSuccess = false };

        public static Result<T> NotFound(string message, string err) => new Result<T> { Messages = message , ErrorMessages = err , IsSuccess= true};
    }
}
