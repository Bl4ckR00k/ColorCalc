namespace ColorCalcTest
{
    using ColorCalc.BL;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ColorCalc_CalculateRgbFromHexTest
    {
        [TestMethod]
        public void Assert_CalculateRgbFromHex_Correct1()
        {
            string[] input = { "7B", "7B", "7B" };

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual("123,123,123", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Correct2()
        {
            string[] input = { "00", "00", "00" };

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual("0,0,0", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Correct3()
        {
            string[] input = { "FF", "FF", "FF" };

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual("255,255,255", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Correct4()
        {
            string[] input = { "01", "01", "01" };

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual("1,1,1", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure1()
        {
            string[] input = { "FF", "FF", "FG" };

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure2()
        {
            string[] input = { "FF", "FF" };

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure3()
        {
            string[] input = { "XX", "FF", "13" };

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure4()
        {
            string[] input = { "AB", "XX", "67" };

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure5()
        {
            string[] input = { "FF", "6B", "13", "AB" };

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure6()
        {
            var input = new string[0];

            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(input, out aRgb);

            Assert.AreEqual(",,", result);
        }

        [TestMethod]
        public void Assert_CalculateRgbFromHex_Failure7()
        {
            int[] aRgb;

            var result = ColorCalc.CalculateRgbFromHex(null, out aRgb);

            Assert.AreEqual(",,", result);
        }
    }
}
