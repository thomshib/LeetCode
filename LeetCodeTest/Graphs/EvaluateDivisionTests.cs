using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Graphs;
using LeetCodeTest.Utility;

namespace LeetCodeTest.Graphs
{

    [TestClass]
    public class EvaluateDivisionTests
    {
        [TestMethod]
        public void EvaluateDivision_Success()
        {
            IList<IList<string>> equations = new List<IList<string>>();
            equations.Add(new List<string> { "a", "b" });
            equations.Add(new List<string> { "b", "c" });

            double[] values = new double[] { 2.0, 3.0 };

            IList<IList<string>> queries = new List<IList<string>>();
            queries.Add(new List<string> { "a", "c" });
            queries.Add(new List<string> { "b", "a" });
            queries.Add(new List<string> { "a", "e" });
            queries.Add(new List<string> { "a", "a" });
            queries.Add(new List<string> { "x", "x" });


            double[] expectedResult = new double[] { 6.0, 0.5, -1.0, 1.0, -1.0 };

            var result = new EvaluateDivision().CalcEquation(equations, values, queries);

            var isEqual = ArrayEquivalence.sequencesEqual(result, expectedResult);
            Assert.IsTrue(isEqual);


            
        }
    }
}
