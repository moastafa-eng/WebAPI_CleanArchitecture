// Ignore Spelling: Dto

using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI_CleanArchitecture.Domain.Abstraction
{
    public class Result<TDto> where TDto : IResult
    {

        // << Properties >>
        public TDto? Data { get; set; }
        [JsonIgnore]
        public bool IsNotSuccessful { get; set; }
        public int StatusCode { get; set; }
        public Error? Errors { get; set; }



        // << *Result Design Pattern* >> 

        // << Success with data >>
        private Result(TDto? data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
            IsNotSuccessful = false;
        }

        // << Success without data >>
        private Result(int statusCode)
        {
            StatusCode = statusCode;
            IsNotSuccessful = false;
        }

        // << Fail with one error >>
        private Result(int statusCode, string errorCode, string errorMassage)
        {
            StatusCode = statusCode;
            IsNotSuccessful = true;
            Errors = new()
            {
                ErrorCode = errorCode,
                ErrorMessages = [errorMassage]
            };
        }

        // << Fail with many errors >>
        private Result(int statusCode, Error errors)
        {
            StatusCode = statusCode;
            IsNotSuccessful = true;
            Errors = errors;
        }



        // << *Factory Design Pattern* >>
        public static Result<TDto> Success(TDto? data, int statusCode)
            => new(data, statusCode);

        public static Result<TDto> Success(int statusCode)
            => new(statusCode);

        public static Result<TDto> Fail(int statusCode, string errorCode, string errorMessage)
            => new(statusCode, errorCode, errorMessage);

        public static Result<TDto> Fail(int statusCode, Error errors)
            => new(statusCode, errors);
    }

    public class Error
    {
        public string ErrorCode { get; set; } = null!;
        public List<string> ErrorMessages { get; set; } = null!;
    }
    public class NoContentDto : IResult;
}
