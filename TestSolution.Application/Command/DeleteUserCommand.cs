﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestSolution.Application.Commend
{
    public class DeleteUserCommand : IRequest
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
