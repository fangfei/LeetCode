﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetMedium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetMedium.Tests
{
    [TestClass()]
    public class LeetMediumAndHardSolutionTests
    {
        [TestMethod()]
        public void Leet004_FindMedianSortedArraysTest()
        {
            LeetMediumAndhardSolution leetMediumHard = new LeetMediumAndhardSolution();
            int[] nums1 = new int[] { 1 };
            int[] nums2 = new int[] { 2 };
            leetMediumHard.Leet004_FindMedianSortedArrays(nums1, nums2);
        }

        [TestMethod()]
        public void Leet004_FindMedianSortedArrays2Test()
        {
            LeetMediumAndhardSolution leetMediumHard = new LeetMediumAndhardSolution();
            int[] nums1 = new int[] { 1, 2 };
            int[] nums2 = new int[] { 1, 2 };
            leetMediumHard.Leet004_FindMedianSortedArrays2(nums1, nums2);
        }

        [TestMethod()]
        public void Leet044_IsMatchTest()
        {
            LeetMediumAndhardSolution leetMediumHard = new LeetMediumAndhardSolution();
            bool a = leetMediumHard.Leet044_IsMatch("aa", "a");
            Assert.IsFalse(a);
        }

        [TestMethod()]
        public void Leet240_SearchMatrixTest()
        {
            LeetMediumAndhardSolution leetMediumHard = new LeetMediumAndhardSolution();
            int[,] a = new int[,] { { 1, 1 } };
            leetMediumHard.Leet240_SearchMatrix(a, 0);
        }

        [TestMethod()]
        public void Leet131_PartitionTest()
        {
            LeetMediumAndhardSolution leetMediumHard = new LeetMediumAndhardSolution();
            leetMediumHard.Leet131_Partition("a");
        }

        [TestMethod()]
        public void Leet229_MajorityElementTest()
        {
            LeetMediumAndhardSolution leetMediumHard = new LeetMediumAndhardSolution();
            int[] a = new int[] { 1, 2 };
            leetMediumHard.Leet229_MajorityElement(a);
        }

        [TestMethod()]
        public void Leet345_ReverseVowelsTest()
        {
            LeetMediumAndhardSolution leetMediumHard = new LeetMediumAndhardSolution();
            string s = "hello";
            leetMediumHard.Leet345_ReverseVowels(s);
        }

        [TestMethod()]
        public void Leet128_LongestConsecutiveTest()
        {
            LeetMediumAndhardSolution leetMediumHard = new LeetMediumAndhardSolution();
            int[] a = new int[] { -1, 1, 0 };
            leetMediumHard.Leet128_LongestConsecutive(a);
        }

        [TestMethod()]
        public void Leet329_LongestIncreasingPathTest()
        {
            LeetMediumAndhardSolution leetMediumHard = new LeetMediumAndhardSolution();
            int[,] a = new int[,] { {3,4,5 }, {3,2,6 }, {2,2,1 } };
            leetMediumHard.Leet329_LongestIncreasingPath(a);
        }
    }

    [TestClass()]
    public class LeetMediumSolutionTests
    {
        [TestMethod()]
        public void Leet094_InorderTraversalTest()
        {
            LeetMediumAndhardSolution leetMedium = new LeetMediumAndhardSolution();
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            IList<int> rst = leetMedium.Leet094_InorderTraversal(root);
            Assert.AreEqual(1, rst[0]);
            Assert.AreEqual(3, rst[1]);
            Assert.AreEqual(2, rst[2]);
        }

        [TestMethod()]
        public void Leet318_MaxProductTest()
        {
            LeetMediumAndhardSolution leetMedium = new LeetMediumAndhardSolution();
            string[] tst = new string[] { "abcw", "baz", "foo", "bar", "xtfn", "abcdef" };
            Assert.AreEqual(16, leetMedium.Leet318_MaxProduct(tst));
        }

        [TestMethod()]
        public void Leet331_IsValidSerializationTest()
        {
            LeetMediumAndhardSolution leetMedium = new LeetMediumAndhardSolution();
            string tst = "9,3,4,#,#,1,#,#,2,#,6,#,#";
            Assert.IsTrue(leetMedium.Leet331_IsValidSerialization(tst));
            tst = "#";
            Assert.IsTrue(!leetMedium.Leet331_IsValidSerialization(tst));
        }

        [TestMethod()]
        public void Leet113_PathSumTest()
        {
            LeetMediumAndhardSolution leetMedium = new LeetMediumAndhardSolution();
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(4);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(11);
            root.right.left = new TreeNode(13);
            root.right.right = new TreeNode(4);
            root.left.left.left = new TreeNode(7);
            root.left.left.right = new TreeNode(2);
            root.right.right.left = new TreeNode(5);
            root.right.right.right = new TreeNode(1);
            leetMedium.Leet113_PathSum(root, 22);
        }
    }
}