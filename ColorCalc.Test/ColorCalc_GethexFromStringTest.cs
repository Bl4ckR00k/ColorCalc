namespace ColorCalcTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ColorCalc.BL;

    [TestClass]
    public class ColorCalc_GetHexFromStringTest
    {
        [TestMethod]
        public void Assert_GetHexFromString_StringWhiteSpace()
        {
            const string input = " ";

            var result = ColorCalc.GetHexFromString(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetHexFromString_StringOnlyHashtag()
        {
            const string input = "#";

            var result = ColorCalc.GetHexFromString(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetHexFromString_StringFailure1()
        {
            const string input = "b6,Aa,ad";

            var result = ColorCalc.GetHexFromString(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetHexFromString_StringFailure2()
        {
            const string input = "#1234";

            var result = ColorCalc.GetHexFromString(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetHexFromString_StringFailure3()
        {
            const string input = "#12345678";

            var result = ColorCalc.GetHexFromString(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetHexFromString_StringFailure4()
        {
            const string input = "#12FF5G";

            var result = ColorCalc.GetHexFromString(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetHexFromString_StringFailure5()
        {
            const string input = "#12,45,107";

            var result = ColorCalc.GetHexFromString(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetHexFromString_StringFailure6()
        {
            const string input = "124,107,-13";

            var result = ColorCalc.GetHexFromString(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetHexFromString_StringCorrect1()
        {
            const string input = "#123456";

            var result = ColorCalc.GetHexFromString(input);

            Assert.AreEqual(3, result.Length, "Array-Length false.");
            Assert.AreEqual("12", result[0], "first value false");
            Assert.AreEqual("34", result[1], "second value false");
            Assert.AreEqual("56", result[2], "thrid value false");
        }                      

        [TestMethod]
        public void Assert_GetHexFromString_StringCorrect2()
        {
            const string input = "#abcdef";

            var result = ColorCalc.GetHexFromString(input);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("ab", result[0], "first value false");
            Assert.AreEqual("cd", result[1], "second value false");
            Assert.AreEqual("ef", result[2], "thrid value false");
        }

        [TestMethod]
        public void Assert_GetHexFromString_StringCorrect3()
        {
            const string input = "#7CFF6B";

            var result = ColorCalc.GetHexFromString(input);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("7C", result[0], "first value false");
            Assert.AreEqual("FF", result[1], "second value false");
            Assert.AreEqual("6B", result[2], "thrid value false");
        }
    }
}
