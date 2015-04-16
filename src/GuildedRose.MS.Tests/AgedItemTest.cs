//-----------------------------------------------------------------------
// <copyright file="AgedItemTest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GildedRose.MS.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GildedRose.Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AgedItemTest
    {
        [TestMethod]
        public void Sulfuras_Quality_RemainsSame()
        {
            var updater = new QualityUpdater();

            var sulfuras = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};

            updater.Items = new List<Item> { sulfuras };

            updater.UpdateQuality();

            Assert.AreEqual(80, sulfuras.Quality);
        }
    }
}
