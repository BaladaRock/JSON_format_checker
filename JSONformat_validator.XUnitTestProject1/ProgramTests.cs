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
            Assert.True(Program.CheckSpecialCharacters("Tes\t"));
        }

        [Fact]
        public void BackSlashCharacter_SimpleWord()
        {
            Assert.False(Program.CheckSpecialCharacters("Tes\\T"));
        }

        [Fact]
        public void SpecialCharacters_UpperCase()
        {
            Assert.True(Program.CheckSpecialCharacters("\\Test"));
        }

        [Fact]
        public void SpecialCharacters_SpecialCase()
        {
            Assert.True(Program.CheckSpecialCharacters("Test\\"));
        }


        [Fact]
        public void UnicodeCharacters_SimpleExample()
        {
            Assert.True(Program.CheckUnicodeCharacters("\"T\\u005Cest\""));
        }

        [Fact]
        public void CheckHexadecimalFormat_Number()
        {
            Assert.True(Program.CheckUnicodeCharacters("80AE"));
        }

        
    }
}
