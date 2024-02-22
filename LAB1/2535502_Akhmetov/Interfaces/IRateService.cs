namespace _2535502_Akhmetov;
using NbrbAPI.Models;
public interface IRateService
{
    IEnumerable<Rate> GetRates(DateTime date);
}