using System;
using System.Linq;

namespace BinaryCalculator.Core
{
    public class BinNum
    {
        public BinNum() { }

        public BinNum(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Any(x => x != '0' && x != '1'))
            {
                throw new ArgumentException(nameof(value));
            }

            value = value.TrimStart('0');
            if(!string.IsNullOrEmpty(value)) Value = value;
        }

        public string Value { get; private set; } = "0";

        public void AppendZero()
        {
            if (Value.Contains('1'))
            {
                Value += "0";
            }
        }

        public void AppendOne()
        {
            if (Value.Contains('1'))
            {
                Value += "1";
            }
            else
            {
                Value = "1";
            }
        }

        public bool IsEmpty() => Value == "0";

        public BinNum Add(BinNum toAdd)
        {
            var big = toAdd.Value.Length > Value.Length ? toAdd.Value : Value;
            var small = toAdd.Value.Length > Value.Length ? Value : toAdd.Value;
            var diff = big.Length - small.Length;

            bool extra = false;
            var result = string.Empty;
            for (int bigIndex = big.Length - 1; bigIndex >= 0; bigIndex--)
            {
                var bigCurrent = int.Parse(big.AsSpan().Slice(bigIndex, 1));

                var smallIndex = bigIndex - diff;
                var smallCurrent = smallIndex < 0 ? -1 : int.Parse(small.AsSpan().Slice(smallIndex, 1));

                var sum = bigCurrent;
                if (smallCurrent != -1)
                {
                    sum += smallCurrent;
                }

                if (extra) sum++;

                switch (sum)
                {
                    case 0:
                        result = "0" + result;
                        extra = false;
                        break;
                    case 1:
                        result = "1" + result;
                        extra = false;
                        break;
                    case 2:
                        result = "0" + result;
                        extra = true;
                        break;
                    case 3:
                        result = "1" + result;
                        extra = true;
                        break;
                }
            }

            if(extra) result = "1" + result;

            return new BinNum(result);
        }

        /// <summary>
        /// Does not need to support negative results.
        /// </summary>
        public BinNum Subtract(BinNum toSubtract)
        {
            var from = Value;
            var subtracted = toSubtract.Value;
            var diff = from.Length - subtracted.Length;
            
            var result = string.Empty;
            for (int fromIndex = from.Length - 1; fromIndex >= 0; fromIndex--)
            {
                var fromCurrent = int.Parse(from.AsSpan().Slice(fromIndex, 1));

                var subtractedIndex = fromIndex - diff;
                var subtractedCurrent = subtractedIndex < 0 ? 0 : int.Parse(subtracted.AsSpan().Slice(subtractedIndex, 1));

                if (fromCurrent < subtractedCurrent)
                {
                    var fromChars = from.ToCharArray();
                    for (int i = fromIndex; i >= 0; i--)
                    {
                        if (from[i] == '1')
                        {
                            fromChars[i] = '0';
                            for (int j = i + 1; j < fromIndex; j++)
                            {
                                fromChars[j] = '1';
                            }
                            break;
                        }
                    }

                    from = new string(fromChars);
                }

                var sum = Math.Abs(fromCurrent - subtractedCurrent);
                result = sum + result;
            }

            return new BinNum(result);
        }
    }
}
