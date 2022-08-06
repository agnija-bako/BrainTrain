using System;
using System.Windows;
using System.Data;

namespace BrainTrain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            formula_text.Text = generateFormula(null, "*");
            result_txt.Text = string.Empty;
            evaluation_txt.Text = string.Empty;
            description_txt.Text = "Add additional operations to the expression by clicking on one of the operator buttons below. To reset the numbers in the expression click RESET. To start a new expression click NEW.";

        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            formula_text.Text = UpdateNumbers(formula_text.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new ();
            object correctAnswer = dt.Compute(formula_text.Text, "");
            if (result_txt.Text.Equals(correctAnswer.ToString()))
            {
                evaluation_txt.Text = "Correct";
                return;
            }
            
            evaluation_txt.Text = $"Wrong, the answer is {correctAnswer}";
        }

        private void btn_new_Click(object sender, RoutedEventArgs e)
        {
            formula_text.Text = generateFormula(null, "*");
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            formula_text.Text = generateFormula(formula_text.Text, "-");
        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            formula_text.Text = generateFormula(formula_text.Text, "+");
        }

        private void btn_multiply_Click(object sender, RoutedEventArgs e)
        {
            formula_text.Text = generateFormula(formula_text.Text, "*");
        }

        private void btn_divide_Click(object sender, RoutedEventArgs e)
        {
            formula_text.Text = generateFormula(formula_text.Text, "/");
        }

        private int generateNumber()
        {
            return new Random().Next(1,9);
        }

        private string generateFormula(string? formula, string formula_operator)
        {
            return formula == null ? $"{generateNumber()} {formula_operator} {generateNumber()}" 
                                   : $"{formula} {formula_operator} {generateNumber()}";
        }

        private string UpdateNumbers(string formula)
        {
            string newFormula = string.Empty;
            for (int i = 0; i < formula.Length; i++)
            {
                if (char.IsDigit(formula[i])) 
                {
                    newFormula += generateNumber();
                    continue;
                } 
                newFormula += formula[i];                
            }

            return newFormula;
        }
    }
}
