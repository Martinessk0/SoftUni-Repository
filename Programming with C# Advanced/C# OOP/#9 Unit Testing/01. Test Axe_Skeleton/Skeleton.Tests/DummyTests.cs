using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void Initialize()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(20, 5);
        }
        [Test]
        public void DummyLoosesHealthIfAttacked()
        {
            axe.Attack(dummy);
            
            Assert.AreEqual(10,dummy.Health);
        }
        [Test]
        public void DummyThrowsAnExceptionIfAttacked()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.AreEqual(5,dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException.With
                    .Message.EqualTo("Target is not dead."));
        }
    }
}