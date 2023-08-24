using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public async Task<DbTransactionResponseDto> Add(IEnumerable<MedicalDeviceDto> devices)
        {
            try
            {
                await _context.AddRangeAsync(devices.Select(d => new MedicalDevice
                {
                    ServiceId = d.ServiceId,
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
                var response = new DbTransactionResponseDto
                {
                    Success = false,
                    Message = SqlAddExceptionMessage,
                    Code = ApiResponseCodes.AddMedicalDeviceError
                };

                if (e is DbUpdateException dbUpdateEx && dbUpdateEx?.InnerException is SqlException sqlException)
                {
                    response.Message = sqlException.Message;
                }
                return response;
            }

            return new DbTransactionResponseDto
            {
                Success = true,
                Message = SqlAddSuccessfulMessage,
                Code = ApiResponseCodes.GlobalSuccess
            };
        }

        public Task<List<MedicalDeviceDto>> GetAll()
        {
            return _context.MedicalDevices.Select(d => new MedicalDeviceDto
            {
                ServiceId = d.ServiceId,
                Name = d.Name,
                Description = d.Description,
                Brand = d.Brand,
                MaintenanceIntervalInDays = d.MaintenanceIntervalInDays,
                Model = d.Model,
                PurchaseDate = d.PurchaseDate,
                LastMaintenanceDate = d.LastMaintenanceDate
            }).ToListAsync();
        }

        public MedicalDeviceDto GetByServiceId(Guid serviceId)
        {
            var device = _context.MedicalDevices.SingleOrDefault(d => d.ServiceId.Equals(serviceId.ToString()));

            if (device == default)
                return null;

            return new MedicalDeviceDto
            {
                ServiceId = device.ServiceId,
                Name = device.Name,
                Description = device.Description,
                Brand = device.Brand,
                MaintenanceIntervalInDays = device.MaintenanceIntervalInDays,
                Model = device.Model,
                PurchaseDate = device.PurchaseDate,
                LastMaintenanceDate = device.LastMaintenanceDate
            };
        }
    }
}