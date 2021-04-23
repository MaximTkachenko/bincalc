using System;

namespace BinaryCalculator.Core
{
    public sealed class Calculator
    {
        private const int MaxLength = 12;
        
        public enum Operation
        {
            None,
            Add, 
            Subtract
        }

        public string CurrentInput { get; private set; } = string.Empty;
        public Operation CurrentOperation { get; private set; } = Operation.None;
        public string CurrentResult { get; private set; } = "0";

        public Calculator EnterZero()
        {
            if (CurrentInput.Length < MaxLength)
            {
                CurrentInput += "0";
            }

            return this;
        }

        public Calculator EnterOne()
        {
            if (CurrentInput.Length < MaxLength)
            {
                CurrentInput += "1";
            }

            return this;
        }

        public Calculator Add()
        {
            if (!string.IsNullOrEmpty(CurrentInput))
            {
                PerformOperation();
            }
            
            CurrentOperation = Operation.Add;
            CurrentInput = string.Empty;
            
            return this;
        }
        
        public Calculator Subtract()
        {
            if (!string.IsNullOrEmpty(CurrentInput))
            {
                PerformOperation();
            }

            CurrentOperation = Operation.Subtract;
            CurrentInput = string.Empty;

            return this;
        }

        public Calculator ClearLastEntry()
        {
            CurrentInput = string.Empty;

            return this;
        }

        public Calculator ClearAll()
        {
            CurrentInput = string.Empty;
            CurrentOperation = Operation.None;
            CurrentResult = "0";

            return this;
        }

        public Calculator PerformOperation()
        {
            if (CurrentOperation == Operation.None)
            {
                CurrentResult = CurrentInput;
                return this;
            }
            
            var result = Convert.ToInt32(CurrentResult, 2);
            var input = Convert.ToInt32(CurrentInput, 2);

            result = CurrentOperation == Operation.Add ? result + input : result - input;
            CurrentResult = Convert.ToString(result, 2);

            return this;
        }
    }
}
