using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace expectedValue_Calculator
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<double, double> ProbabilityDictionary = new Dictionary<double, double>();
            ProbabilityDictionary.Add(-2, 0.0078125);
            ProbabilityDictionary.Add(-1.5, 0.078125);
            ProbabilityDictionary.Add(-1, 0.078125);
            ProbabilityDictionary.Add(-0.5, 0.05078125);
            ProbabilityDictionary.Add(0, 0.578125);
            ProbabilityDictionary.Add(0.5, 0.05078125);
            ProbabilityDictionary.Add(1, 0.0703125);
            ProbabilityDictionary.Add(1.5, 0.078125);
            ProbabilityDictionary.Add(2, 0.0078125);
            Dictionary<double, double> MoneyGainedDictionary = new Dictionary<double, double>();
            MoneyGainedDictionary.Add(-2, 3);
            MoneyGainedDictionary.Add(-1.5, 3);
            MoneyGainedDictionary.Add(-1, 3);
            MoneyGainedDictionary.Add(-0.5, 3);
            MoneyGainedDictionary.Add(0, 3);
            MoneyGainedDictionary.Add(0.5, 1);
            MoneyGainedDictionary.Add(1, 0);
            MoneyGainedDictionary.Add(1.5, -1);
            MoneyGainedDictionary.Add(2, -7);

            double currentScore = 0;
            double expectedValue = 0;
            double RoundExpectedValue = 0;
            double ScoreProbability;
            double[] possibility = new double[] { -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2 };
            double totalProbability=0;
            double bonusProbability = 0;
            double average = 0;
            double Variance = 0;
            double StdDev = 0;
            double sum = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        ScoreProbability = ProbabilityDictionary[possibility[i]] * ProbabilityDictionary[possibility[k]] * ProbabilityDictionary[possibility[j]];
                        totalProbability = totalProbability + ScoreProbability;
                        currentScore = possibility[i] + possibility[k] + possibility[j];
                        if (currentScore > 2)
                            currentScore = 2;
                        if (currentScore < -2)
                            currentScore = -2;
                        RoundExpectedValue = ScoreProbability * MoneyGainedDictionary[currentScore];
                        sum = MoneyGainedDictionary[currentScore] - 1.310;
                        sum = sum * sum;
                        Variance = sum + Variance;
                        average++;
                        expectedValue = expectedValue + RoundExpectedValue;
                        Console.WriteLine(possibility[i] + "," + possibility[k] + "," + possibility[j] + ",      " + expectedValue);
                    }
                }

            }
            for (int i = 5; i < 9; i++)
            {
                for (int k = 5; k < 9; k++)
                {
                    for (int j = 5; k < 9; k++)
                    {
                        ScoreProbability = ProbabilityDictionary[possibility[i]] * ProbabilityDictionary[possibility[k]] * ProbabilityDictionary[possibility[j]];
                        bonusProbability = ScoreProbability + bonusProbability;
                        currentScore = possibility[i] + possibility[k] + possibility[j];
                        if (currentScore > 2)
                            currentScore = 2;
                        if (currentScore < -2)
                            currentScore = -2;
                        RoundExpectedValue = ScoreProbability * MoneyGainedDictionary[currentScore];
                        expectedValue = expectedValue - RoundExpectedValue;
                        sum = MoneyGainedDictionary[currentScore] - 1.310;
                        sum = sum * sum;
                        Variance = Variance - sum;
                        RoundExpectedValue = ScoreProbability * (MoneyGainedDictionary[currentScore] - 10);
                        expectedValue = expectedValue + RoundExpectedValue;
                        sum = (MoneyGainedDictionary[currentScore] - 10) - 1.310;
                        sum = sum * sum;
                        Variance = Variance + sum;
                        Console.WriteLine(expectedValue);
                    }
                }
            }
            StdDev = Variance / average;
            StdDev = Math.Sqrt(StdDev);
            Console.WriteLine("FINAL");
            Console.WriteLine(expectedValue);
            Console.WriteLine("StdDev:" + StdDev);
            Console.WriteLine("DONE");
            Console.WriteLine(totalProbability);
            Console.Read();
        }
    }
}
