namespace _2535502_Akhmetov;
using System.Text.Json;
using NbrbAPI.Models;
public class RateService : IRateService
{
    private HttpClient client;
    public RateService(HttpClient httpClient)
    {
        client = httpClient;


    }
    public IEnumerable<Rate> GetRates(DateTime date)
    {



        return JsonSerializer.Deserialize<IEnumerable<Rate>>(
                             response.Content.ReadAsStream());

    }
//https://api.nbrb.by/exrates/rates?periodicity=0 to get all currencies to brub


}