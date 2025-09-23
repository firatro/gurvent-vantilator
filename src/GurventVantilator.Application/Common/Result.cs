using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Common
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public string? ErrorMessage { get; private set; }
        public T? Data { get; private set; }

        private Result(bool success, string? errorMessage, T? data)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public static Result<T> Ok(T data) => new Result<T>(true, null, data);
        public static Result<T> Fail(string errorMessage) => new Result<T>(false, errorMessage, default);
    }
}
