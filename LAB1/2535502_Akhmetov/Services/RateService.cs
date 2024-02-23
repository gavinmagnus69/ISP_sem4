namespace _2535502_Akhmetov;

using System.Diagnostics;
using System.Text.Json;
using NbrbAPI.Models;
public class RateService : IRateService
{
    private HttpClient client;
    public RateService(HttpClient httpClient)
    {
        client = httpClient;


    }
    public async Task<IEnumerable<Rate>> GetRates(DateTime date)
    {
        HttpResponseMessage response = await client.GetAsync("https://api.nbrb.by/exrates/rates?periodicity=0"); 
        try{
            response.EnsureSuccessStatusCode();
        }
        catch(Exception x)
        {
            Debug.WriteLine("Error ocured in request {0}", x.Message);
            return null;
        }
        return JsonSerializer.Deserialize<IEnumerable<Rate>>(await response.Content.ReadAsStreamAsync());

    }
//https://api.nbrb.by/exrates/rates?periodicity=0 to get all currencies to bel rub
//https://api.nbrb.by/exrates/rates?ondate=2023-01-10&periodicity=0 to get all curencies to bel rub on date 

}