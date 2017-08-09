using linqExercises;
using System;
using Xunit;

namespace ExtensionLinqTest
{
    public class LinqExercisesTest
    {
        [Fact]
        public void TRange()
        {
            var actual = LinqFunctions.TRange(0, 5);
            Assert.Equal(new[] { 0, 1, 2, 3, 4 }, actual);
        }

        [Fact]
        public void TTake()
        {
            var actual = LinqFunctions
                .TRange(0, 5)
                .TTake(3);

            Assert.Equal(new[] { 0, 1, 2 }, actual);
        }

        [Fact]
        public void TWhere()
        {
            var actual = LinqFunctions
                .TRange(0, 5)
                .TWhere(i => i % 2 == 0);

            Assert.Equal(new[] { 0, 2, 4 }, actual);
        }

        //[Fact] TSelect not implemented
        public void TSelect()
        {
            var actual = LinqFunctions
                .TRange(0, 3);
                //.TSelect(i => i * 2);

            Assert.Equal(new[] { 0, 2, 4 }, actual);
        }

        [Fact]
        public void TSelectMany()
        {
            var numbers = LinqFunctions.TRange(1, 2);
            var letters = new[] { 'A', 'B' };
            var actual = numbers.TSelectMany(num => letters, Tuple.Create);

            Assert.Equal(new[] {
                Tuple.Create(1, 'A'),
                Tuple.Create(1, 'B'),
                Tuple.Create(2, 'A'),
                Tuple.Create(2, 'B')
            }, actual);
        }

        [Fact]
        public void TReverse()
        {
            var actual = LinqFunctions
                .TRange(0, 5)
                .TReverse();

            Assert.Equal(new[] { 4, 3, 2, 1, 0 }, actual);
        }
    }
}
