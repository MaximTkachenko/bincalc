namespace BinaryCalculator.Core
{
    public sealed class Calculator
    {
        public enum Operation
        {
            None,
            Add, 
            Subtract
        }

        public Calculator() => ClearAll();

        public BinNum CurrentInput { get; private set; }
        public Operation CurrentOperation { get; private set; }
        public BinNum CurrentResult { get; private set; }

        public Calculator EnterZero()
        {
            CurrentInput.AppendZero();
            return this;
        }

        public Calculator EnterOne()
        {
            CurrentInput.AppendOne();
            return this;
        }

        public Calculator Add()
        {
            if (!CurrentInput.IsEmpty())
            {
                PerformOperation();
            }
            
            CurrentOperation = Operation.Add;
            CurrentInput = new BinNum();
            return this;
        }
        
        public Calculator Subtract()
        {
            if (!CurrentInput.IsEmpty())
            {
                PerformOperation();
            }

            CurrentOperation = Operation.Subtract;
            CurrentInput = new BinNum();
            return this;
        }

        public Calculator ClearLastEntry()
        {
            CurrentInput = new BinNum();
            return this;
        }

        public Calculator ClearAll()
        {
            CurrentInput = new BinNum();
            CurrentOperation = Operation.None;
            CurrentResult = new BinNum();
            return this;
        }

        public Calculator PerformOperation()
        {
            if (CurrentOperation == Operation.None)
            {
                CurrentResult = CurrentInput;
                return this;
            }

            CurrentResult = CurrentOperation == Operation.Add
                ? CurrentResult.Add(CurrentInput) 
                : CurrentResult.Subtract(CurrentInput);
            return this;
        }
    }
}
