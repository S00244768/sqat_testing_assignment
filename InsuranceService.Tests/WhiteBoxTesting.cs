using Moq;

namespace InsuranceService.Tests
{
    [TestFixture]
    public class WhiteBoxTests
    {

        [Test]
        public void CalcPremium_RuralBetween18and30()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(24, "rural"), Is.EqualTo(5));
        }


        [Test]
        public void CalcPremium_RuralOver31and50()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(60, "rural"), Is.EqualTo(2.5 * 0.85));
        }

        [Test]
        public void CalcPremium_RuralBelow18()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(17, "rural"), Is.EqualTo(0));
        }

        [Test]
        public void CalcPremium_UrbanBetween18and35()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(24, "urban"), Is.EqualTo(6));
        }

        [Test]
        public void CalcPremium_UrbanOver36and50()
        {

            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(60, "urban"), Is.EqualTo(5 * 0.85));
        }

        [Test]
        public void CalcPremium_UrbanBelow18()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(17, "urban"), Is.EqualTo(0));
        }

        [Test]
        public void CalcPremium_InvalidLocation()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(24, "cat"), Is.EqualTo(0));
        }


    }
}