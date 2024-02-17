using Android.Graphics;
using Xamarin.Google.ErrorProne.Annotations;

namespace _2535502_Akhmetov;

public partial class Sinus : ContentPage
{
    public Sinus(){
        InitializeComponent();
        cTSource = new();
        token = cTSource.Token;
    }
    
    CancellationTokenSource cTSource;
    CancellationToken token;

    bool start_active = false;
    
    bool cancel_active = false;

    public async Task SolveAsync(double left = 0, double right = 1, double d = 0.00000001){
        await Task.Run(async () => {
            await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        StateLabel.Text = "Calculating Integral";
                    });

            int counter = 0;
            double sum = 0;
            for (var i = left; i <= right; i += d){

                if(token.IsCancellationRequested){

                    await Cancellation();
                     await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        StateLabel.Text = "Task cancelled";
                    });
                    //await Task.Delay(2000);
                    return;
                }
                sum += d * Math.Sin(i);
                // for(int j = 0; j < 100000; ++j){
                //     int tmp = 2 * j;
                // }
               

                if((counter % 100000) == 0){
                    //await DisplayAsync(i);
                  await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        await ProgressSlider.ProgressTo(i, 10, Easing.Linear);
                        ProgressLabel.Text = ((int)(ProgressSlider.Progress * 100)).ToString() + " %";
                    });
                   
                
                }
                 ++counter;
                
            }
            ProgressLabel.Text = "100 %";
            start_active = false;
            await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        StateLabel.Text = "Answer is = " + sum.ToString();
                    });
        }, token);
        
    }

    public async Task Cancellation(){
        await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        await ProgressSlider.ProgressTo(0, 0, Easing.Linear);
                        ProgressLabel.Text = "0 %";
                        cancel_active = false;
                        start_active = false;
                        cTSource.Dispose();
                        cTSource = new();
                        token = cTSource.Token;   



                    });
                 
    }

    
  
    public void OnClicked(object sender, EventArgs e){
       if(!start_active){
            start_active = true;
            SolveAsync(0, 1, 0.0000001);
       }       
    }

    public void OnCancel(object sender, EventArgs e){
        if(start_active && !cancel_active){
            cancel_active = true;
            cTSource.Cancel();
           
            //Cancellation();
        }

    }
	
}