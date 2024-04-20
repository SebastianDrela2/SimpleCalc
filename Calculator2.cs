namespace Test
{
    // 1 + 5 + 5 - 10
    // (number) (operator) (number)
    internal struct Calculator2(int totalValue = 0)
    {
        private int _totalValue = totalValue;

        public readonly int TotalValue => _totalValue;

        public void Calculate(ReadOnlySpan<char> rest)
        {
            var chunk = TakeChunk(ref rest);
            var num = int.Parse(chunk);

            _totalValue = num;

            CalculateNext(rest);
        }

        public void CalculateNext(ReadOnlySpan<char> rest)
        {
            while (!rest.IsEmpty)
            {
                var opChunk = TakeChunk(ref rest);
                var num = int.Parse(TakeChunk(ref rest));

                switch (opChunk)
                {
                    case ['+']:
                        _totalValue += num;
                        break;

                    case ['-']:
                        _totalValue -= num;
                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        private static ReadOnlySpan<char> TakeChunk(ref ReadOnlySpan<char> rest)
        {
            var index = rest.IndexOf(' ');

            if (index is -1)
            {
                var tmp = rest;
                rest = [];

                return tmp;
            }

            var result = rest.Slice(0, index);
            rest = rest.Slice(index + 1);

            return result;
        }
    }

    file enum OpType
    {
        Plus,
        Minus
    }
}
