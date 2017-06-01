namespace ColorCalcTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ColorCalc.BL;

    [TestClass]
    public class ColorCalc_CalculateHexFromRgbTest
    {
        [TestMethod]
        public void Assert_CalculateHexFromRgb_Correct1()
        {
            int[] input = new int[] { 123, 123, 123 };

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#7B7B7B", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Correct2()
        {
            int[] input = new int[] { 0, 0, 0 };

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#000000", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Correct3()
        {
            int[] input = new int[] { 255, 255, 255 };

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#FFFFFF", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Correct4()
        {
            int[] input = new int[] { 1, 1, 1 };

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#010101", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Failure1()
        {
            int[] input = new int[] { 255, 255, 256 };

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Failure2()
        {
            int[] input = new int[] { 255, 255 };

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Failure3()
        {
            int[] input = new int[] { 255, 255, 360 };

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Failure4()
        {
            int[] input = new int[] { 255, 3600, 100 };

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Failure5()
        {
            int[] input = new int[] { 255, 107, 13, 100 };

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Failure6()
        {
            int[] input = new int[0];

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#", result);
        }

        [TestMethod]
        public void Assert_CalculateHexFromRgb_Failure7()
        {
            int[] input = null;

            var result = ColorCalc.CalculateHexFromRgb(input);

            Assert.AreEqual("#", result);
        }
    }
}
