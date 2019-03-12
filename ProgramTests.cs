using System;
using Xunit;

namespace JSONformat_validator.XUnitTestProject1
{
    public class ProgramTests
    {
        [Fact]
        public void CheckJSOnFormat_SimpleWord()
        {
            Assert.True(Program.CheckJSONString("\"Test\""));
        }

        [Fact]
        public void CheckJSOnFormat_WordHasNot_Commas()
        {
            Assert.False(Program.CheckJSONString("Test\""));
        }
    }
}
