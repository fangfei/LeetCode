using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetMedium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetMedium.Tests
{
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