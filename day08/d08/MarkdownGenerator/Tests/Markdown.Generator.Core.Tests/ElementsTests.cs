using Markdown.Generator.Core.Markdown.Elements;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class ElementsTests
    {
        [Fact]
        public void Given_Code_When_LanguageAndCodeAsParameter_Then_ReturnMarkdownCodeMarkup()
        {
            var code = new Code("csharp", "some code");
            var expected = "```csharp\r\nsome code\r\n```\r\n";

            var actual = code.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_CodeQuote_When_CodeAsParameter_Then_ReturnMarkdownCodeQuoteMarkup()
        {
            var text = "some code";
            var codeQuote = new CodeQuote(text);
            var expected = $"```{text}```";

            var actual = codeQuote.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_Header_When_LevelAndTextAsParameter_Then_ReturnMarkdownHeaderMarkup()
        {
            var maxLevel = 6;
            var headerStr = " header";
            for (var level = 1; level <= maxLevel; level++)
            {
                var header = new Header(level, headerStr);
                
                var expected = $"{new string('#', level - 1)} {headerStr}\r\n";

                var actual = header.Create();

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void Given_List_When_TextAsParameter_Then_ReturnMarkdownListMarkup()
        {
            var list = new List("firstList");
            var expected = "- firstList\r\n";

            var actual = list.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_Link_When_TextAndUrlAsParameter_Then_ReturnMarkdownLinkMarkup()
        {
            var link = new Link("mylink", "https://github.com/roshik14");
            var expected = "[mylink](https://github.com/roshik14)";

            var actual = link.Create();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_Image_When_AltTextAndUrlAsParameter_Then_ReturnMarkdownImageMarkup()
        {
            var altText = "my_image";
            var url = "https://somelink";
            var image = new Image(altText, url);
            var expected = $"![{altText}]({url})";

            var actual = image.Create();

            Assert.Equal(expected, actual);
        }

    }
}