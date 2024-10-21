using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ResultPattern.ResultPattern
{
    public sealed class Result<T>
    {
        private Result(T data)
        {
            Data = data;
            IsSuccesfull = true;
            statusCode = (int)HttpStatusCode.OK;
        }

        public T? Data { get; set; }
        public List<string>? ErrorMessages { get; set; } = new();
        public bool IsSuccesfull { get; set; }
        [JsonIgnore]
        public int statusCode { get; set; } = (int)HttpStatusCode.OK;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        private Result(List<string> messages, int StatusCode = 400)
        {
            ErrorMessages = messages;
            IsSuccesfull = false;
            statusCode = StatusCode;
        }
        public Result(int StatusCode, List<string> errorMessage)
        {
            IsSuccesfull = false;
            statusCode = StatusCode;
            ErrorMessages = errorMessage;
        }
        public Result(int StatusCode, string errorMessage)
        {
            IsSuccesfull = false;
            statusCode = StatusCode;
            ErrorMessages = new List<string> { errorMessage };
        }

        public static Result<T> Succeed(T data)
        {
            return new Result<T>(data);
        }

        public static Result<T> Failure(string message)
        {
            return new Result<T>(new List<string> { message }, 500);
        }

        public static Result<T> Failure(List<string> messages, int StatusCode = 400)
        {
            return new Result<T>(messages, StatusCode);
        }
    }
}
