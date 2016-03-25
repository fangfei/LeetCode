using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeEasy
{
    class ExecutionClass
    {
        static void Main(string[] args)
        {
        }
    }

    public class LeetCodeEasySolution
    {
        public bool Leet292_CanWinNim(int n)
        {
            if (n <= 0)
            {
                return false;
            }

            // With less than 4 left, will always win the game
            // for any # lager than 4, as long as it is not 4*i, will win
            return n % 4 != 0;
        }

        public int Leet258_AddDigits(int num)
        {
            if (num<=0)
            {
                return num;
            }

            int rst = Leet258_helper(num);
            while (rst > 9)
            {
                rst = Leet258_helper(rst);
            }
            return rst;
        }

        private int Leet258_helper(int n)
        {
            int rst = 0;
            while (n > 0)
            {
                rst += n % 10;
                n = n / 10;
            }
            return rst;
        }
    }
}
