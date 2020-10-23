using Order_Management.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Services.Contracts
{
    public interface ITokenDetailService
    {
        Task<List<TokenDetailDto>> GetTokenDetails();
        Task AddToken(TokenDetailDto dto);
        Task<bool> DeleteToken(int id);
        Task<TokenDetailDto> GetToken(int id);
        Task<bool> UpdateToken(TokenDetailDto dto);
        Task<StatisticsDto> GetStatistics();
    }
}
