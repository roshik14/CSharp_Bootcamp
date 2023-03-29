using Markdown.Generator.Core.Markdown;
using Markdown.Generator.Core.Markdown.Elements;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class MarkdownBuilderTests
    {
        private readonly MarkdownBuilder _builder = new();

        [Fact]
        public void Should_BuilderContainsCodeQuote_When_CodeQuoteAddedToElements()
        {
            _builder.CodeQuote("csharp");
            Assert.Contains(_builder.Elements, x => x as CodeQuote != null);
            Assert.Equal(_builder.Elements.Where(x => x as CodeQuote != null)?.Count(), 1);
        }

        [Fact]
        public void Should_BuilderContainsCode_When_CodeAddedToElements()
        {
            _builder.Code("csharp", "some code");
            Assert.Contains(_builder.Elements, x => x as Code != null);
            Assert.Equal(_builder.Elements.Where(x => x as Code != null)?.Count(), 1);
        }

        [Fact]
        public void Should_BuilderContainsHeader_When_HeaderAddedToElements()
        {
            _builder.Header(1, "some header");
            Assert.Contains(_builder.Elements, x => x as Header != null);
            Assert.Equal(_builder.Elements.Where(x => x as Header != null)?.Count(), 1);
        }

        [Fact]
        public void Should_BuilderContainsLink_When_LinkAddedToElements()
        {
            _builder.Link("some text", "myurl.com");
            Assert.Contains(_builder.Elements, x => x as Link != null);
            Assert.Equal(_builder.Elements.Where(x => x as Link != null)?.Count(), 1);
        }
    }
}
