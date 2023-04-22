using Library.Abstract;
using Library.Models.Business;
using Library.Settings;
using Microsoft.Extensions.Options;

namespace Blazor.Services
{
    public class FamilyCallApi : BaseCallApi<Family>
    {
        public FamilyCallApi(HttpClient client, IOptions<SettingsCallApi> options) : base(client, options)
        {
        }
    }
}