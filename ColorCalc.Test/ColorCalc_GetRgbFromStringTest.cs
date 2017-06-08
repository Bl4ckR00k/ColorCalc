namespace ColorCalcTest
{
    using ColorCalc.BL;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ColorCalc_GetRgbFromStringTest
    {
        [TestMethod]
        public void Assert_GetRgbFromString_StringWhiteSpace()
        {
            const string Input = " ";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringOnlyKomma()
        {
            const string Input = ", ,";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringFailure1()
        {
            const string Input = "b6,Aa,ad";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringFailure2()
        {
            const string Input = "105,13";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringFailure3()
        {
            const string Input = "124,36,107,12";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringFailure4()
        {
            const string Input = "124,3600,107";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringFailure5()
        {
            const string Input = "124,360,107";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringFailure6()
        {
            const string Input = "124,107,-13";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringCorrect1()
        {
            const string Input = "124,255,107";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.AreEqual(3, result.Length, "Array-Length false.");
            Assert.AreEqual(124, result[0], "first value false");
            Assert.AreEqual(255, result[1], "second value false");
            Assert.AreEqual(107, result[2], "thrid value false");
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringCorrect2()
        {
            const string Input = "124.255.107";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(124, result[0], "first value false");
            Assert.AreEqual(255, result[1], "second value false");
            Assert.AreEqual(107, result[2], "thrid value false");
        }

        [TestMethod]
        public void Assert_GetRgbFromString_StringCorrect3()
        {
            const string Input = "124, 255, 107";

            var result = ColorCalc.GetRgbFromString(Input);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(124, result[0], "first value false");
            Assert.AreEqual(255, result[1], "second value false");
            Assert.AreEqual(107, result[2], "thrid value false");
        }
    }
}
