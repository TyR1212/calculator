using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalcForm : Form
    {
        Calculator calc = new Calculator();

        public CalcForm()
        {
            InitializeComponent();
            RefreshOutput();
        }
        
        private void RefreshOutput()
        {
            calcOutputLabel.Text = calc.Total;
        }
       
        //button clicks
        private void oneButton_Click(object sender, EventArgs e)
        {
            if(!calc.IsOperatorSelected)
                calc.AppendToLeftNum("1");
            else
                calc.AppendToRightNum("1");
             
            RefreshOutput();
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum("2");
            else
                calc.AppendToRightNum("2");

            RefreshOutput();
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum("3");
            else
                calc.AppendToRightNum("3");

            RefreshOutput();
        }
        private void fourButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum("4");
            else
                calc.AppendToRightNum("4");

            RefreshOutput();
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum("5");
            else
                calc.AppendToRightNum("5");

            RefreshOutput();
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum("6");
            else
                calc.AppendToRightNum("6");

            RefreshOutput();
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum("7");
            else
                calc.AppendToRightNum("7");

            RefreshOutput();
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum("8");
            else
                calc.AppendToRightNum("8");

            RefreshOutput();
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum("9");
            else
                calc.AppendToRightNum("9");

            RefreshOutput();
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum("0");
            else
                calc.AppendToRightNum("0");

            RefreshOutput();
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            if (!calc.IsOperatorSelected)
                calc.AppendToLeftNum(".");
            else
                calc.AppendToRightNum(".");

            RefreshOutput();
        }

        private void additionButton_Click(object sender, EventArgs e)
        {
            if (calc.IsReadyToCalculate)
                calc.CalculateTotal();
            
            calc.SetOperator(OperatorType.ADD);

            RefreshOutput();
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            if (calc.IsReadyToCalculate)
                calc.CalculateTotal();

            calc.SetOperator(OperatorType.SUBTRACT);

            RefreshOutput();
        }
        private void multiplyButton_Click(object sender, EventArgs e)
        {
            if (calc.IsReadyToCalculate)
                calc.CalculateTotal();

            calc.SetOperator(OperatorType.MULTIPLY);

            RefreshOutput();
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            if (calc.IsReadyToCalculate)
                calc.CalculateTotal();

            calc.SetOperator(OperatorType.DIVIDE);

            RefreshOutput();
        }

        private void inverseButton_Click(object sender, EventArgs e)
        {
            if (calc.IsReadyToCalculate)
                calc.CalculateTotal();

            if (!calc.IsOperatorSelected)
                calc.CalculateInverse();

            RefreshOutput();
        }

        private void negativeButton_Click(object sender, EventArgs e)
        {
            calc.ToggleNegative();
            RefreshOutput();
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            if (calc.IsReadyToCalculate)
            {
                calc.CalculateTotal();
                RefreshOutput();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            calc.ClearAll();
            RefreshOutput();
        }
    }
}
