//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.Extensions;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Localization;
//using SchoolProject.Data.Entities.Identity;
//using SchoolProject.infraStructure.Data;
//using SchoolProject.Service.Abstracts;

//namespace SchoolProject.Service.implementaion
//{
//    public class ApplicationUserService(UserManager<User> userManager, ApplicationDBContext dBContext ,HttpContextAccessor httpContextAccessor, IEmailsService emailsService, IUrlHelper urlHelper ) : IApplicationUserService
//    {
//        private readonly UserManager<User> _userManager = userManager;
//        private readonly ApplicationDBContext _dBContext = dBContext;
//        private readonly HttpContextAccessor _httpContextAccessor = httpContextAccessor;
//        private readonly IEmailsService emailsService = emailsService;
//        private readonly IUrlHelper _urlHelper = urlHelper;

//        public async Task<string> AddAsyenc(User user, string password)
//        {
//            var tran = _dBContext.Database.BeginTransaction();
//            try
//            {
//                var Email = _userManager.FindByEmailAsync(user.Email);
//                if (Email != null) return ("Email Already Exists");
//                var username = _userManager.FindByNameAsync(user.UserName);
//                if (username != null) return ("UserName Already Exists");
//                IdentityResult result = await _userManager.CreateAsync(user, password);
//                if (result.Succeeded) 
//                {
//                    await _userManager.AddToRoleAsync(user, "User");
//                    //Send Confirm Email
//                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                    var resquestAccessor = _httpContextAccessor.HttpContext.Request;
//                    var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
//                    var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";
//                    //$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
//                    //message or body
//                    await _emailsService.SendEmail(user.Email, message, "ConFirm Email");
//                    tran.Commit();
//                    return ("User Created Successfully");
//                }
//                else
//                {
//                    return string.Join(",", result.Errors.Select(x => x.Description).ToList());
//                }
//            }
//            catch
//            {
//                tran.Rollback();
//                return ("Error To Create User");
//            }


//        }
//    }
//}
