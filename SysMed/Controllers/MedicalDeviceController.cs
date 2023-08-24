using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SysMed.Model;
using SysMed.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalDeviceController : ControllerBase
    {
        private readonly ILogger<MedicalDeviceController> _logger;
        private readonly IMedicalDeviceService _medicalDeviceService;

        public MedicalDeviceController(
            ILogger<MedicalDeviceController> logger,
            IMedicalDeviceService medicalDeviceService)
        {
            _medicalDeviceService = medicalDeviceService;
            _logger = logger;
        }

        [HttpPost(Name = "Add")]
        public async Task<IActionResult> Add(IEnumerable<MedicalDeviceDto> devices)
        {
            var response = await _medicalDeviceService.AddMedicalDevices(devices);
            return Ok(response);
        }
    }
 }
