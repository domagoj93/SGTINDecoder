using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGTINDecoder.HelperMethods;

namespace UnitTests.SGTIN
{
    [TestClass]
    public class SGTIN_96_Tests
    {
        [TestMethod]
        public void ValidateTag_ReturnsTrue()
        {
            var HEX_SGTIN_96 = "3098D0A357783C0034E9DF74";

            var result = Validator.IsValid_SGTIN_96(HEX_SGTIN_96);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateTag_ReturnsFalse()
        {
            var HEX_SGTIN_96 = "30HB747BA582600005AE9068";

            var result = Validator.IsValid_SGTIN_96(HEX_SGTIN_96);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePartition0_ReturnsTrue()
        {
            var partition = 0;
            var expectedResult = (40, 4);

            var result = PartitionResolveHelper.GetCompanyPrefixAndItemReference(partition);

            Assert.AreEqual(result,expectedResult);
        }

        [TestMethod]
        public void ValidatePartition1_ReturnsTrue()
        {
            var partition = 1;
            var expectedResult = (37, 7);

            var result = PartitionResolveHelper.GetCompanyPrefixAndItemReference(partition);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ValidatePartition2_ReturnsTrue()
        {
            var partition = 2;
            var expectedResult = (34, 10);

            var result = PartitionResolveHelper.GetCompanyPrefixAndItemReference(partition);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ValidatePartition3_ReturnsTrue()
        {
            var partition = 3;
            var expectedResult = (30, 14);

            var result = PartitionResolveHelper.GetCompanyPrefixAndItemReference(partition);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ValidatePartition4_ReturnsTrue()
        {
            var partition = 4;
            var expectedResult = (27, 17);

            var result = PartitionResolveHelper.GetCompanyPrefixAndItemReference(partition);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ValidatePartition5_ReturnsTrue()
        {
            var partition = 5;
            var expectedResult = (24, 20);

            var result = PartitionResolveHelper.GetCompanyPrefixAndItemReference(partition);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ValidatePartition6_ReturnsTrue()
        {
            var partition = 6;
            var expectedResult = (20, 24);

            var result = PartitionResolveHelper.GetCompanyPrefixAndItemReference(partition);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ValidatePartition7_ReturnsTrue()
        {
            var partition = 7;
            var expectedResult = (0, 0);

            var result = PartitionResolveHelper.GetCompanyPrefixAndItemReference(partition);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
