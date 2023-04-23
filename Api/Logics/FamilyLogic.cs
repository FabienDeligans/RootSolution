using Api.Services;
using Library.Abstract;
using Library.Models.Business;

namespace Api.Logics
{
    public class FamilyLogic : BaseApiLogic<Family>
    {
        public FamilyLogic(ServiceDatabase serviceDatabase) : base(serviceDatabase)
        {
        }
    }
}
