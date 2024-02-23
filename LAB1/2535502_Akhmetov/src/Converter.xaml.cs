using System.Diagnostics;
using NbrbAPI.Models;

namespace _2535502_Akhmetov;
public partial class Converter : ContentPage
{
    IRateService service = new RateService(new HttpClient());
    bool state_cur1 = false;
    bool state_cur2 = false;
    public Converter(){
            InitializeComponent();
            //to set today currencies when you start an app 
            getTodayRates(DateTime.Now);
    }
    public async Task getTodayRates(DateTime dt){
        IEnumerable<Rate> miau = await service.GetRates(dt);
        foreach (var item in miau)
        {
            if(item.Cur_Abbreviation == "USD"){
                UsdLabel.Text = item.Cur_OfficialRate.ToString();
            }
            if(item.Cur_Abbreviation == "EUR"){
                EurLabel.Text = item.Cur_OfficialRate.ToString();
            }
            if(item.Cur_Abbreviation == "RUB"){
                RubLabel.Text = item.Cur_OfficialRate.ToString();
            }
            if(item.Cur_Abbreviation == "CHF"){
                ChfLabel.Text = item.Cur_OfficialRate.ToString();
            }
            if(item.Cur_Abbreviation == "CNY"){
                CnyLabel.Text = item.Cur_OfficialRate.ToString();
            }
            if(item.Cur_Abbreviation == "GBP"){
                GbpLabel.Text = item.Cur_OfficialRate.ToString();
            }
            
        }
    }


    private void converter(){
        if(state_cur1 && state_cur2){
            



        }



    }
    private void OnCur1Changed(object sender, EventArgs e){}
    private void OnCur2Changed(object sender, EventArgs e){}
    public void OnDateChanged(object sender, EventArgs e){
        this.getTodayRates(datePicker.Date);
    }

    










    
}