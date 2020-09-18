using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    class KnapSack
    {
        public int KnapSack_Binary(int Cap, int[] wt, int[] val, int n, int[,] dp)
        {
            if (dp[n, Cap] != 0) return dp[n, Cap];
            //Base Case
            if (n == 0 || Cap == 0) return 0;

            if(wt[n-1] > Cap)
            {
                return KnapSack_Binary(Cap, wt, val, n - 1, dp);
            }
            else
            {
                // Return the maximum of two cases: 
                // (1) nth item included 
                // (2) not included
                int temp1 = val[n - 1] + KnapSack_Binary(Cap - wt[n - 1], wt, val, n - 1, dp);
                int temp2 = KnapSack_Binary(Cap, wt, val, n - 1, dp);
                int result = Math.Max(temp1, temp2);
                dp[n, Cap] = result;
                //return max(val[n-1] + KnapSack_Binary(Cap - wt[n-1], wt, val, n-1, dp),
                //    KnapSack_Binary(Cap, wt, val, n - 1,dp));
                return result;
            }
        }

        public int KnapSack_Fraction(int Cap, int[] wt, int[] val, int n)
        {
            int[] ratio = new int[val.Length];
            for (int i = 0; i<n; i++)
            {
                 ratio[i] = val[i] / wt[i];
            }

            //Bubble sort
            ///
            for (int i = 0; i < ratio.Length; i++)
            {
                for (int j = i + 1; j < ratio.Length; j++)
                {
                    if(ratio[i] < ratio[j])
                    {
                        int temp = ratio[i];
                        ratio[i] = ratio[j];
                        ratio[j] = temp;

                        int temp1 = wt[i];
                        wt[i] = wt[j];
                        wt[j] = temp1;

                        int temp2 = val[i];
                        val[i] = val[j];
                        val[j] = temp2;

                    }
                    
                }
            }
            int curWeight = 0;  // Current weight in knapsack 
            double finalvalue = 0.0;

            for (int i = 0; i < n; i++)
            { 
                if(curWeight + wt[i] <= Cap)
                {
                    curWeight = curWeight + wt[i];
                    finalvalue = finalvalue + val[i];
                }
                else
                {
                    float remainRatio = (Cap - curWeight)/wt[i];
                    finalvalue = finalvalue + (val[i] * remainRatio);
                }
            }

                return (int)finalvalue;
        }


        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
    }
}
