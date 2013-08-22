using System;
using System.Collections.Generic;

namespace ChangeMachineProblem
{
    public class ChangeMachine
    {
        private static readonly double[] _denominations = {20.00, 10.00, 5.00, 1.00, 0.25, 0.10, 0.05, 0.01};

        public IDictionary<double, int> MakeChange(double amount, double? wantCoin = null)
        {
            var results = new Dictionary<double, int>();

            if (amount <= .01 || amount > 20.00)
            {
                throw new ArgumentException();
            }

            var amountLeft = amount;

            if (wantCoin.HasValue)
            {
                results.Add(wantCoin.Value, 1);
                amountLeft = Math.Round(amountLeft - wantCoin.Value, 2);
            }

            var startingPoint = 0;
            for (var i = 0; i < _denominations.Length; i++)
            {
                if (_denominations[i] >= amount)
                {
                    continue;
                }

                startingPoint = i;
                break;
            }

            for (var i = startingPoint; i < _denominations.Length; i++)
            {
                var denomination = _denominations[i];

                var coins = (int) Math.Floor(amountLeft / denomination);
                amountLeft = Math.Round(amountLeft - (coins * denomination), 2);
                if (results.ContainsKey(denomination))
                    results[denomination] += coins;
                else
                    results.Add(denomination, coins);
            }

            return results;
        }
    }
}
