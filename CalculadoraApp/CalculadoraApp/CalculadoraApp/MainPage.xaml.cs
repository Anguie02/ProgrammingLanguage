using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculadoraApp
{
    public partial class MainPage : ContentPage
    {
        string currentNumber = string.Empty;
        double firstNumber, secondNumber;
        string operation;
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentNumber += button.Text;
            resultLabel.Text = currentNumber;
        }

        void OnOperatorClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            firstNumber = double.Parse(currentNumber);
            operationLabel.Text += currentNumber + " " + operation ; // Mostrar la operación actual
            resultLabel.Text = string.Empty; // Limpiar el contenido del resultado
            currentNumber = string.Empty;
        }

        void OnClearClicked(object sender, EventArgs e)
        {
            currentNumber = string.Empty;
            operation = string.Empty;
            resultLabel.Text = "0";
            operationLabel.Text = string.Empty;
        }

        void OnCalculateClicked(object sender, EventArgs e)
        {
            secondNumber = double.Parse(currentNumber);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "×":
                    result = firstNumber * secondNumber;
                    break;
                case "÷":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                    {
                        resultLabel.Text = "Error";
                        operationLabel.Text = string.Empty; // Limpiar operationLabel en caso de error
                        return; // Salir del método para evitar que se actualice currentNumber
                    }

                    break;
            }

            resultLabel.Text = result.ToString(); // Actualizar el resultado en resultLabel
            operationLabel.Text += " " + secondNumber + " = " ; // Mostrar la operación completa en operationLabel
            currentNumber = result.ToString();
        }
    }
}
