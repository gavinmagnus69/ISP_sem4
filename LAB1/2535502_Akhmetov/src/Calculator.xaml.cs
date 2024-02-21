
namespace _2535502_Akhmetov;
public partial class Calculator : ContentPage
{
	string current = "";
	string answer = "null";
	string error = "ERROR";

	bool error_state = false;
	List<string> queque;



	//bool int_state = true; ?
	public Calculator()
	{
		InitializeComponent();
		queque = new();
	}

	private bool FloatCheck(string opr){
		if(opr.Contains(".")){
			return true;
		}
		return false;
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
			if (queque.Count == 0 || queque.Count == 2){
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
			if (queque.Count == 0 || queque.Count == 2){
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
			if (queque.Count == 0 || queque.Count == 2){
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
			if (queque.Count == 0 || queque.Count == 2){
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
			if (queque.Count == 0 || queque.Count == 2){
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
			if (queque.Count == 0 || queque.Count == 2){
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
			if (queque.Count == 0 || queque.Count == 2){
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
			if (queque.Count == 0 || queque.Count == 2){
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
			if (queque.Count == 0 || queque.Count == 2){
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
			if (queque.Count == 0 || queque.Count == 2){
				queque.Add("9");
			
			}
		}
		if ((Button)sender == ClearAllBtn ){
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

		if( (Button)sender == XDivBtn){
			if (queque.Count == 1){
				double tmp = double.Parse(queque[0]);
				if(tmp != 0){
					tmp = 1 / tmp;
					queque[0] = tmp.ToString();

				}
				else{
					error_state = true;
					answer = error;
					queque.Clear();
				}	
			}
		}

		if ((Button)sender == Pow2Btn){
			if (queque.Count == 1){
				double tmp = double.Parse(queque[0]);
				tmp = Math.Pow(tmp, 2);
				queque[0] = tmp.ToString();
			}
		}
		if ((Button)sender == DivBtn){
			if (queque.Count == 1){
				queque.Add("/");
			}
		}

		if((Button)sender == MulBtn){
			if (queque.Count == 1){
				queque.Add("*");
			}
		}

		if((Button)sender == AddBtn){
			if (queque.Count == 1){
				queque.Add("+");
			}
		}

		if ((Button)sender == SubBtn){
			if (queque.Count == 1){
				queque.Add("-");
			}
		}

		if((Button)sender == SqrBtn){
			if (queque.Count == 1){
				double tmp = double.Parse(queque[0]);
				if(tmp >= 0){
					tmp = Math.Pow(tmp, 0.5);
					answer = tmp.ToString();
				}
				else{
					error_state = true;
					answer = error;
				}

			}
		}

		if((Button)sender == Pow10Btn){
			if(queque.Count == 1){
				double tmp = double.Parse(queque[0]);
				tmp = Math.Pow(10, tmp);
				answer = tmp.ToString();
			}
		}

		if ((Button)sender == ChngBtn){
			if (queque.Count == 1){
				double tmp = double.Parse(queque[0]);
				tmp *= -1;
				queque[0] = tmp.ToString();
			}
			if (queque.Count == 3){
				double tmp = double.Parse(queque[2]);
				tmp *= -1;
				queque[2] = tmp.ToString();
			}
		}

		if((Button)sender == ComBtn){
			if (queque.Count == 1){
				if (!FloatCheck(queque[0])){
					queque[0] += ".";
				}
			}
			else if(queque.Count == 0){
				queque.Add("0.");
			}
			else if(queque.Count == 3){
				if(!FloatCheck(queque[2])){
					queque[2] += ".";
				}
			}
		}

		// = handling
		if((Button)sender == CalcBtn){
			if(queque.Count == 3){
				double equ1 = double.Parse(queque[0]);
				double equ2 = double.Parse(queque[2]);
				double ans = 0;
				if(queque[1] == "/"){
					if(equ2 != 0){
						ans = equ1 / equ2;
						answer = ans.ToString();
					}
					else{
						error_state = true;
						answer = error;
						//queque.Clear();
					}
				}
				if(queque[1] == "*"){
					ans = equ1 * equ2;
					answer = ans.ToString();
				}
				if(queque[1] == "+"){
					ans = equ1 + equ2;
					answer = ans.ToString();
				}
				if(queque[1] == "-"){
					ans = equ1 - equ2;
					answer = ans.ToString();
				}
			}



		}

			//show queque in gui first label
			current = "";
			if (error_state){
				ShowLabel.Text = "Occured some";
				//error_state = false;
			}
			else{
				foreach(var i in queque){
					current += i;
				}
				ShowLabel.Text = current;
			}

			
			SemanticScreenReader.Announce(ShowLabel.Text);



			//show answer in gui second label
			if (answer != "null"){
				AnswerLabel.Text = answer;
				//SemanticScreenReader.Announce(AnswerLabel.Text);
				queque.Clear();
				if(!error_state){
					queque.Add(answer);
				}
				error_state = false;
				answer = "null";
			}
			else{
				AnswerLabel.Text = "";
				//SemanticScreenReader.Announce(AnswerLabel.Text);
			}
	}
}