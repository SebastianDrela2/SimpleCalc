namespace Test
{
    internal class Calculator
    {
        // 1 + 5 + 5 - 10
        // (number) (operator) (number)

        public int Calculate(string text)
        {            
            var elements = text.Split(' ');
            var currentList = new List<string>();
            
            foreach(var element in elements)
            {              
                if (currentList.Count == 3)
                {
                    var tmp = GetResult(currentList);

                    currentList.Clear();
                    currentList.Add(tmp.ToString());
                }

                currentList.Add(element);
            }

            var result = GetResult(currentList);

            return result;
        }

        private int GetResult(List<string> currentList)
        {
            var number = int.Parse(currentList[0]);
            var number2 = int.Parse(currentList[2]);
            var op = currentList[1];

            if (op is "+")
            {
                return number + number2;
            }

            if (op is "-")
            {
                return number - number2;
            }

            return -1;
        }
    }
}
