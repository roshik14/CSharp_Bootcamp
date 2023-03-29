using Xunit;
using Moq;
using Markdown.Generator.Core.Markdown;
using Markdown.Generator.Core.Documents;
using System.Reflection;

namespace Markdown.Generator.Core.Tests
{
    public class GithubWikiDocumentBuilderTests
    {
        private readonly Mock<IMarkdownGenerator> markdownGeneratorMock = new();
        private readonly Mock<Type> typeMock = new ();

        [Fact]
        public void Given_MarkdownGenerator_When_TypesAsParameter_Then_CallsLoadOnlyOnce()
        {
            var types = new Type[] { typeMock.Object };
            markdownGeneratorMock.Setup<MarkdownableType[]>(x => x.Load(types));
            var wiki = new GithubWikiDocumentBuilder<IMarkdownGenerator>(markdownGeneratorMock.Object);

            wiki.Generate(types, "./");

            markdownGeneratorMock.Verify(x => x.Load(It.IsAny<Type[]>()), Times.Once);
        }

        [Fact]
        public void Given_MarkdownGenerator_When_DllPathAndNamespaceMatchAsParameter_Then_CallsLoadOnlyOnce()
        {
            var dllpath = "dll";
            var namespaceMatch = "aboba";
            markdownGeneratorMock.Setup<MarkdownableType[]>(x => x.Load(dllpath, namespaceMatch));
            var wiki = new GithubWikiDocumentBuilder<IMarkdownGenerator>(markdownGeneratorMock.Object);

            wiki.Generate(dllpath, namespaceMatch, "./");

            markdownGeneratorMock.Verify(x => x.Load(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void Given_MarkdownGenerator_When_AssembliesAndNamespaceMatchAsParameter_Then_CallsLoadOnlyOnce()
        {
            var assembiles = new Assembly[] { Assembly.GetExecutingAssembly() };
            var namespaceMatch = "aboba";
            markdownGeneratorMock.Setup<MarkdownableType[]>(x => x.Load(assembiles, namespaceMatch));
            var wiki = new GithubWikiDocumentBuilder<IMarkdownGenerator>(markdownGeneratorMock.Object);

            wiki.Generate(assembiles, namespaceMatch, "./");

            markdownGeneratorMock.Verify(x => x.Load(It.IsAny<Assembly[]>(), It.IsAny<string>()), Times.Once());
        }
    }
}
