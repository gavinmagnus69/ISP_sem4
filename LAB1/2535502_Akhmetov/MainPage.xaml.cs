namespace _2535502_Akhmetov;

public partial class MainPage : ContentPage
{
	int count = 0;
	string current = "";
	string current2 = "";
	string operation = "";
	string answer = "";


	bool int_state = true;
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		

		if ((Button)sender == Btn8){
			current += "8";	
		}
		if ((Button)sender == Btn0){
			current += "0";	
		}
		if ((Button)sender == Btn1){
			current += "1";	
		}
		if ((Button)sender == Btn2){
			current += "2";	
		}
		if ((Button)sender == Btn3){
			current += "3";	
		}
		if ((Button)sender == Btn4){
			current += "4";	
		}
		if ((Button)sender == Btn5){
			current += "5";	
		}
		if ((Button)sender == Btn6){
			current += "6";	
		}
		if ((Button)sender == Btn7){
			current += "7";	
		}
		if ((Button)sender == Btn9){
			current += "8";	
		}
		


			ShowLabel.Text = current;
			SemanticScreenReader.Announce(ShowLabel.Text);
		
	}
}

