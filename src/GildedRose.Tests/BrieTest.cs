using NUnit.Framework;
using GildedRose.Console;
using System.Linq;

namespace GildedRose.Tests
{
    [TestFixture]
    public class BrieTest
    {
        [Test]
        public void Brie_Quality_IncreasesTo1()
        {
            Program.Current = new Program();

            var item = Program.Current.Brie;

            Assert.AreEqual(0, item.Quality);

            Program.Run();
            
            Assert.AreEqual(1, item.Quality);
        }

        [Test]
        public void Brie_SellIn_StartsAt2()
        {
            Program.Current = new Program();

            var item = Program.Current.Brie;

            Assert.AreEqual(2, item.SellIn);
        }

        [Test]
        public void Brie_SellIn_DecreasesTo1()
        {
            Program.Current = new Program();

            var item = Program.Current.Brie;

            Program.Run();

            Assert.AreEqual(1, item.SellIn);
        }
    }
}