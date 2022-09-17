using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProjetCRMStagiaire.Core.Data;

namespace ProjetCRMStagiaire.Core.Helpers
{


    public class SignInManagerWrapper<TUser> : SignInManager<ApplicationUser> where TUser : class
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public SignInManagerWrapper(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger, ApplicationDbContext dbContext, IAuthenticationSchemeProvider schemeProvider, IUserConfirmation<ApplicationUser> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider, confirmation)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            SignInResult signInResult = new SignInResult();

            //Login not allowed - ClientId required to login
            return await Task.FromResult(signInResult);
        }

        public async Task<SignInResult> PasswordSignInAsync(string clientId, string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            if (CheckIsClientIdValid(userName, password))
            {
                var result = await base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
                return result;
            }
            else
            {
                SignInResult result = await Task.FromResult(new SignInResult());
                //Login not allowed - ClientId mismatch
                return result;
            }
        }

        private bool CheckIsClientIdValid(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
