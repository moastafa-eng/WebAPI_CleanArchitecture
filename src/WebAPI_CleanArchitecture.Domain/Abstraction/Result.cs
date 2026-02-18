using System.Collections;
using System.Collections.Generic;

namespace WebAPI_CleanArchitecture.Domain.Abstraction
{
    public class Result<TEntity> where TEntity : BaseEntity 
    {

        // << Properties >>
        public TEntity? Data { get; set; }
        public bool IsNotSuccessfull { get; set; }
        public int StatusCode { get; set; }
        public Dictionary<string, string>? Errors { get; set; }



        // << *Result Design Pattern* >> 

        // << Success with data >>
        private Result(TEntity? data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
            IsNotSuccessfull = false;
        }

        // << Success without data >>
        private Result(int statusCode)
        {
            StatusCode = statusCode;
            IsNotSuccessfull = false;
        }

        // << Fail with one error >>
        private Result(int statusCode, string errorCode, string errorMassage)
        {
            StatusCode = statusCode;
            IsNotSuccessfull = true;
            Errors = new() { { errorCode, errorMassage } };
        }

        // << Fail with many errors >>
        private Result(int statusCode, Dictionary<string, string> errors)
        {
            StatusCode = statusCode;
            IsNotSuccessfull = true;
            Errors = errors;
        }



        // << *Factory Design Pattern* >>
        public static Result<TEntity> Success(TEntity? data, int statusCode)
            => new(data, statusCode);

        public static Result<TEntity> Success(int statusCode)
            => new(statusCode);

        public static Result<TEntity> Fail(int statusCode, string errorCode, string errorMessage)
            => new(statusCode, errorCode, errorMessage);

        public static Result<TEntity> Fail(int statusCode, Dictionary<string, string> errors)
            => new(statusCode, errors);


        public class NoContentDto;
    }
}
