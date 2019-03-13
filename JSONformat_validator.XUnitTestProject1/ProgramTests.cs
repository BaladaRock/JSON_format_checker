using System;
using Xunit;

namespace JSONformat_validator.XUnitTestProject1
{
    public class ProgramTests
    {
        [Fact]
        public void CheckJSOnFormat_SimpleWord()
        {
            Assert.True(Program.CheckFirstAndLastCharacters("\"Test\""));
        }

        [Fact]
        public void CheckJSOnFormat_WordHasNot_Commas()
        {
            Assert.False(Program.CheckFirstAndLastCharacters("Test\""));
        }

        [Fact]
        public void CheckJSOnFormat_SpecialCharacter()
        {
            Assert.True(Program.CheckSpecialCharacters("\\Test"));
        }

        [Fact]
        public void SpecialCharacters_SimpleWord()
        {
            Assert.False(Program.CheckSpecialCharacters("Tes\t"));
        }

        [Fact]
        public void UnicodeCharacters_SimpleExample()
        {
            Assert.False(Program.CheckUnicodeCharacters("T\u005Cest"));
        }
    }
}
