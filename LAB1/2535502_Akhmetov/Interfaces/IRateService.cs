namespace _2535502_Akhmetov;
using NbrbAPI.Models;
public interface IRateService
{
    public Task<IEnumerable<Rate>> GetRates(DateTime date);
}