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
            Assert.False(Program.CheckUnicodeCharacters("\"T\\u005Cest\""));
        }

        [Fact]
        public void CheckHexadecimalFormat_Number()
        {
            Assert.True(Program.CheckUnicodeCharacters("80AE"));
        }

        [Fact]
        public void CheckJSONNumber_Positive_Number()
        {
            Assert.True(Program.IsStringJSONNumber("1"));
        }

        [Fact]
        public void CheckJSONNumber_Bigger_Number()
        {
            Assert.True(Program.IsStringJSONNumber("23"));
        }

        [Fact]
        public void CheckJSONNumber_String_IsNot_Number()
        {
            Assert.False(Program.IsStringJSONNumber("23A4"));
        }

        [Fact]
        public void CheckJSONNumber_Negative_Number()
        {
            Assert.True(Program.IsStringJSONNumber("-123"));
        }

        [Fact]
        public void CheckJSONNumber_Empty_String()
        {
            Assert.False(Program.IsStringJSONNumber(""));
        }

        [Fact]
        public void CheckJSONNumber_FirstDigitIs_0()
        {
            Assert.False(Program.IsStringJSONNumber("0123"));
        }
        [Fact]
        public void CheckJSONNumber_FirstDigitIs_0_NegativeNumber()
        {
            Assert.False(Program.IsStringJSONNumber("-0123"));
        }

        [Fact]
        public void CheckJSONNumber_RealNumber()
        {
            Assert.True(Program.IsStringJSONNumber("12.34"));
        }


        [Theory]
        [InlineData("12.3E1")]
        [InlineData("123.E-7")]
        [InlineData("12.3E+3")]
        [InlineData("12.3e4")]
        [InlineData("123.e-4")]
        public void CheckJSONNumber_exponent_(string input)
        {
            Assert.True(Program.IsStringJSONNumber(input));
        }

        [Fact]
        public void CheckJSONNumber_SpecialCase()
        {
            Assert.False(Program.IsStringJSONNumber("12."));
        }

        [Fact]
        public void CheckJSONNumber_DecimalNumber_SpecialCase()
        {
            Assert.True(Program.IsStringJSONNumber("0.23"));
        }


    }
}
