using Api.Logics;
using Library.Abstract;
using Library.Models.Business;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : BaseApiController<Family>
    {
        private readonly FamilyLogic _familyLogic;
        public FamilyController(FamilyLogic familyLogic) : base(familyLogic)
        {
            _familyLogic = familyLogic;
        }
    }
}
