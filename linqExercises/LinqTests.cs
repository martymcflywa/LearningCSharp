using System;
using System.Collections.Generic;
using ExtensionFunctions;
using NUnit.Framework;

namespace linqExercises
{
    [TestFixture]
    public class LinqTests
    {
        [Test]
        public void WhereTest()
        {
            int[] elems = { 0, 30, 20, 15, 90, 85, 40, 75 };
            var actual = elems.Where(number => number <= 50);

            CollectionAssert.AreEqual(new[] { 0, 30, 20, 15, 40 }, actual);
        }

        [Test]
        public void WhereIndexTest()
        {
            throw new NotImplementedException();
            //int[] elems = { 0, 30, 20, 15, 90, 85, 40, 75 };
            //var actual = elems.Where((number, index) => number <= index * 10);

            //CollectionAssert.AreEqual(new[] { 0, 20, 15, 40 }, actual);
        }

        [Test]
        public void RangeTest()
        {
            var actual = MyEnumerable.Range(1, 10);

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, actual);
        }

        [Test]
        public void TakeTest()
        {
            int[] elems = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = elems.Take(5);

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, actual);
        }

        [Test]
        public void ReverseTest()
        {
            var actual = MyEnumerable.Range(1, 5).Reverse();

            CollectionAssert.AreEqual(new[] { 5, 4, 3, 2, 1 }, actual);
        }

        //
        // Not implemented.
        //
        [Test]
        public void SelectManyTest()
        {
            throw new NotImplementedException();
            //PetOwner[] petOwners = {
            //    new PetOwner { Name="Higa, Sidney", Pets = new List<string>{ "Scruffy", "Sam" } },
            //    new PetOwner { Name="Ashkenazi, Ronen", Pets = new List<string>{ "Walker", "Sugar" } },
            //    new PetOwner { Name="Price, Vernette", Pets = new List<string>{ "Scratches", "Diesel" } }
            //};

            //// Query using SelectMany().
            //var actual = petOwners.SelectMany(petOwner => petOwner.Pets);

            //CollectionAssert.AreEqual(new[] { "Scruffy", "Sam", "Walker", "Sugar", "Scratches", "Diesel" }, actual);
        }

        public class PetOwner
        {
            public string Name { get; set; }
            public List<String> Pets { get; set; }
        }


        [Test]
        public void SelectManyCartesianProduct()
        {
            var numbers = MyEnumerable.Range(1, 3);
            var letters = new[] { 'x', 'y', 'z' };

            var actual = numbers.SelectMany(
                number => letters,
                Tuple.Create
            );

            CollectionAssert.AreEqual(
                new[] {
                    Tuple.Create(1,'x'),
                    Tuple.Create(1,'y'),
                    Tuple.Create(1,'z'),
                    Tuple.Create(2,'x'),
                    Tuple.Create(2,'y'),
                    Tuple.Create(2,'z'),
                    Tuple.Create(3,'x'),
                    Tuple.Create(3,'y'),
                    Tuple.Create(3,'z')
                }, actual);
        }
    }
}
