using Moq;

namespace InsuranceService.Tests
{
    [TestFixture]
    public class BlackBoxTests
    {
        [Test]
        public void CalcPremium_EquivClass_RuralBetween18And30()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(17, "rural"), Is.EqualTo(0)); // boundary 
            Assert.That(ins.CalcPremium(18, "rural"), Is.EqualTo(5)); // boundary 

            Assert.That(ins.CalcPremium(24, "rural"), Is.EqualTo(5));

            Assert.That(ins.CalcPremium(30, "rural"), Is.EqualTo(5)); // boundary
            Assert.That(ins.CalcPremium(31, "rural"), Is.EqualTo(2.5)); // boundary 

            Assert.That(ins.CalcPremium(24, "urban"), Is.EqualTo(6)); // invalid 
            Assert.That(ins.CalcPremium(16, "rural"), Is.EqualTo(0)); // invalid 
            Assert.That(ins.CalcPremium(33, "rural"), Is.EqualTo(2.5)); // invalid 
        }

        [Test]
        public void CalcPremium_EquivClass_RuralOver30()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(30, "rural"), Is.EqualTo(5)); // boundary 
            Assert.That(ins.CalcPremium(31, "rural"), Is.EqualTo(2.5)); // boundary 

            Assert.That(ins.CalcPremium(42, "rural"), Is.EqualTo(2.5));

            Assert.That(ins.CalcPremium(42, "urban"), Is.EqualTo(5)); // invalid 
            Assert.That(ins.CalcPremium(21, "rural"), Is.EqualTo(5)); // invalid 
        }

        [Test]
        public void CalcPremium_EquivClass_UrbanBetween18And30()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(17, "urban"), Is.EqualTo(0)); // boundary 
            Assert.That(ins.CalcPremium(18, "urban"), Is.EqualTo(6)); // boundary 

            Assert.That(ins.CalcPremium(24, "urban"), Is.EqualTo(6));

            Assert.That(ins.CalcPremium(35, "urban"), Is.EqualTo(6)); // boundary
            Assert.That(ins.CalcPremium(36, "urban"), Is.EqualTo(5)); // boundary 

            Assert.That(ins.CalcPremium(24, "rural"), Is.EqualTo(5)); // invalid 
            Assert.That(ins.CalcPremium(17, "urban"), Is.EqualTo(0)); // invalid 
            Assert.That(ins.CalcPremium(42, "urban"), Is.EqualTo(5)); // invalid 
        }

        [Test]
        public void CalcPremium_EquivClass_UrbanOver30()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(35, "urban"), Is.EqualTo(6)); // boundary 
            Assert.That(ins.CalcPremium(36, "urban"), Is.EqualTo(5)); // boundary 

            Assert.That(ins.CalcPremium(42, "urban"), Is.EqualTo(5));

            Assert.That(ins.CalcPremium(42, "rural"), Is.EqualTo(2.5)); // invalid 
            Assert.That(ins.CalcPremium(21, "urban"), Is.EqualTo(6)); // invalid 
        }

        [Test]
        public void CalcPremium_EquivClass_AgeOver50()
        {
            var discountService = new Mock<DiscountService>();
            discountService.Setup(x => x.GetDiscount()).Returns(0.85);

            InsuranceService ins = new InsuranceService(discountService.Object);
            Assert.That(ins.CalcPremium(49, "rural"), Is.EqualTo(2.5)); // boundary 
            Assert.That(ins.CalcPremium(50, "rural"), Is.EqualTo(2.5 * 0.85)); // boundary 
            Assert.That(ins.CalcPremium(49, "urban"), Is.EqualTo(5)); // boundary 
            Assert.That(ins.CalcPremium(50, "urban"), Is.EqualTo(5 * 0.85)); // boundary 

            Assert.That(ins.CalcPremium(60, "urban"), Is.EqualTo(5 * 0.85));
            Assert.That(ins.CalcPremium(60, "rural"), Is.EqualTo(2.5 * 0.85));

            Assert.That(ins.CalcPremium(49, "rural"), Is.EqualTo(2.5)); // invalid 
            Assert.That(ins.CalcPremium(49, "urban"), Is.EqualTo(5)); // invalid 
            Assert.That(ins.CalcPremium(65, "cat"), Is.EqualTo(0)); // invalid 
        }

    }
}
