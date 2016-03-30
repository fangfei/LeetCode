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
            long a = 100;
            long b = 3;
            long c = a / b;
            long d = a % b;

        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
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
