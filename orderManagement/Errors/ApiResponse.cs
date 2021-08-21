﻿using System;

namespace orderManagement.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "All look good",
                400 => "A bad request you have made",
                401 => "Authorized, you are not",
                404 => "Resource found,it was not",
                500 => "Error are the path to the dark side.Errors leads to anger. Anger leads to hate. Hate leads to career change",
                _ => null
            };
        }
    }
}