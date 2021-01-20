using Moedas.Constants;
using Moedas.Models;
using Moedas.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moedas.Services.Coins
{
    public class CoinsService  : ICoinsService
    {
        private readonly IGenericRepository _genericRepository;
        
        public CoinsService(IGenericRepository genericRepository)
        { 
            _genericRepository = genericRepository;
        }

        public async Task<List<CoinsModel.Value>> GetAllCoinsAsync()
        {
            string uri = $"{ApiConstants.BaseApiUrl}"+ApiConstants.Moedas;
            var coins = await _genericRepository.GetAsync<CoinsModel>(uri);
          
            var listCoins = coins.value;
           
            return listCoins;
        }

    }
}
