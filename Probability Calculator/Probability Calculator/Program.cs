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
            MoneyGainedDictionary.Add(-2, 2);
            MoneyGainedDictionary.Add(-1.5, 2);
            MoneyGainedDictionary.Add(-1, 2);
            MoneyGainedDictionary.Add(-0.5, 2);
            MoneyGainedDictionary.Add(0, 2);
            MoneyGainedDictionary.Add(0.5, 0);
            MoneyGainedDictionary.Add(1, -1);
            MoneyGainedDictionary.Add(1.5, -2);
            MoneyGainedDictionary.Add(2, -8);
   
            double currentScore=0;
            double expectedValue = 0;
            double RoundExpectedValue =0;
            double ScoreProbability;
            double totalProbability = 0;
            double bonusProbability = 0;
            double[] possibility = new double[] { -2, -1.5,-1, -0.5, 0, 0.5, 1, 1.5, 2 };
            double average = 0;
            double sum = 0;
            double Variance =0;
            double StdDev = 0;
            for (int i = 0; i<9; i++)
            {
                for (int k = 0; k<9; k++)
                {

                    ScoreProbability = ProbabilityDictionary[possibility[i]] * ProbabilityDictionary[possibility[k]];
                    totalProbability = totalProbability + ScoreProbability;
                    currentScore = possibility[i] + possibility[k];
                    if (currentScore > 2)
                        currentScore = 2;
                    if (currentScore < -2)
                        currentScore = -2;
                    RoundExpectedValue = ScoreProbability * MoneyGainedDictionary[currentScore];
                    sum = MoneyGainedDictionary[currentScore] - 0.6189;
                    sum = sum * sum;
                    Variance = sum + Variance;
                    average++;
                    expectedValue = expectedValue + RoundExpectedValue;
                }
                
            }
            for (int i = 5; i < 9; i++)
            {
                for (int k = 5; k < 9; k++)
                {
                    ScoreProbability = ProbabilityDictionary[possibility[i]] * ProbabilityDictionary[possibility[k]];
                    bonusProbability = ScoreProbability + bonusProbability;
                    currentScore = possibility[i] + possibility[k];
                    if (currentScore > 2)
                        currentScore = 2;
                    if (currentScore < -2)
                        currentScore = -2;
                    RoundExpectedValue = ScoreProbability * MoneyGainedDictionary[currentScore];
                    expectedValue = expectedValue - RoundExpectedValue;
                    sum = 0.6189 - MoneyGainedDictionary[currentScore];
                    sum = sum * sum;
                    Variance = Variance - sum;
                    RoundExpectedValue = ScoreProbability * (MoneyGainedDictionary[currentScore] - 3);
                    sum = 0.6189 - (MoneyGainedDictionary[currentScore]-3);
                    sum = sum * sum;
                    Variance = Variance + sum;
                    expectedValue = expectedValue + RoundExpectedValue;
                    Console.WriteLine(expectedValue);
                }
            }
            StdDev = Variance / average;
            StdDev = Math.Sqrt(StdDev);
            Console.WriteLine(expectedValue);
            Console.WriteLine("StdDev:" + StdDev);
            Console.WriteLine("P:"+totalProbability);
            Console.Read();
        }
    }
}
