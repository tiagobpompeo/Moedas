using Moedas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moedas.Services.Coins
{
    public interface ICoinsService
    {
        Task<List<CoinsModel.Value>> GetAllCoinsAsync();
    }
}
