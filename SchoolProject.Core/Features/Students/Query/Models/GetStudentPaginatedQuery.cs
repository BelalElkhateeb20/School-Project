﻿using MediatR;
using SchoolProject.Core.Features.Students.Query.ResponseDTO;
using SchoolProject.Core.Wrappers;
namespace SchoolProject.Core.Features.Students.Query.Models
{
    public class GetStudentPaginatedQuery:IRequest<PaginatedResult<GetStudentPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string[]? OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
