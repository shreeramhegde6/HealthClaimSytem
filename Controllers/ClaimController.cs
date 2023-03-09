using HealthClaimApp.Models;
using HealthClaimApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClaimApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {

        IClaimService claimService;
        public ClaimController(IClaimService _claimService)
        {
            claimService = _claimService;
        }

        [HttpGet]
        [Route("GetAllClaimType")]
        public IEnumerable<TblClaimType> GetAllClaimType()
        {
            var claimTypeList = claimService.GetAllClaimType();
            return claimTypeList;
        }

        [HttpPost]
        [Route("add-claim")]
        public IActionResult SaveClaim([FromBody] TblClaim claim)
        {
            try
            {
                var data = claimService.SaveClaim(claim);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return Ok(ex);

            }

        }
    }
}
