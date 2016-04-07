﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetMedium
{
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

    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class LeetMediumAndhardSolution
    {
        public IList<int> Leet094_InorderTraversal(TreeNode root)
        {
            Stack<TreeNode> s = new Stack<TreeNode>();
            List<int> rst = new List<int>();

            while (root != null || s.Count != 0)
            {
                if (root != null)
                {
                    s.Push(root);
                    root = root.left;
                }
                else
                {
                    root = s.Pop();
                    rst.Add(root.val);
                    root = root.right;
                }
            }

            return rst;
        }

        /// <summary>
        /// Assume all input words are of lower cases
        /// Using int to represent whether a specific character exists in a word
        /// For example, 1001 means 'd' and 'a' exists in a word
        /// </summary>
        /// <param name="words">words</param>
        /// <returns>results</returns>
        public int Leet318_MaxProduct(string[] words)
        {
            if (words == null || words.Length <= 1)
            {
                return 0;
            }

            int[] wordsbits = new int[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                wordsbits[i] = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    wordsbits[i] |= (1 << words[i][j] - 'a');
                }
            }

            int rst = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (((wordsbits[i] & wordsbits[j]) == 0)
                            && words[i].Length * words[j].Length > rst)
                    {
                        rst = words[i].Length * words[j].Length;
                    }
                }
            }

            return rst;
        }

        public string Leet166_FractionToDecimal(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                return "";
            }

            // use long to calculate, in case out of bound
            long num = (long)numerator;
            long den = (long)denominator;

            long a = num / den;
            long remain = num % den;

            // Perfect divide
            if (remain == 0)
            {
                return a.ToString();
            }

            num = Math.Abs(num);
            remain = Math.Abs(remain);
            den = Math.Abs(den);

            string ret = Math.Abs(a).ToString() + ".";
            Dictionary<long, long> map = new Dictionary<long, long>();

            while (remain != 0)
            {
                num = remain * 10;
                a = num / den;
                remain = num % den;
                if (!map.ContainsKey(num))
                {
                    map.Add(num, a);
                }
                else
                {
                    // break in case of repeat
                    break;
                }
            }

            if (remain == 0)
            {
                foreach (var item in map)
                {
                    ret += item.Value.ToString();
                }
            }
            else
            {
                foreach (var item in map)
                {
                    if (item.Key != num)
                    {
                        ret += item.Value.ToString();
                    }
                    else
                    {
                        ret += "(" + item.Value.ToString();
                    }
                }
                ret += ")";
            }

            int flag = (numerator ^ denominator) >> 31;
            return flag == 0 ? ret : "-" + ret;
        }

        public bool Leet331_IsValidSerialization(string preorder)
        {
            if (preorder == null)
            {
                return true;
            }
            string[] treearray = preorder.Split(',');

            int diff = 1;
            for (int i = 0; i < treearray.Length; i++)
            {
                diff--;
                if (diff < 0)
                {
                    return false;
                }
                if (!treearray[i].Equals("#"))
                {
                    diff = diff + 2;
                }
            }

            return diff == 0;
        }

        public IList<int> Leet310_FindMinHeightTrees(int n, int[,] edges)
        {
            var ret = new List<int>();
            if (n == 0)
            {
                return ret;
            }
            if (n == 1)
            {
                ret.Add(0);
                return ret;
            }
            int[] degree = new int[n];
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                graph[edges[i, 0]].Add(edges[i, 1]);
                degree[edges[i, 0]]++;
                graph[edges[i, 1]].Add(edges[i, 0]);
                degree[edges[i, 1]]++;
            }

            for (int i = 0; i < n; i++)
            {
                if (degree[i] == 1)
                {
                    queue.Enqueue(i);
                }
            }

            while (n > 2)
            {
                int sz = queue.Count;
                for (int i = 0; i < sz; i++)
                {
                    int tmp = queue.Dequeue();
                    n--;
                    foreach (var j in graph[tmp])
                    {
                        degree[j]--;
                        if (degree[j] == 1)
                        {
                            queue.Enqueue(j);
                        }
                    }
                }
            }

            while (queue.Count > 0)
            {
                ret.Add(queue.Dequeue());
            }
            return ret;
        }

        public IList<IList<int>> Leet113_PathSum(TreeNode root, int sum)
        {
            List<IList<int>> ret = new List<IList<int>>();
            if (root == null)
            {
                return ret;
            }
            List<int> path = new List<int>();

            Leet113_helper(root, sum, ref path, ref ret);
            return ret;
        }

        private void Leet113_helper(TreeNode root,
                            int sum,
                            ref List<int> path,
                            ref List<IList<int>> rst)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                if (root.val == sum)
                {
                    path.Add(root.val);
                    rst.Add(new List<int>(path));
                    path.RemoveAt(path.Count - 1);
                }
                return;
            }

            path.Add(root.val);
            Leet113_helper(root.left, sum - root.val, ref path, ref rst);
            path.RemoveAt(path.Count - 1);

            path.Add(root.val);
            Leet113_helper(root.right, sum - root.val, ref path, ref rst);
            path.RemoveAt(path.Count - 1);
        }

        public int Leet230_KthSmallest(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode p = root;
            int result = 0;

            while (stack.Count != 0 || p != null)
            {
                if (p != null)
                {
                    stack.Push(p);
                    p = p.left;
                }
                else {
                    TreeNode t = stack.Pop();
                    k--;
                    if (k == 0)
                    {
                        result = t.val;
                    }
                    p = t.right;
                }
            }

            return result;
        }

        public int Leet200_NumIslands(char[,] grid)
        {
            int row = grid.GetLength(0);
            int col = grid.GetLength(1);
            bool[,] flag = new bool[row, col];

            int rst = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i, j] == '1' && !flag[i, j])
                    {
                        rst++;
                        Leet200_helper(ref flag, grid, i, j);
                    }
                }
            }

            return rst;
        }

        private void Leet200_helper(ref bool[,] flag, char[,] grid, int r, int c)
        {
            int row = flag.GetLength(0);
            int col = flag.GetLength(1);

            if (r < 0 || c < 0 || r >= row || c >= col || flag[r, c] || grid[r, c] == '0')
            {
                return;
            }
            flag[r, c] = true;
            Leet200_helper(ref flag, grid, r, c + 1);
            Leet200_helper(ref flag, grid, r, c - 1);
            Leet200_helper(ref flag, grid, r + 1, c);
            Leet200_helper(ref flag, grid, r - 1, c);
        }

        public int Leet130_SurroundedRegions(char[,] grid)
        {
            return 1;
        }

        public IList<Interval> Leet056_merge(IList<Interval> intervals)
        {
            var res = new List<Interval>();
            intervals = intervals.OrderBy(x => x.start).ToList();

            for (int i = 0; i < intervals.Count; i++)
            {
                var newInterval = new Interval(intervals[i].start, intervals[i].end);
                while (i < intervals.Count - 1 && newInterval.end >= intervals[i + 1].start)
                {
                    newInterval.end = Math.Max(newInterval.end, intervals[i + 1].end);
                    i++;
                }

                res.Add(newInterval);
            }

            return res;
        }

        public IList<Interval> Leet057_Insert(IList<Interval> intervals, Interval newInterval)
        {
            var rst = new List<Interval>();
            var start = newInterval.start;
            var end = newInterval.end;

            for (int i = 0; i < intervals.Count; i++)
            {
                while (i < intervals.Count && !(intervals[i].end < start || end < intervals[i].start))
                {
                    start = Math.Min(start, intervals[i].start);
                    end = Math.Max(end, intervals[i].end);
                    i++;
                }
                if (i < intervals.Count) rst.Add(intervals[i]);
            }

            rst.Add(new Interval(start, end));
            return rst.OrderBy(x => x.start).ToList();
        }

        public double Leet004_FindMedianSortedArrays(int[] nums1, int[] nums2)
        {

            int[] merged = Leet004_merge(nums1, nums2);

            int size = merged.Length;

            double rst;
            if (size == 0)
            {
                return 0;
            }
            if (size == 1)
            {
                return merged[0];
            }

            if (size % 2 == 0)
            {
                rst = (merged[size / 2] + merged[size / 2 + 1]) / 2.0;
            }
            else
            {
                rst = merged[size / 2 + 1];
            }

            return rst;
        }

        private int[] Leet004_merge(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length == 0)
            {
                return nums2;
            }
            if (nums2 == null || nums2.Length == 0)
            {
                return nums1;
            }

            int[] rst = new int[nums1.Length + nums2.Length];
            int i = 0, j = 0, k = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] <= nums2[j])
                {
                    rst[k++] = nums1[i++];
                }
                else
                {
                    rst[k++] = nums2[j++];
                }
            }
            if (i == nums1.Length)
            {
                for (; j < nums2.Length; j++)
                {
                    rst[k++] = nums2[j];
                }
            }
            if (j == nums2.Length)
            {
                for (; i < nums1.Length; i++)
                {
                    rst[k++] = nums1[i];
                }
            }

            return rst;
        }

        public double Leet004_FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            int l1 = nums1.Length;
            int l2 = nums2.Length;

            if ((l1 + l2) % 2 == 0)
            {
                int m1 = Leet004_findkth(nums1, 0, l1 - 1, nums2, 0, l2 - 1, (l1 + l2) / 2);
                int m2 = Leet004_findkth(nums1, 0, l1 - 1, nums2, 0, l2 - 1, (l1 + l2) / 2+1);
                return (m1 + m2) / 2.0;
            }
            else
            {
                return Leet004_findkth(nums1, 0, l1 - 1, nums2, 0, l2 - 1, (l1 + l2) / 2+1) / 1.0;
            }
        }

        private int Leet004_findkth(int[] nums1, int nums1Start, int nums1End,
                              int[] nums2, int nums2Start, int nums2End,
                              int k)
        {
            int sizeNums1 = nums1End - nums1Start +1;
            int sizeNums2 = nums2End - nums2Start +1;
            if (nums1Start>nums1End)
            {
                return nums2[Math.Max(Math.Min(nums2End, k-1 ), 0)];
            }
            if (nums2Start > nums2End)
            {
                return nums1[Math.Max(Math.Min(nums1End, k-1 ), 0)];
            }
            if (sizeNums1 > sizeNums2)
            {
                return Leet004_findkth(nums2, nums2Start, nums2End, nums1, nums1Start, nums1End, k);
            }

            if (sizeNums1 == 0 && sizeNums2 > 0)
            {
                return nums2[nums2End];
            }

            if (k <= 1)
            {
                return Math.Min(nums1[nums1Start], nums2[nums2Start]);
            }

            int a1 = Math.Min(sizeNums1, k / 2);
            int a2 = Math.Min(sizeNums2, k / 2);
            int nums1Index = a1-1+nums1Start;
            int nums2Index = a2-1+nums2Start;

            if (nums1[nums1Index] < nums2[nums2Index])
            {
                return Leet004_findkth(nums1, nums1Index + 1, nums1End,
                               nums2, nums2Start, nums2Index,
                               k - a1);
            }
            else if (nums1[nums1Index] > nums2[nums2Index])
            {
                return Leet004_findkth(nums1, nums1Start, nums1Index,
                               nums2, nums2Index + 1, nums2End,
                               k - a2);
            }
            else
            {
                return nums1[nums1Index];
            }
        }
    }
}
