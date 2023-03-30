﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string messagee):this(success)
        {
            Message = messagee;
            Success = success;
        }

        public Result(bool success)
        {
            Success = success;
        }



        public bool Success { get; }

        public string Message { get; }
    }
}
