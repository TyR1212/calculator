using System;

namespace Calculator
{
    enum OperatorType { ADD, SUBTRACT, MULTIPLY, DIVIDE}

    class Calculator
    {
        private string leftNum = "0";
        private string rightNum = "0";
        private OperatorType operation;

        public string Total { get; set; } = "0";    //"screen" of the calculator
        public bool IsOperatorSelected { get; set; } = false;
        public bool IsReadyToCalculate { get; set; } = false;
        public bool IsCalculationComplete { get; set; } = true;

        public void SetOperator(OperatorType type)
        {
            if (IsOperatorSelected)
                Total = Total.Substring(0, leftNum.Length);

            if (!leftNum.Equals(Double.PositiveInfinity.ToString()))
            {
                switch (type)
                {
                    case OperatorType.ADD:
                        operation = OperatorType.ADD;
                        Total += "+";
                        break;
                    case OperatorType.SUBTRACT:
                        operation = OperatorType.SUBTRACT;
                        Total += "-";
                        break;
                    case OperatorType.MULTIPLY:
                        operation = OperatorType.MULTIPLY;
                        Total += "*";
                        break;
                    case OperatorType.DIVIDE:
                        operation = OperatorType.DIVIDE;
                        Total += "/";
                        break;
                }

                IsOperatorSelected = true;
            }
        }

        public void AppendToLeftNum(string num)
        {
            if (IsCalculationComplete)
                ResetNumbers();

            if (!num.Equals(".") || (num.Equals(".") && !leftNum.Contains(".")))
            {
                if (leftNum.Equals("0"))
                {
                    leftNum = "";
                    Total = "";
                }
                if (num.Equals(".") && leftNum.Equals(""))
                {
                    leftNum += "0";
                    Total += "0";
                }

                leftNum += num;
                Total += num;
                IsCalculationComplete = false;
            }
        }

        public void AppendToRightNum(string num)
        {
            if ((num.Equals(".") && !rightNum.Contains(".")) || !num.Equals("."))
            {
                if (rightNum.Equals("0"))
                {
                    rightNum = "";
                    Total = Total.Substring(0, leftNum.Length+1);
                }

                if (num.Equals(".") && rightNum.Equals(""))
                {
                    rightNum += "0";
                    Total += "0";
                }

                rightNum += num;
                Total += num;
            }

            IsReadyToCalculate = true;
        }

        public void CalculateTotal()
        {
            double tempTotal = 0;
            double tempLeftNum = Convert.ToDouble(leftNum);
            double tempRightNum = Convert.ToDouble(rightNum);

            switch(operation)
            {
                case OperatorType.ADD:
                    tempTotal = tempLeftNum + tempRightNum;
                    break;
                case OperatorType.SUBTRACT:
                    tempTotal = tempLeftNum - tempRightNum;
                    break;
                case OperatorType.MULTIPLY:
                    tempTotal = tempLeftNum * tempRightNum;
                    break;
                case OperatorType.DIVIDE:
                    if (rightNum.Equals("0"))   //divide by zero
                        tempTotal = Double.PositiveInfinity;
                    else
                        tempTotal = tempLeftNum / tempRightNum;
                    break;
            }

            SetResults(tempTotal);
        }

        public void CalculateInverse()
        {
            double tempTotal = Convert.ToDouble(Total);

            if (!tempTotal.Equals(0) && !tempTotal.Equals(Double.PositiveInfinity))
                tempTotal = 1 / tempTotal;

            SetResults(tempTotal);
        }

        public void ToggleNegative()
        {
            if (!leftNum.Equals(Double.PositiveInfinity.ToString()))
            {
                if (!IsOperatorSelected)    //toggle negative on left number
                {
                    if (!leftNum.StartsWith("-") && !leftNum.Equals("0"))
                    {
                        leftNum = leftNum.Insert(0, "-");
                        Total = Total.Insert(0, "-");
                    }
                    else if (leftNum.StartsWith("-"))
                    {
                        leftNum = leftNum.Remove(0, 1);
                        Total = Total.Remove(0, 1);
                    }
                }
                else                        //toggle negative on right number
                {
                    if (!rightNum.StartsWith("-") && !rightNum.Equals("0"))
                    {
                        rightNum = rightNum.Insert(0, "-");
                        Total = Total.Insert(leftNum.Length + 1, "-");
                    }
                    else if (rightNum.StartsWith("-"))
                    {
                        rightNum = rightNum.Remove(0, 1);
                        Total = Total.Remove(leftNum.Length + 1, 1);
                    }
                }
            }
        }

        private void SetResults(double num)
        {
            Total = Math.Round(num, 4).ToString();
            leftNum = Total;
            rightNum = "0";

            ResetStates();
        }

        private void ResetStates()
        {
            IsOperatorSelected = false;
            IsReadyToCalculate = false;
            IsCalculationComplete = true;
        }

        public void ResetNumbers()
        {
            rightNum = "0";
            leftNum = "0";
            Total = "0";
        }

        public void ClearAll()
        {
            ResetNumbers();
            ResetStates();
        }
    }
}
