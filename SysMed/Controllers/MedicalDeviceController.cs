﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SysMed.Model;
using SysMed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysMed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost("Add")]
        public async Task<IActionResult> Add(IEnumerable<MedicalDeviceDto> devices)
        {
            var response = await _medicalDeviceService.Add(devices);
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _medicalDeviceService.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById/{serviceId}")]
        public IActionResult GetById(Guid serviceId)
        {
            var response = _medicalDeviceService.GetByServiceId(serviceId);
            return Ok(response);
        }
    }
 }
