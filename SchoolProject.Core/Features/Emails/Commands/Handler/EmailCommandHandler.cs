using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basies;
using SchoolProject.Core.Features.Emails.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;


namespace SchoolProject.Core.Features.Emails.Commands.Handler
{
    public class EmailCommandHandler(IStringLocalizer<SharedResources> stringLocalizer ,IEmailsService emailsService) : ResponseHandler(stringLocalizer), IRequestHandler<SendEmailCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer = stringLocalizer;
        private readonly IEmailsService _emailsService = emailsService;

        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailsService.SendEmail(request.Email, request.Massage,null);
            if (response == "Success")
                return Success("");
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SendEmailFailed]);
        }
    }
}
