using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace expectedValue_Calculator
{
    class Program
    {

        static void Main(string[] args)
        {   /* This creates a dictionary which will be referenced later, it assigns the probability of getting a certain score to said score
             * The individual probabilities were calculated assuming that the payer chooses his pokemon at random
             * I then calculated all the possible scores, and for each seperat score divided [amount score shows up]/[total amount of scores]
             */ 
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
                        
            /*
             This also creates a dictionary which assigned the total amount of money gained by the computer for each overall score
             *It is based on the initial $6 gained (due to the player choosing 6 different PokeType at a rate of 1$/PokeType), and so even if, for example
             the player sores a 1 and the computer pays out $3, it has still earned $3.
             */ 
            Dictionary<double, double> MoneyGainedDictionary = new Dictionary<double, double>();
            MoneyGainedDictionary.Add(-2, 6);
            MoneyGainedDictionary.Add(-1.5, 6);
            MoneyGainedDictionary.Add(-1, 6);
            MoneyGainedDictionary.Add(-0.5, 6);
            MoneyGainedDictionary.Add(0, 6);
            MoneyGainedDictionary.Add(0.5, 4);
            MoneyGainedDictionary.Add(1, 3);
            MoneyGainedDictionary.Add(1.5, 2);
            MoneyGainedDictionary.Add(2, -4);

          
            double[] possibility = new double[] { -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2 }; /*This is an array of numbers. This creates 9 sepereat variables, each with
            the same name but a different index number. the name is "possibility" meanwhile the index number goes within the []... so for example possibility[0] = -2, and
             possibility[8] = 2.*/
            //The rest are variables that will be explained as they come up.
            double currentScore = 0;
            double expectedValue = 0;
            double RoundExpectedValue = 0;
            double ScoreProbability;
            double totalProbability = 0;
            double average = 0;
            double sum = 0;
            double Variance =0;
            double StdDev = 0;
            for (int i = 0; i < 9; i++)

            { /*this is called a for loop, it will run everything inside it until the true condition becoems false, in this case 
               the true condition is that the variable i, which sttarts off as 0, is less than 9. The variable i is then incrememnted up by one everytime
               the loop runs through.
               */ 
                for (int k = 0; k < 9; k++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        for (int f = 0; f < 9; f++)
                        {
                            for (int g = 0; g < 9; g++)
                            {//each of these above loops (and the one below) do the same thing - only the variable has a different name. 
                                for (int h = 0; h < 9; h++)
                                {
                                    /*score probability holds the probability for a certain outcome
                                     It uses the Dictionary for Probability above to calculate the probabiltiy of getting any set of scores.
                                     Example: Assuming this is the first time running through in which i=0,k=0,j=0,f=0, g=0 and h=0, the score probability would be:
                                     ScoreProbability = ProbabilityDictionary(possibility[0])^6. possibility[0] as stated above is equal to -2. The -2 is then plugged into the
                                     ProbabilityDictionary which returns the probability and so the equatino is really:
                                     Score probability = (0.0078125)^6. 0.0078125 is the probability of receiving a -2 once.
                                     This is loop is run 9^6 or 531441 times, running through all possibly combinations.
                                     *      the second run would be i=0,k=0,j=0,f=0, g=0 and h=1, and so ScoreProbability = ProbabilityDictionary(possibility[0])^5 *
                                     *      ProbabilityDictionary(possibility[1]) or (0.0078125)^5 * 0.078125 (the probability for getting a -1.5)....and so on.
                                     */
                                    ScoreProbability = ProbabilityDictionary[possibility[i]] * ProbabilityDictionary[possibility[k]] * ProbabilityDictionary[possibility[j]] * ProbabilityDictionary[possibility[f]] * ProbabilityDictionary[possibility[g]] * ProbabilityDictionary[possibility[h]];
                                    totalProbability = totalProbability + ScoreProbability; /*this keeps track of the total probability and really has no purpose other then to 
                                                                                              check that it adds up to 1 at the end meaning that nothing was skipped. It is a check*/
                                    //CurrentScore is the overall score for a certain game
                                    currentScore = possibility[i] + possibility[k] + possibility[j] + possibility[f] + possibility[g] + possibility[h];
                                    //If a score is above 2 or below -2, the player's monetary winnings or losings does not change and so this does not allow it to exceed either value.
                                    if (currentScore > 2)
                                        currentScore = 2;
                                    if (currentScore < -2)
                                        currentScore = -2;
                                    //RoundExpectedValue is the the expected value for any given round. It is calculated by multiplying the probability of each score by the money gained
                                    RoundExpectedValue = ScoreProbability * MoneyGainedDictionary[currentScore];
                                   //sum is the name given to a single variance which is calculated by: (amount of money gained - average money gained)^2 for each possible combination
                                    sum = MoneyGainedDictionary[currentScore] - 3.584198;
                                    sum = sum * sum;
                                    //variance keeps track of the total variances added together
                                    Variance = sum + Variance;
                                    //this counts how many different combinations there are and will later divide into the the sum of the variances
                                    average++;
                                    expectedValue = RoundExpectedValue + expectedValue;
                                    Console.WriteLine(possibility[i] + "," + possibility[k] + "," + possibility[j] + "," + possibility[f] + "," + possibility[g] + ","+ possibility[h] + ",      " + RoundExpectedValue);
                                }
                            }
                        }
                    }
                }

            }
            //This part is to incorperate the chance at a bonus. 
            for (int i = 5; i < 9; i++)
            {
                for (int k = 5; k < 9; k++)
                {
                    for (int j = 5; k < 9; k++)
                    {
                        for (int f = 5; f < 9; f++)
                        {
                            for (int g = 5; g < 9; g++)
                            {
                                for (int h = 5; h < 9; h++)
                                {/*
                                  The idea is rougly the same as above. ScoreProbability is calculated in the same way, only it only uses values pf 0.5 and above (situations where the 
                                  bonus is earned).
                                  */
                                    ScoreProbability = ProbabilityDictionary[possibility[i]] * ProbabilityDictionary[possibility[k]] * ProbabilityDictionary[possibility[j]] * ProbabilityDictionary[possibility[f]] * ProbabilityDictionary[possibility[g]] * ProbabilityDictionary[possibility[h]];
                                    currentScore = possibility[i] + possibility[k] + possibility[j] + possibility[f] + possibility[g] + possibility[h];
                                    if (currentScore > 2)
                                        currentScore = 2;
                                    if (currentScore < -2)
                                        currentScore = -2;
                                    RoundExpectedValue = ScoreProbability * MoneyGainedDictionary[currentScore];
                                    /*
                                    Here I subtract the expected value pre-bonus of the round from the overall expected vaue. This is necessary because this set of scores would have
                                    already been incorperated in the the expected value, and so adding them back in with the bonus, but without taking them out first would create an erro
                                    because they are being counted twice.
                                    */
                                    expectedValue = expectedValue - RoundExpectedValue;
                                    //Needs to be subtracted from variance too
                                    sum = 3.584198 - MoneyGainedDictionary[currentScore];
                                    sum = sum * sum;
                                    Variance = Variance - sum;
                                    //the RoundExpectedValue is recalculated with the extra $100 bonus included, so is the variance.5
                                    RoundExpectedValue = ScoreProbability * (MoneyGainedDictionary[currentScore] - 100);
                                    sum = 3.584198 - (MoneyGainedDictionary[currentScore] - 100);
                                    sum = sum * sum;
                                    Variance = Variance + sum;
                                    expectedValue = expectedValue + RoundExpectedValue;
                                    Console.WriteLine(expectedValue);
                                }
                            }
                        }
                    }
                }
            }
            StdDev = Variance / average; // this takes the average of the variances, and puts it into the variable StdDev
            StdDev = Math.Sqrt(StdDev);  //takes the square root of the the average of the variances and assigns it to the StdDev. This is the Standard Deviations.
            Console.WriteLine("FINAL");
            Console.WriteLine(expectedValue);
            Console.WriteLine("StdDev:" + StdDev);
            Console.WriteLine("DONE");
            Console.WriteLine(totalProbability);
            Console.Read();
        }
    }
}
