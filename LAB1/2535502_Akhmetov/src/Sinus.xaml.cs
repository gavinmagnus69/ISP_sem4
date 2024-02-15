namespace _2535502_Akhmetov;

public partial class Sinus : ContentPage
{
    public Sinus(){
        InitializeComponent();
    }
    public async Task SolveAsync(double left = 0, double right = 1, double d = 0.00000001){
        await Task.Run(async () => {
            double sum = 0;
            for (var i = left; i <= right; i += d){
                sum += d * Math.Sin(i);
                for(int j = 0; j < 100000; ++j){
                    int tmp = 2 * j;
                }
                double tmp2 = i;
                await Display(tmp2);
                //await ProgressSlider.ProgressTo(tmp2, 100, Easing.Linear);
            }


        });
    }
    public async Task Display(double prog){
        await Task.Run(() =>
            {   
                ProgressLabel.Text = ((int)(100 * prog)).ToString() + " %";
                SemanticScreenReader.Announce(ProgressLabel.Text);
            }
        );
    }
    public void OnClicked(object sender, EventArgs e){
       
        //Task.Run(async () => await SolveAsync());

        for(double i = 0.000000001; i <= 1; i += 0.0000000000001){
            Display(i);


        }

            
    }
	
}