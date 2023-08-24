using SysMed.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SysMed.Services
{
    public interface IMedicalDeviceService
    {
        Task<DbTransactionResponseDto> Add(IEnumerable<MedicalDeviceDto> devices);

        Task<List<MedicalDeviceDto>> GetAll();

        MedicalDeviceDto GetByServiceId(Guid ServiceId);
    }
}