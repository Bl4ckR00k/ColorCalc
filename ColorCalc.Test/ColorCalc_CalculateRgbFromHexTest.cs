namespace ColorCalcTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ColorCalc.BL;

    [TestClass]
    public class ColorCalc_CalculateRgbFromHexTest
    {
        [TestMethod]
        public void Assert_CalculateRgbFromHex_Correct1()
        {
            string[] input = new string[] { "7B", "7B", "7B" };

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual("123,123,123", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Correct2()
        {
            string[] input = new string[] { "00","00","00" };

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual("0,0,0", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Correct3()
        {
            string[] input = new string[] { "FF", "FF", "FF" };

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual("255,255,255", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Correct4()
        {
            string[] input = new string[] { "01", "01", "01" };

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual("1,1,1", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure1()
        {
            string[] input = new string[] { "FF", "FF", "FG" };

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure2()
        {
            string[] input = new string[] { "FF", "FF" };

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure3()
        {
            string[] input = new string[] { "XX", "FF", "13" };

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure4()
        {
            string[] input = new string[] { "AB", "XX", "67" };

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure5()
        {
            string[] input = new string[] { "FF", "6B", "13", "AB" };

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure6()
        {
            string[] input = new string[0];

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure7()
        {
            string[] input = null;

            var result = ColorCalc.CalculateRgbFromHex(input, out int[] aRGB);

            Assert.AreEqual(",,", result);
        }
    }
}
