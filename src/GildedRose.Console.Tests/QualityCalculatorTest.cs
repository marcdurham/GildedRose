// <copyright file="QualityCalculatorTest.cs" company="Microsoft">Copyright © Microsoft 2011</copyright>

using System;
using GildedRose.Console;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Console
{
    [TestClass]
    [PexClass(typeof(QualityCalculator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class QualityCalculatorTest
    {
        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public void Calculate([PexAssumeUnderTest]QualityCalculator target, Item item)
        {
            target.Calculate(item);
            // TODO: add assertions to method QualityCalculatorTest.Calculate(QualityCalculator, Item)
        }
    }
}
