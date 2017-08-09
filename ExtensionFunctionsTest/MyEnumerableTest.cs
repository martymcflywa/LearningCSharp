using System;
using ExtensionFunctions;
using Xunit;

namespace ExtensionFunctionsTest
{
    public class MyEnumerableTest
    {
        [Fact]
        public void Range()
        {
            var actual = MyEnumerable.Range(0, 5);
            Assert.Equal(new[] { 0, 1, 2, 3, 4 }, actual);
        }

        [Fact]
        public void Take()
        {
            var actual = MyEnumerable
                .Range(0, 5)
                .Take(3);

            Assert.Equal(new[] { 0, 1, 2 }, actual);
        }

        [Fact]
        public void Select()
        {
            var actual = MyEnumerable
                .Range(0, 3)
                .Select(i => i * 2);

            Assert.Equal(new[] { 0, 2, 4 }, actual);
        }

        [Fact]
        public void SelectMany()
        {
            var numbers = MyEnumerable.Range(1, 2);
            var letters = new[] { 'A', 'B' };
            var actual = numbers.SelectMany(num => letters, Tuple.Create);

            Assert.Equal(new[] { 
                Tuple.Create(1, 'A'),
                Tuple.Create(1, 'B'),
                Tuple.Create(2, 'A'),
                Tuple.Create(2, 'B')
            }, actual);
        }

        [Fact]
        public void Reverse()
        {
            var actual = MyEnumerable
                .Range(0, 5)
                .Reverse();

            Assert.Equal(new[] { 4, 3, 2, 1, 0 }, actual);
        }
    }
}
