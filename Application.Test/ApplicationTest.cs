using Xunit;
using Application.Utils;

namespace Application.Test
{
    public class ApplicationTest
    {
        [Fact]
        public void NameFormatterTest()
        {
            Assert.Equal(AuthorNameFormatter.FormatNames("guimaraes"), "GUIMARAES");
            Assert.Equal(AuthorNameFormatter.FormatNames("Joao Silva Neto"), "SILVA NETO, Joao");
            Assert.Equal(AuthorNameFormatter.FormatNames("Joao Neto"), "NETO, Joao");
            Assert.Equal(AuthorNameFormatter.FormatNames("YURI IVANOFF"), "IVANOFF, Yuri");
            Assert.Equal(AuthorNameFormatter.FormatNames("joao silva"), "SILVA, Joao");
            Assert.Equal(AuthorNameFormatter.FormatNames("paulo coelho"), "COELHO, Paulo");
            Assert.Equal(AuthorNameFormatter.FormatNames("celso de araujo"), "ARAUJO, Celso de");
        }
    }
}
