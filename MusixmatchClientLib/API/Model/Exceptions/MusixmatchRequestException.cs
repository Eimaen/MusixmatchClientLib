﻿using MusixmatchClientLib.API.Model.Types;
using System;
using System.Collections.Generic;

namespace MusixmatchClientLib.API.Model.Exceptions
{
    public class MusixmatchRequestException : Exception
    {
        public StatusCode StatusCode { get; }

        private static Dictionary<StatusCode, string> ExceptionMessages = new Dictionary<StatusCode, string>
        {
            [StatusCode.Success] = "The request was successful.",
            [StatusCode.BadSyntax] = "The request had bad syntax or was inherently impossible to be satisfied.",
            [StatusCode.AuthFailed] = "Authentication failed, probably because of invalid/missing API key.",
            [StatusCode.UsageLimitReached] = "The usage limit has been reached, either you exceeded per day requests limits or your balance is insufficient.",
            [StatusCode.NotAuthorized] = "You are not authorized to perform this operation.",
            [StatusCode.ResourceNotFound] = "The requested resource was not found.",
            [StatusCode.MethodNotFound] = "The requested method was not found.",
            [StatusCode.ConflictDetected] = "The data you have submitted is different from the server one.",
            [StatusCode.ServerError] = "Ops. Something was wrong.", // i've already realised that they like typos very much?
            [StatusCode.ServerBusy] = "Our system is a bit busy at the moment and your request can’t be satisfied."
        };

        public MusixmatchRequestException(StatusCode statusCode) : base(ExceptionMessages[statusCode]) => StatusCode = statusCode;
    }
}
