using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Others;

namespace LeetCodeTest.Others
{

 [TestClass]
    public  class ValidNumberTests
    {
        [TestMethod]
        public void ValidNumberTest_Success()
        {
           string input = "0";
           var result = new ValidNumber().IsNumber(input);
            Assert.IsTrue(result);

             input = "0.1";
             result = new ValidNumber().IsNumber(input);
             Assert.IsTrue(result);

             input = "abc";
             result = new ValidNumber().IsNumber(input);
             Assert.IsFalse(result);

             input = "1 a";
             result = new ValidNumber().IsNumber(input);
             Assert.IsFalse(result);

             input = "2e10";
             result = new ValidNumber().IsNumber(input);
             Assert.IsTrue(result);

             input = "-90e3";
             result = new ValidNumber().IsNumber(input);
             Assert.IsTrue(result);

             input = "1e";
             result = new ValidNumber().IsNumber(input);
             Assert.IsFalse(result);

              input = "e3";
             result = new ValidNumber().IsNumber(input);
             Assert.IsFalse(result);

             input = "6e-1";
             result = new ValidNumber().IsNumber(input);
             Assert.IsTrue(result);

             input = "99e2.5";
             result = new ValidNumber().IsNumber(input);
             Assert.IsFalse(result);

             input = "53.5e93";
             result = new ValidNumber().IsNumber(input);
             Assert.IsTrue(result);

             
             input = "--6";
             result = new ValidNumber().IsNumber(input);
             Assert.IsFalse(result);

             input = "-+3";
             result = new ValidNumber().IsNumber(input);
             Assert.IsFalse(result);

             input = "95a54e53";
             result = new ValidNumber().IsNumber(input);
             Assert.IsFalse(result);

             



           

        }
    }
}
