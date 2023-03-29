using Markdown.Generator.Core.Markdown;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class Sut
    {
        public int publicField;
        private int privateField;

        public int PublicProperty { get; }
        private int PrivateProperty { get; }

        public void PublicMethod() { }
        private void PrivateMethod() { }
    }

    public class MarkdownableTypeTests
    {
        [Fact]
        public void Given_MarkdownableType_When_SutTypeAsParameter_Then_ReturnPublicMethods()
        {
            var type = new MarkdownableType(typeof(Sut), null);

            foreach (var method in type.GetMethods())
            {
                Assert.True(method.IsPublic);
            }
        }

        [Fact]
        public void Given_MarkdownableType_When_SutTypeAsParameter_Then_ReturnPublicFields()
        {
            var type = new MarkdownableType(typeof(Sut), null);

            foreach (var field in type.GetFields())
            {
                Assert.True(field.IsPublic);
            }
        }

        [Fact]
        public void Given_MarkdownableType_When_SutTypeAsParameter_Then_ReturnPublicProperties()
        {
            var type = new MarkdownableType(typeof(Sut), null);

            foreach (var property in type.GetProperties())
            {
                Assert.True(property.GetMethod?.IsPublic);
            }
        }
    }
}
