using TaskTrayApplication.Models;

namespace TaskTrayApplication.Services
{
    public interface ICryptoRepository
    {
        CryptoContainer GetCryptoPrices();
    }
}