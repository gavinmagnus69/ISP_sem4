using System.Diagnostics;
using NbrbAPI.Models;
using System.Text.RegularExpressions;

namespace _2535502_Akhmetov;
public partial class Converter : ContentPage
{
    IRateService service = new RateService(new HttpClient());
    List<string> abbreviations = new List<string>{"USD","EUR", "RUB", "CHF", "CNY", "GBP"};
    bool state_cur1 = false;
    bool state_cur2 = false;
    Dictionary<string, Tuple<int, decimal>> values;
    public Converter(){
            InitializeComponent();
            values = new();
            datePicker.MaximumDate = DateTime.Now;
            //to set today currencies when you start an app 
            getTodayRates(DateTime.Now);
    }
    public async Task getTodayRates(DateTime dt){
        IEnumerable<Rate> miau = await service.GetRates(dt);
        foreach (var item in miau)
        {
            // if(abbreviations.Contains(item.Cur_Abbreviation)){

            // }

            //we could just add labels without ifs
            if(item.Cur_Abbreviation == "USD"){
                UsdLabel.Text = item.Cur_OfficialRate.ToString();
                values[item.Cur_Abbreviation] = new Tuple<int, decimal>(item.Cur_Scale, (decimal)item.Cur_OfficialRate); 
            }
            if(item.Cur_Abbreviation == "EUR"){
                EurLabel.Text = item.Cur_OfficialRate.ToString();
                values[item.Cur_Abbreviation] = new Tuple<int, decimal>(item.Cur_Scale, (decimal)item.Cur_OfficialRate); 
            }
            if(item.Cur_Abbreviation == "RUB"){
                RubLabel.Text = item.Cur_OfficialRate.ToString();
                values[item.Cur_Abbreviation] = new Tuple<int, decimal>(item.Cur_Scale, (decimal)item.Cur_OfficialRate); 
            }
            if(item.Cur_Abbreviation == "CHF"){
                ChfLabel.Text = item.Cur_OfficialRate.ToString();
                values[item.Cur_Abbreviation] = new Tuple<int, decimal>(item.Cur_Scale, (decimal)item.Cur_OfficialRate); 
            }
            if(item.Cur_Abbreviation == "CNY"){
                CnyLabel.Text = item.Cur_OfficialRate.ToString();
                values[item.Cur_Abbreviation] = new Tuple<int, decimal>(item.Cur_Scale, (decimal)item.Cur_OfficialRate); 
            }
            if(item.Cur_Abbreviation == "GBP"){
                GbpLabel.Text = item.Cur_OfficialRate.ToString();
                values[item.Cur_Abbreviation] = new Tuple<int, decimal>(item.Cur_Scale, (decimal)item.Cur_OfficialRate); 
            }
            
        }
    }


    private void converter(int state){
        if(state_cur1 && state_cur2){
            if(state == 1){
                double to_brub = (double)values[Currency1.Items[Currency1.SelectedIndex]].Item2 / values[Currency1.Items[Currency1.SelectedIndex]].Item1 * Double.Parse(Cur1Entry.Text);
                double to_cur =  to_brub / (double)values[Currency2.Items[Currency2.SelectedIndex]].Item2 * values[Currency2.Items[Currency2.SelectedIndex]].Item1;
                //Cur2Entry.Text = Math.Round(to_cur, 3).ToString();
                Cur2Entry.Text = String.Format("{0:0.00}", to_cur);
            }
            if(state == 2){
                double to_brub = (double)values[Currency2.Items[Currency2.SelectedIndex]].Item2 / values[Currency2.Items[Currency2.SelectedIndex]].Item1 * Double.Parse(Cur2Entry.Text);
                double to_cur =  to_brub / (double)values[Currency1.Items[Currency1.SelectedIndex]].Item2 * values[Currency1.Items[Currency1.SelectedIndex]].Item1;
                //Cur1Entry.Text = Math.Round(to_cur, 3).ToString();
                Cur1Entry.Text = String.Format("{0:0.00}", to_cur);
            }
        }
    }
    
    void OnEntryTextChanged1(object sender, TextChangedEventArgs e)
    {
         if(Cur1Entry.Text == "," || Cur1Entry.Text == ".")
        {
            Cur1Entry.Text = "0";
        }
        if(Cur1Entry.Text != ""){
            this.converter(1);
        }
       
       
        
    }
    void OnEntryTextChanged2(object sender, TextChangedEventArgs e)
    {
        if(Cur2Entry.Text == "," || Cur2Entry.Text == ".")
        {
            Cur2Entry.Text = "0";
        }
        if(Cur2Entry.Text != ""){
            this.converter(2);
        }
        
    }
    private void OnCur1Changed(object sender, EventArgs e){
        if(Currency1.SelectedIndex != -1){
            state_cur1 = true;
        }
        else{
            state_cur1 = false;
        }
    }
    private void OnCur2Changed(object sender, EventArgs e){
        if(Currency2.SelectedIndex != -1){
            state_cur2 = true;
        }
        else{
            state_cur2 = false;
        }
    }
    public void OnDateChanged(object sender, EventArgs e){
        this.getTodayRates(datePicker.Date);
    }
}