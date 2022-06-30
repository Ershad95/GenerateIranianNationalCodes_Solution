using GenerateIranianNationalCodes_ML_Detection;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GenerateIranianNationalCodes.Test
{
    public class Tests
    {
        
        [Test]
        public void CheckInvalidCode()
        {
            Assert.IsFalse(Util.Utility.Check("0000000000"),$"Is Not Valid ");
            Assert.IsFalse(Util.Utility.Check("1"),$"Is Not Valid ");
            Assert.IsFalse(Util.Utility.Check("143434"),$"Is Not Valid ");
            Assert.IsFalse(Util.Utility.Check("909090"),$"Is Not Valid ");
            Assert.IsFalse(Util.Utility.Check("03245455"),$"Is Not Valid ");
            Assert.IsFalse(Util.Utility.Check("9999999999"), $"Is Not Valid ");
            Assert.IsFalse(Util.Utility.Check("5555555555"), $"Is Not Valid ");
            Assert.IsFalse(Util.Utility.Check("33333333333355555"), $"Is Not Valid ");
            Assert.IsFalse(Util.Utility.Check("0216548484"), $"Is Not Valid ");
            Assert.IsFalse(Util.Utility.Check("0318374747"), $"Is Not Valid ");
        }
        [Test]
        public void CheckValidCode()
        {
            Assert.IsTrue(Util.Utility.Check("0311226817"), $"Is Valid ");
            Assert.IsTrue(Util.Utility.Check("0012000000"), $"Is Valid ");
            Assert.IsTrue(Util.Utility.Check("0325020000"), $"Is Valid ");
            Assert.IsTrue(Util.Utility.Check("0325020000"), $"Is Valid ");
        }
        [Test]
        public void PredicateKarajCodeTest()
        {
       
            // Make a single prediction on the sample data and print results
            var predictionResult = MLncodeModel.Predict(new MLncodeModel.ModelInput() { Ncode = Convert.ToInt64("0311226817") });
            Assert.AreEqual(predictionResult.Prediction,"karaj");
            Assert.AreNotEqual(predictionResult.Prediction, "tehran");

            // Make a single prediction on the sample data and print results
            var predictionResult2 = MLncodeModel.Predict(new MLncodeModel.ModelInput() { Ncode = Convert.ToInt64("0325020000") });
            Assert.AreEqual(predictionResult2.Prediction, "karaj");
            Assert.AreNotEqual(predictionResult2.Prediction, "tehran");
        }
        [Test]
        public void PredicateTehranCodeTest()
        {
            // Make a single prediction on the sample data and print results
            var predictionResult1 = MLncodeModel.Predict(new MLncodeModel.ModelInput() { Ncode = Convert.ToInt64("0012000000") });
            Assert.AreEqual(predictionResult1.Prediction, "tehran");
            Assert.AreNotEqual(predictionResult1.Prediction, "karaj");
            // Make a single prediction on the sample data and print results
            var predictionResult2 = MLncodeModel.Predict(new MLncodeModel.ModelInput() { Ncode = Convert.ToInt64("0011080000") });
            Assert.AreEqual(predictionResult2.Prediction, "tehran");
            Assert.AreNotEqual(predictionResult2.Prediction, "karaj");
        }
        [Test]
        public void PredicateGeneralKarajTest()
        {
            foreach (var code in new List<string>() { "031", "032" })
            {
                for (long number = 0; number < 9999999; number++)
                {
                    var ncode = $"{code}{number}";
                    var len = ncode.Length;
                    if (ncode.Length < 10)
                        for (int j = 1; j <= 10 - len; j++)
                            ncode = ncode + "0";

                    if (Util.Utility.Check(ncode))
                    {
                        var predictionResult = MLncodeModel.Predict(new MLncodeModel.ModelInput() { Ncode = Convert.ToInt64(ncode) });
                        Assert.AreEqual(predictionResult.Prediction, "karaj");
                    }
                }
            }
        }
        [Test]
        public void PredicateGeneralTehranTest()
        {
            foreach (var code in new List<string>() { "001", "002", "003", "004","005","006","007","008" })
            {
                for (long number = 0; number < 9999999; number++)
                {
                    var ncode = $"{code}{number}";
                    var len = ncode.Length;
                    if (ncode.Length < 10)
                        for (int j = 1; j <= 10 - len; j++)
                            ncode = ncode + "0";

                    if (Util.Utility.Check(ncode))
                    {
                        var predictionResult = MLncodeModel.Predict(new MLncodeModel.ModelInput() { Ncode = Convert.ToInt64(ncode) });
                        Assert.AreEqual(predictionResult.Prediction, "tehran");
                    }
                }
            }
        }
        [Test]
        public void PredicatePercentageGeneralKarajTest()
        {
            foreach (var code in new List<string>() { "031", "032" })
            {
                for (long number = 0; number < 9999999; number++)
                {
                    var ncode = $"{code}{number}";
                    var len = ncode.Length;
                    if (ncode.Length < 10)
                        for (int j = 1; j <= 10 - len; j++)
                            ncode = ncode + "0";

                    if (Util.Utility.Check(ncode))
                    {
                        var predictionResult = MLncodeModel.Predict(new MLncodeModel.ModelInput() { Ncode = Convert.ToInt64(ncode) });
                        Assert.GreaterOrEqual(predictionResult.Score[0]*100, 98);
                    }
                }
            }
        }
        [Test]
        public void PredicatePercentageGeneralTehranTest()
        {
            foreach (var code in new List<string>() { "001", "002", "003", "004", "005", "006", "007", "008" })
            {
                for (long number = 0; number < 9999999; number++)
                {
                    var ncode = $"{code}{number}";
                    var len = ncode.Length;
                    if (ncode.Length < 10)
                        for (int j = 1; j <= 10 - len; j++)
                            ncode = ncode + "0";

                    if (Util.Utility.Check(ncode))
                    {
                        var predictionResult = MLncodeModel.Predict(new MLncodeModel.ModelInput() { Ncode = Convert.ToInt64(ncode) });
                        Assert.GreaterOrEqual(predictionResult.Score[1] * 100, 98);
                    }
                }
            }
        }
    }
}