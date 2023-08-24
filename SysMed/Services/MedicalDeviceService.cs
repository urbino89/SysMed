using Microsoft.Extensions.Logging;
using SysMed.Data;
using SysMed.Infrastructure;
using SysMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysMed.Services
{
    public class MedicalDeviceService : IMedicalDeviceService
    {
        private readonly ILogger _logger;
        private const string SqlAddExceptionMessage = "Error Adding MedicalDevice to the database";
        private const string SqlAddSuccessfulMessage = "Device Added Successfully";
        private SysmedContext _context;
        public MedicalDeviceService(ILogger<MedicalDeviceService> logger, SysmedContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<DbTransactionResponseDto> AddMedicalDevices(IEnumerable<MedicalDeviceDto> devices)
        {
            try
            {
                await _context.AddRangeAsync(devices.Select(d => new MedicalDevice
                {
                    Name = d.Name,
                    Description = d.Description,
                    Brand = d.Brand,
                    MaintenanceIntervalInDays = d.MaintenanceIntervalInDays,
                    Model = d.Model,
                    PurchaseDate = d.PurchaseDate,
                    LastMaintenanceDate = d.LastMaintenanceDate
                }));

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, SqlAddExceptionMessage);

                return new DbTransactionResponseDto
                {
                    Success = false,
                    Message = SqlAddExceptionMessage,
                    Code = ApiResponseCodes.AddMedicalDeviceError
                };
            }

            return new DbTransactionResponseDto
            {
                Success = true,
                Message = SqlAddSuccessfulMessage,
                Code = ApiResponseCodes.GlobalSuccess
            };
        }

    }

    public interface IMedicalDeviceService
    {
        Task<DbTransactionResponseDto> AddMedicalDevices(IEnumerable<MedicalDeviceDto> devices);
    }

    public class DbTransactionResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
    }
}
