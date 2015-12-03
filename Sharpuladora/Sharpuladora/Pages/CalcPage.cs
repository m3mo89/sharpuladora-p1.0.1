﻿using System;
using Xamarin.Forms;

namespace Sharpuladora
{
	public class CalcPage : ContentPage
	{
		Grid _layout;

		Button _b0, _b1, _b2, _b3, _b4, _b5, _b6, _b7, _b8, _b9;
		Button _calculateBtn, _plusBtn, _minusBtn, _divBtn, _mulBtn, _clearBtn;
		Label _resultDisplay;

		bool textoNumero=true;
		double total=0,firstNumber=0, secondNumber=0;
		string oper="";

		public CalcPage()
		{
			_layout = CreateGridLayout();

			CreateUiElements();

			WireEvents();

			// Trick to make our calculater fullscreen
			var relativeLayout = new RelativeLayout();
			relativeLayout.Children.Add(_layout, // <= Original layout
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent(p => p.Width),
				Constraint.RelativeToParent(p => p.Height));
			Content = relativeLayout;
		}

		private void WireEvents()
		{
			_b0.Clicked += OnNumericButtonClicked;
			_b1.Clicked += OnNumericButtonClicked;
			_b2.Clicked += OnNumericButtonClicked;
			_b3.Clicked += OnNumericButtonClicked;
			_b4.Clicked += OnNumericButtonClicked;
			_b5.Clicked += OnNumericButtonClicked;
			_b6.Clicked += OnNumericButtonClicked;
			_b7.Clicked += OnNumericButtonClicked;
			_b8.Clicked += OnNumericButtonClicked;
			_b9.Clicked += OnNumericButtonClicked;


			_minusBtn.Clicked += OnControlButtonClicked;
			_plusBtn.Clicked += OnControlButtonClicked;
			_divBtn.Clicked += OnControlButtonClicked;
			_mulBtn.Clicked += OnControlButtonClicked;

			_calculateBtn.Clicked += OnControlResultButtonClicked;

			_clearBtn.Clicked += OnClearButtonClicked;
		}


		#region Events

		void OnClearButtonClicked(object sender, EventArgs e)
		{
			firstNumber = 0;
			secondNumber = 0;
			total = 0;
			oper = "";
			_resultDisplay.Text = "0";
		}

		private void OnControlButtonClicked(object sender, EventArgs e)
		{
			Button botonClickeado = (Button)sender;
			oper = botonClickeado.Text;
			textoNumero = true;
			firstNumber = double.Parse (_resultDisplay.Text);
		}

		private void OnControlResultButtonClicked(object sender, EventArgs e)
		{
			secondNumber = double.Parse (_resultDisplay.Text);
			textoNumero = true;

			switch (oper) {
				case "+":
					total = firstNumber + secondNumber;
					_resultDisplay.Text = "" + total.ToString ();
					break;
				case "-":
					total = firstNumber - secondNumber;
					_resultDisplay.Text = "" + total.ToString ();
					break;
				case "*":
					total = firstNumber * secondNumber;
					_resultDisplay.Text = "" + total.ToString ();
					break;
				case "/":
					total = firstNumber / secondNumber;
					_resultDisplay.Text = "" + total.ToString ();
					break;

			}
		}

		void OnNumericButtonClicked(object sender, EventArgs e)
		{
			Button botonClickeado = (Button)sender;
			if (botonClickeado.Text=="0" && _resultDisplay.Text=="0") {
				return;
			}

			if (textoNumero) {
				_resultDisplay.Text = "";
				_resultDisplay.Text = "" + botonClickeado.Text;
				textoNumero = false;
			} else {
				_resultDisplay.Text += "" + botonClickeado.Text;
			}
		}

		#endregion


		private void CreateUiElements()
		{
			_resultDisplay = new Label
			{
				FontSize = 40,
				Text = "0"
			};
			Grid.SetColumnSpan(_resultDisplay, 4);
			_layout.Children.Add(_resultDisplay);

			#region Numeric buttons

			_b0 = new Button { Text = "0" };
			Grid.SetColumn(_b0, 1);
			Grid.SetRow(_b0, 4);
			_layout.Children.Add(_b0);

			_b1 = new Button { Text = "1" };
			Grid.SetColumn(_b1, 0);
			Grid.SetRow(_b1, 3);
			_layout.Children.Add(_b1);

			_b2 = new Button { Text = "2" };
			Grid.SetColumn(_b2, 1);
			Grid.SetRow(_b2, 3);
			_layout.Children.Add(_b2);

			_b3 = new Button { Text = "3" };
			Grid.SetColumn(_b3, 2);
			Grid.SetRow(_b3, 3);
			_layout.Children.Add(_b3);

			// TODO: add missing buttons
			_b4 = new Button { Text = "4" };
			Grid.SetColumn(_b4, 0);
			Grid.SetRow(_b4, 2);
			_layout.Children.Add(_b4);

			_b5 = new Button { Text = "5" };
			Grid.SetColumn(_b5, 1);
			Grid.SetRow(_b5, 2);
			_layout.Children.Add(_b5);

			_b6 = new Button { Text = "6" };
			Grid.SetColumn(_b6, 2);
			Grid.SetRow(_b6, 2);
			_layout.Children.Add(_b6);

			_b7 = new Button { Text = "7" };
			Grid.SetColumn(_b7, 0);
			Grid.SetRow(_b7, 1);
			_layout.Children.Add(_b7);

			_b8 = new Button { Text = "8" };
			Grid.SetColumn(_b8, 1);
			Grid.SetRow(_b8, 1);
			_layout.Children.Add(_b8);

			_b9 = new Button { Text = "9" };
			Grid.SetColumn(_b9, 2);
			Grid.SetRow(_b9, 1);
			_layout.Children.Add(_b9);

			#endregion

			#region Control buttons
			_calculateBtn = new Button { Text = "=" };
			Grid.SetColumn(_calculateBtn, 2);
			Grid.SetRow(_calculateBtn, 4);
			_layout.Children.Add(_calculateBtn);

			_clearBtn = new Button { Text = "C" };
			Grid.SetColumn(_clearBtn, 0);
			Grid.SetRow(_clearBtn, 4);
			_layout.Children.Add(_clearBtn);

			// TODO: add missing buttons
			_divBtn = new Button { Text = "/" };
			Grid.SetColumn(_divBtn, 3);
			Grid.SetRow(_divBtn, 1);
			_layout.Children.Add(_divBtn);

			_mulBtn = new Button { Text = "*" };
			Grid.SetColumn(_mulBtn, 3);
			Grid.SetRow(_mulBtn, 2);
			_layout.Children.Add(_mulBtn);

			_minusBtn = new Button { Text = "-" };
			Grid.SetColumn(_minusBtn, 3);
			Grid.SetRow(_minusBtn, 3);
			_layout.Children.Add(_minusBtn);

			_plusBtn = new Button { Text = "+" };
			Grid.SetColumn(_plusBtn, 3);
			Grid.SetRow(_plusBtn, 4);
			_layout.Children.Add(_plusBtn);


			#endregion
		}

		private Grid CreateGridLayout()
		{
			var layout = new Grid();
			layout.HorizontalOptions = LayoutOptions.StartAndExpand;
			layout.VerticalOptions = LayoutOptions.StartAndExpand;

			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			return layout;
		}
	}
}
