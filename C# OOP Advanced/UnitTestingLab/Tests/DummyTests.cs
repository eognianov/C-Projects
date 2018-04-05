using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(1);
            Assert.That(dummy.Health, Is.EqualTo(9), "Dummy dosn't take demage.");
        }

        [Test]
        public void DeadDummyThrowsExecptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);
            Assert.That(() => dummy.TakeAttack(5), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveExpirience()
        {
            Dummy dummy = new Dummy(0, 10);
            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(10), "Target is not dead.");
        }

        [Test]
        public void AliveDummyCannotGiveExpirience()
        {
            Dummy dummy = new Dummy(5, 10);
            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
