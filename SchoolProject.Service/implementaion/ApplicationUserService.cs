using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Data.Enums;
using SchoolProject.infraStructure.Data;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.implementaion
{
    public class ApplicationUserService(UserManager<User> userManager, ApplicationDBContext dBContext, IHttpContextAccessor httpContextAccessor, IMapper mapper, IEmailsService emailsService, IAuthenticationService authentication, LinkGenerator linkGenerator) : IApplicationUserService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly ApplicationDBContext _dBContext = dBContext;
        private readonly IMapper _mapper = mapper;

        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IEmailsService _emailsService = emailsService;
        private readonly IAuthenticationService _authentication = authentication;
        private readonly LinkGenerator _linkGenerator = linkGenerator;
        //private readonly IUrlHelper _urlHelper = urlHelper;

        public async Task<string> AddAsyenc(User user, string password, string role , int departmentid)
        {


            using var tran = await _dBContext.Database.BeginTransactionAsync();
            try
            {
                if (await _userManager.FindByEmailAsync(user.Email) is not null)
                    return "Email Already Exists";

                if (await _userManager.FindByNameAsync(user.UserName) is not null)
                    return "UserName Already Exists";
                user.EmailConfirmed = false;
                user.AccessFailedCount = 0;
                user.LockoutEnabled = false;
                user.TwoFactorEnabled = false;
                switch (role)
                {
                    case "Student":
                        user.UserType = UserType.Student;
                        user.Code = "Code";
                        break;
                    case "Instractor":
                        user.UserType = UserType.Instructor;
                        user.Code = "Code";
                        break;
                    default:
                        return "This Role is Not Found";
                }

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                    return string.Join("; ", result.Errors.Select(e => e.Description));


                switch (role)
                {
                    case "Student":
                        var student = _mapper.Map<Student>(user);
                        student.UserId = user.Id;
                        user.Code = "Code" + $"{user.Id}";
                        await _userManager.AddToRoleAsync(user,"Student");
                        await _dBContext.students.AddAsync(student);
                        break;

                    case "Instractor":
                        var instructor = _mapper.Map<Instructor>(user);
                        instructor.UserId = user.Id;
                        user.Code = "Code" + $"{user.Id}";
                        await _userManager.AddToRoleAsync(user, "Instractor");
                        instructor.DepartmentID = departmentid;
                        await _dBContext.instructors.AddAsync(instructor);
                        break;
                }
                await GenerateEmailToken(user);

                await _userManager.UpdateAsync(user);

                await _dBContext.SaveChangesAsync();
                await tran.CommitAsync();
                return "User Created Successfully";
            }
            catch
            {
                await tran.RollbackAsync();
                return "Error To Create User";
            }

        }
        public async Task GenerateEmailToken(User user)
        {
            var Token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var request = _httpContextAccessor.HttpContext.Request;

            var confirmationUrl = _linkGenerator.GetUriByAction(
                httpContext: _httpContextAccessor.HttpContext,
                action: "ConfirmEmailAsync",
                controller: "Authentication",
                values: new { userId = user.Id, Token },
                scheme: request.Scheme,
                host: request.Host
                   );

            var body = $"To Confirm Email Click Link: <a href='{confirmationUrl}'>Link Of Confirmation</a>";
            await _emailsService.SendEmail(user.Email, body, "Confirm Email");
        }
    }
}
