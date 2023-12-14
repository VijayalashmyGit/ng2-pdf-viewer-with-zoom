using VassaSpraket_TW.Data.Repositories;
using VassaSpraket_TW.Models;
using Microsoft.AspNetCore.Mvc;


namespace VassaSpraket_TW.Controllers
{

    [ApiController]
    [Route("PageTemplate")]

    public class PageTemplateController : ControllerBase
    {
        private readonly IPageTemplateRepository _PageTemplaterepository;

        public PageTemplateController(IPageTemplateRepository repository)
        {
            _PageTemplaterepository = repository;
        }

      

        [HttpGet]
        [Route("GetById")]
        public async Task<ApiResponse<PageTemplateViewModel>> Get(int id)
        {
            try
            {
                var exercise = await _PageTemplaterepository.GetById(id);
                return new ApiResponse<PageTemplateViewModel>
                {
                    Payload = exercise,
                    Success = true
                };

            }
            catch (Exception e)
            {
                return new ApiResponse<PageTemplateViewModel>
                {
                    ErrorMessage = "Error Pagetemplate" + e.Message,
                    Success = false
                };
            }

        }
    }
}
