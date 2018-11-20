using System.Threading.Tasks;
using ReminderXamarin.Rest.Models;

namespace ReminderXamarin.Rest
{
    /// <summary>
    /// Provide access to authentication API.
    /// </summary>
    public interface IIdentityClient
    {
        /// <summary>
        /// Get token from authentication API.
        /// </summary>
        /// <param name="model"><see cref="LoginModel"/> to be send.</param>
        /// <returns></returns>
        Task<TokenResponse> GetToken(LoginModel model);
    }
}