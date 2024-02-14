using System.Numerics;

namespace _2535502_Akhmetov;

public partial class MainPage : ContentPage
{
	string current = "";

	string current1 = "";
	string current2 = "";
	string operation = "";
	string answer = "";
	List<string> queque;



	//bool int_state = true; ?
	public MainPage()
	{
		InitializeComponent();
		queque = new();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		

		if ((Button)sender == Btn8){
			
			if(queque.Count == 1){
				queque[0] += "8";
				
			}
			if (queque.Count == 3){
				queque[2] += "8";
				
			}
			if (queque.Count == 0){
				queque.Add("8");
			
			}
		}
		if ((Button)sender == Btn0){
			if(queque.Count == 1){
				queque[0] += "0";
				
			}
			if (queque.Count == 3){
				queque[2] += "0";
				
			}
			if (queque.Count == 0){
				queque.Add("0");
			
			}	
		}
		if ((Button)sender == Btn1){
			if(queque.Count == 1){
				queque[0] += "1";
				
			}
			if (queque.Count == 3){
				queque[2] += "1";
				
			}
			if (queque.Count == 0){
				queque.Add("1");
			
			}
		}
		if ((Button)sender == Btn2){
			if(queque.Count == 1){
				queque[0] += "2";
				
			}
			if (queque.Count == 3){
				queque[2] += "2";
				
			}
			if (queque.Count == 0){
				queque.Add("2");
			
			}
		}
		if ((Button)sender == Btn3){
			if(queque.Count == 1){
				queque[0] += "3";
				
			}
			if (queque.Count == 3){
				queque[2] += "3";
				
			}
			if (queque.Count == 0){
				queque.Add("3");
			
			}
		}
		if ((Button)sender == Btn4){
			if(queque.Count == 1){
				queque[0] += "4";
				
			}
			if (queque.Count == 3){
				queque[2] += "4";
				
			}
			if (queque.Count == 0){
				queque.Add("4");
			
			}
		}
		if ((Button)sender == Btn5){
			if(queque.Count == 1){
				queque[0] += "5";
				
			}
			if (queque.Count == 3){
				queque[2] += "5";
				
			}
			if (queque.Count == 0){
				queque.Add("5");
			
			}
		}
		if ((Button)sender == Btn6){
			if(queque.Count == 1){
				queque[0] += "6";
				
			}
			if (queque.Count == 3){
				queque[2] += "6";
				
			}
			if (queque.Count == 0){
				queque.Add("6");
			
			}	
		}
		if ((Button)sender == Btn7){
			if(queque.Count == 1){
				queque[0] += "7";
				
			}
			if (queque.Count == 3){
				queque[2] += "7";
				
			}
			if (queque.Count == 0){
				queque.Add("7");
			
			}
		}
		if ((Button)sender == Btn9){
			if(queque.Count == 1){
				queque[0] += "9";
				
			}
			if (queque.Count == 3){
				queque[2] += "9";
				
			}
			if (queque.Count == 0){
				queque.Add("9");
			
			}
		}
		if ((Button)sender == ClearAllBtn ){
			current = "";
			current1 = "";
			current2 = "";
			operation = "";
			queque.Clear();
		}

		if ((Button)sender == ClearSecBtn){
			if (queque.Count != 0){
				queque.RemoveAt(queque.Count - 1);
			}
		}

		if ((Button)sender == PercentBtn){
			if(queque.Count == 1){
				double tmp = double.Parse(queque[0]);
				tmp = tmp / 100;
				queque[0] = tmp.ToString();
			}
		}

		if ((Button)sender == ClearCharBtn){
			if (queque.Count == 3){
				if(queque[2].Count() != 0){
					queque[2] = queque[2].Remove(queque[2].Count() - 1);
				}
				else{
					queque.RemoveAt(2);
				}
			}
			else if (queque.Count == 2){
				queque.RemoveAt(1);
			}
			else if (queque.Count == 1){
				if(queque[0].Count() != 0){
					queque[0] = queque[0].Remove(queque[0].Count() - 1);
				}
				else{
					queque.RemoveAt(0);
				}
			}
		} 

			current = "";
			foreach(var i in queque){
				current += i;
			}
			ShowLabel.Text = current;
			SemanticScreenReader.Announce(ShowLabel.Text);
		
	}
}

