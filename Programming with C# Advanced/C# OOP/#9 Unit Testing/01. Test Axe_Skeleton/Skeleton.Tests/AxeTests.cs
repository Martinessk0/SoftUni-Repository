using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void Initialize()
        {
            axe = new Axe(10, 2);
            dummy = new Dummy(20, 5);
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(1,axe.DurabilityPoints);
        }

        [Test]
        public void AttackWithBrokenAxe()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy),Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}