using System;
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


        public IList<IList<int>> Leet040_CombinationSum2(int[] candidates, int target)
        {
            if (candidates == null || candidates.Length == 0)
            {
                return new List<IList<int>>();
            }
            Dictionary<string, IList<int>> map = new Dictionary<string, IList<int>>();
            Array.Sort(candidates);
            Leet040_sumrecursive(candidates, new List<int>(), 0, target, ref map);

            return map.Values.ToList();
        }

        private void Leet040_sumrecursive(
            int[] candidates,
            List<int> arr,
            int index,
            int target,
            ref Dictionary<string, IList<int>> result)
        {
            if (target <= 0)
            {
                string key = string.Join(",", arr);
                if (!result.ContainsKey(key))
                {
                    result.Add(key, new List<int>(arr));
                }
                return;
            }

            for (int i = index; i < candidates.Length && target >= candidates[i]; i++)
            {
                var c = candidates[i];
                arr.Add(c);
                Leet040_sumrecursive(candidates, arr, i + 1, target - c, ref result);
                arr.RemoveAt(arr.Count - 1);
            }
        }

        public IList<IList<int>> Leet216_CombinationSum3(int k, int n)
        {
            var rst = new List<IList<int>>();
            if (n > 45 || k > 9 || k > n)
            {
                return rst;
            }

            Leet216_helper(new List<int>(), 1, n, k,ref rst);

            return rst;
        }

        private void Leet216_helper(List<int> arr, int index, int target, int numcounter, ref List<IList<int>> result)
        //IList<int> current
        {
            if (arr.Count > numcounter || target < 0)
            {
                return;
            }
            if (target == 0)
            {
                // add result
                if (arr.Count == numcounter)
                {
                    result.Add(new List<int>(arr));
                }
                return;
            }
            for (int i = index; i < 10 && target >= i; i++)
            {
                arr.Add(i);
                Leet216_helper(arr, i+1, target - i, numcounter, ref result);
                arr.RemoveAt(arr.Count - 1);
            }
        }

        public bool Leet044_IsMatch(string s, string p)
        {
            int recordSIndex = -1;
            int recordPIndex = -1;

            int i = 0;
            int j = 0;
            for (i = 0; i < s.Length;)
            {
                if (j >= p.Length)
                {
                    recordSIndex++;
                    i = recordSIndex;
                    j = recordPIndex;
                }
                else if ((j >= 0) && (s[i] == p[j] || p[j] == '?'))
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j >= 0 && p[j] == '*')
                    {
                        while ((j < p.Length) && (p[j] == '*'))
                        {
                            j++;
                        }
                        if (j == p.Length)
                        {
                            return true;
                        }
                        recordSIndex = i;
                        recordPIndex = j;
                    }
                    else
                    {
                        if (recordPIndex >= 0)
                        {
                            recordSIndex++;
                            i = recordSIndex;
                            j = recordPIndex;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            while (j < p.Length && p[j] == '*')
            {
                j++;
            }

            return i == s.Length && j == p.Length;
        }


        public IList<string> Leet093_RestoreIpAddresses(string s)
        {
            List<string> rst = new List<string>();
            if (s.Length > 12)
            {
                return rst;
            }
            Leet093_helper(s, 4, "", ref rst);
            return rst;
        }

        public void Leet093_helper(string s, int k, string current, ref List<string> rst)
        {
            if (k == 0)
            {
                if (s == "") rst.Add(current);
            }
            else
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (s.Length >= i && Leet093_validrange(s.Substring(0, i)))
                    {
                        if (k == 1)
                        {
                            Leet093_helper(s.Substring(i), k - 1, current + s.Substring(0, i), ref rst);
                        }
                        else
                        {
                            Leet093_helper(s.Substring(i), k - 1, current + s.Substring(0, i) + ".", ref rst);
                        }
                    }
                }
            }
        }
        public bool Leet093_validrange(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length > 3 || (s.Length > 1 && s[0] == '0')) return false;
            int rst = Int32.Parse(s);
            return rst <= 255 && rst >= 0;
        }

        public IList<TreeNode> Leet095_GenerateTrees(int n)
        {
            return Leet095_helper(1, n);
        }

        private IList<TreeNode> Leet095_helper(int start, int end)
        {
            List<TreeNode> rst = new List<TreeNode>();
            if (start > end)
            {
                rst.Add(null);
                return rst;
            }

            for (int i = start; i <= end; i++)
            {
                IList<TreeNode> left = Leet095_helper(start, i - 1);
                IList<TreeNode> right = Leet095_helper(i + 1, end);

                for (int j = 0; j < left.Count(); j++)
                {
                    for (int k = 0; k < right.Count(); k++)
                    {
                        TreeNode current = new TreeNode(i);
                        current.left = left[j];
                        current.right = right[k];
                        rst.Add(current);
                    }
                }
            }

            return rst;
        }

        public bool Leet240_SearchMatrix(int[,] matrix, int target)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            int i = row - 1;
            int j = 0;

            while (j <= col - 1 && i >= 0)
            {
                if (matrix[i, j] == target)
                {
                    return true;
                }
                else if (matrix[i, j] < target)
                {
                    j++;
                }
                else
                {
                    i--;
                }
            }

            return false;
        }

        public IList<IList<string>> Leet131_Partition(string s)
        {
            List<IList<string>> rst = new List<IList<string>>();
            List<string> interimRst = new List<string>();

            Leet131_helper(s, 0, ref interimRst, ref rst);

            return rst;
        }

        private void Leet131_helper(string s, int start,
                            ref List<string> interimRst, ref List<IList<string>> rst)
        {
            if (start == s.Length)
            {
                List<string> tmp = new List<string>(interimRst);
                rst.Add(tmp);
                return;
            }

            for (int i = start; i < s.Length; i++)
            {
                if (Leet131_isPalindrome(s, start, i))
                {
                    interimRst.Add(s.Substring(start, i - start + 1));
                    Leet131_helper(s, i + 1, ref interimRst, ref rst);
                    interimRst.RemoveAt(interimRst.Count - 1);
                }
            }
        }

        private bool Leet131_isPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }

        public IList<int> Leet229_MajorityElement(int[] nums)
        {
            List<int> rst = new List<int>();
            if (nums == null || nums.Length == 0)
            {
                return rst;
            }

            int m = 0, n = 0, countm = 0, countn = 0;


            int sizecheck = nums.Length / 3;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == m)
                {
                    countm++;
                }
                else if (nums[i] == n)
                {
                    countn++;
                }
                else if (countm == 0)
                {
                    m = nums[i];
                    countm = 1;
                }
                else if (countn == 0)
                {
                    n = nums[i];
                    countn = 1;
                }
                else
                {
                    countm--;
                    countn--;
                }

            }

            countm = 0;
            countn = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (m == nums[i])
                {
                    countm++;
                }
                else if (n == nums[i])
                {
                    countn++;
                }
            }

            if (countm > sizecheck)
            {
                rst.Add(m);
            }
            if (countn > sizecheck)
            {
                rst.Add(n);
            }


            return rst;
        }

        public int LadderLength(string beginWord, string endWord, ISet<string> wordList)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            Queue<string> bfs = new Queue<string>();
            bfs.Enqueue(beginWord);
            map.Add(beginWord, 1);

            while (bfs.Count > 0)
            {
                string current = bfs.Dequeue();

                for (int i = 0; i < current.Length; i++)
                {
                    char[] newword = current.ToCharArray();
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        newword[i] = c;
                        string s = new string(newword);
                        if (s == endWord)
                        {
                            return map[current] + 1;
                        }
                        if (!map.ContainsKey(s) && wordList.Contains(s))
                        {
                            bfs.Enqueue(s);
                            map.Add(s, map[current] + 1);
                        }
                    }
                }
            }

            return 0;
        }

        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            List<int> rst = new List<int>();
            if (numCourses == 0 || numCourses == 1)
            {
                return rst.ToArray();
            }

            var row = prerequisites.GetLength(0);

            int[] dependencies = new int[numCourses];
            bool[] visited = new bool[numCourses];

            for (int i = 0; i < row; i++)
            {
                dependencies[prerequisites[i, 0]]++;
            }

            int count = 0;

            while (count < numCourses)
            {
                List<int> currentselection = new List<int>();
                for (int i = 0; i < numCourses; i++)
                {
                    if (dependencies[i] == 0 && !visited[i])
                    {
                        count++;
                        visited[i] = true;
                        currentselection.Add(i);
                        rst.Add(i);
                    }
                }

                if (currentselection.Count == 0)
                {
                    break;
                }

                foreach (var c in currentselection)
                {
                    for (int j = 0; j < row; j++)
                    {
                        if (prerequisites[j, 1] == c)
                        {
                            dependencies[prerequisites[j, 0]]--;
                        }
                    }
                }
            }

            if (count >= numCourses)
            {
                return rst.ToArray();
            }
            else
            {
                return new int[0];
            }
        }
    }

    public class MedianFinder
    {

        List<double> values;

        public MedianFinder()
        {
            values = new List<double>();
        }

        // Adds a num into the data structure.
        public void AddNum(double num)
        {
            int pos = helper_getinsertposition(values, num);
            if (pos == values.Count)
            {
                values.Add(num);
            }
            else
            {
                values.Insert(pos, num);
            }
        }

        // return the median of current data stream
        public double FindMedian()
        {
            int allCount = values.Count;

            if (allCount == 0) throw new Exception("array is empty");

            if (allCount % 2 == 0)
                return (values[allCount / 2 - 1] + values[allCount / 2]) / 2;
            else
                return values[allCount / 2];
        }

        private int helper_getinsertposition(List<double> array, double number)
        {
            int start = 0;
            int end = array.Count - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (array[mid] > number)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return start;
        }
    }



    class TrieNode
    {
        public List<TrieNode> children;
        public char val;
        public bool hasWord;

        // Initialize your data structure here.
        public TrieNode()
        {
            children = new List<TrieNode>();
            hasWord = false;
        }
    }

    public class WordDictionary
    {
        private TrieNode root;

        public WordDictionary()
        {
            root = new TrieNode();
        }

        // Inserts a word into the trie.
        public void AddWord(String word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            var n = root;
            var index = 0;

            while (n.children.Count > 0 && index < word.Length)
            {
                var first = n.children.FirstOrDefault(x => x.val == word[index]);
                if (first != null)
                {
                    n = first;
                    index++;
                }
                else
                {
                    break;
                }
            }

            if (index < word.Length)
            {
                for (var i = index; i < word.Length; i++)
                {
                    var child = new TrieNode();
                    child.val = word[i];
                    n.children.Add(child);
                    n = child;
                }
            }
            n.hasWord = true;
        }

        // Returns if the word is in the trie.
        public bool Search(string word)
        {
            return searchDfs(word, root, 0);
        }

        private bool searchDfs(string word, TrieNode node, int index)
        {
            if (index == word.Length)
            {
                return node.hasWord;
            }

            if (word[index] == '.')
            {
                foreach (var child in node.children)
                {
                    if (searchDfs(word, child, index + 1))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                var newnode = node.children.FirstOrDefault(x => x.val == word[index]);
                if (newnode == null)
                {
                    return false;
                }
                else
                {
                    return searchDfs(word, newnode, index + 1);
                }
            }
        }
    }

}
