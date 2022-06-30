﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Query
{
    public class GetUsersQuery : IRequest<List<GetUsersQueryDto>>
    {
    }
}
