using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Application.Utility
{
    public class Result<T>
    {
        public T? Value {  get; set; }
        public ProblemDetails ProblemDetails { get; set; }

        public string Message { get; set; } = string.Empty;

        public int StatusCode { get; set; }

        public bool IsSuccess => ProblemDetails is null;

        public Result(T?value=default,int statusCode=StatusCodes.Status200OK)
        {
            Value=value;
            StatusCode=statusCode;
        }

        public Result(ProblemDetails problemDetails)
        {
            ProblemDetails = problemDetails;
        }

        public static Result<T> Success(T? value)
        {
            return new Result<T>
            {
                Value = value};
        }

        public static Result<T> Success(T? value,string message)
        {
            return new Result<T>
            {
                Value = value,
                Message = message
            };
        }

        public static Result<T> Success(T? value,int statusCode, string message)
        {
            return new Result<T>
            {
                Value = value,
                StatusCode= statusCode,
                Message = message
            };
        }

        public static Result<T> Failure(ProblemDetails problemDetails)
        {
            var details = new ProblemDetails()
            {
                Detail=problemDetails.Detail,
                Instance=problemDetails.Instance,
                Status=problemDetails.Status,
                Title  =problemDetails.Title,
                Type=problemDetails.Type,
            };
            return new Result<T>(details);
        }

        public static Result<T> Failure(string message,int statusCode=StatusCodes.Status500InternalServerError)
        {
            var details = new ProblemDetails()
            {
                Status = statusCode,
                Title = message,
            };
            return new Result<T>(details);
        }
    }
}
