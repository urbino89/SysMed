using Microsoft.AspNetCore.Mvc;

namespace SysMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalDeviceController : ControllerBase
    {
        private readonly ILogger<MedicalDeviceController> logger;

        public MedicalDeviceController(ILogger<MedicalDeviceController> logger)
        {
            this.logger = logger;
        }
    }
}
