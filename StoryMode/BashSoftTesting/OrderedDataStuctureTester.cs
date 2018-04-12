using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using BashSoft.Contracts;
using NUnit.Framework;
using BashSoft.DataStructures;

namespace BashSoftTesting
{
    
    public class OrderedDataStuctureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void setUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity,16);
            Assert.AreEqual(this.names.Size,0);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity,20);
            Assert.AreEqual(this.names.Size,0);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitianlComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity,16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.That(()=>this.names.Add(null), Throws.ArgumentNullException);
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            Assert.AreEqual(this.names, new string[] {"Balkan","Georgi", "Rosen"});
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add(i.ToString());
            }
            Assert.AreEqual(this.names.Size, 17);
            Assert.AreNotEqual(this.names.Capacity, 16);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> namesTwo = new List<string>
            {
                "name1",
                "name2"
            };
            this.names.AddAll(namesTwo);
            Assert.AreEqual(this.names.Size,2);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.That(() => this.names.AddAll(null), Throws.ArgumentNullException);
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            List<string> namesTwo = new List<string>
            {
                "Rosen",
                "Georgi",
                "Balkan"
            };

            this.names.AddAll(namesTwo);
            Assert.AreEqual(this.names, new string[] { "Balkan", "Georgi", "Rosen" });
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("test");
            this.names.Remove("test");
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("ivan");
            this.names.Add("nasko");
            this.names.Remove("ivan");
            Assert.IsFalse(this.names.Contains("ivan"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            Assert.That(() => this.names.Remove(null), Throws.ArgumentNullException);
        }

        [Test]
        public void TestJoinWithNull()
        {
            Assert.That(() => this.names.JoinWith(null), Throws.ArgumentNullException);
        }

        [Test]
        public void TestJoinWorksFine()
        {
            string expeted = "Balkan, Georgi, Rosen";

            this.names.AddAll(new List<string>{"Georgi", "Rosen", "Balkan"});

            string actual = this.names.JoinWith(", ");

            Assert.AreEqual(actual, expeted);
        }
    }
}
