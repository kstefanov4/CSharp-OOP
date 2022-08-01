namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void CtorShouldCreateProperObject()
        {
            Warrior warrior = new Warrior("warrior1", 10, 15);
            string name = warrior.Name;
            int damage = warrior.Damage;
            int hp = warrior.HP;

            Assert.AreEqual("warrior1", name);
            Assert.AreEqual(10, damage);
            Assert.AreEqual(15, hp);

        }

        [Test]
        public void IfNameIsNullOrWhiteSpaceShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(" ", 10, 15);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void DamageLessThanOrEqualToZeroShouldThrowException(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("warrior1", damage, 15);
            }, "Damage value should be positive!");
        }

        [Test]
        public void HpLessThanZeroShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("warrior1", 10, -1);
            }, "HP should not be negative!");
        }

        [Test]
        public void TooLowHpShouldThrowException()
        {
            Warrior warrior = new Warrior("warrior1", 10, 30);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(new Warrior("warrior2", 30, 40));
            }, "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void TooLowEnemyHpShouldThrowException()
        {
            Warrior warrior = new Warrior("warrior1", 10, 35);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(new Warrior("warrior2", 30, 30));
            }, $"Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void TryingToAttackTooStrongEnemyShouldThrowException()
        {
            Warrior warrior = new Warrior("warrior1", 10, 35);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(new Warrior("warrior2", 36, 40));
            }, $"You are trying to attack too strong enemy");
        }

        [Test]
        public void AttackerHpShouldDecreaseWithTheEnemyDamage()
        {
            Warrior warrior = new Warrior("warrior1", 10, 35);
            Warrior enemy = new Warrior("warrior2", 30, 40);

            warrior.Attack(enemy);

            Assert.AreEqual(5, warrior.HP);
        }

        [Test]
        public void AttackerDamageMoreThantEnemyHPShouldSetEnemyHpToZero()
        {
            Warrior warrior = new Warrior("warrior1", 50, 35);
            Warrior enemy = new Warrior("warrior2", 30, 40);

            warrior.Attack(enemy);

            Assert.AreEqual(0, enemy.HP);
        }

        [Test]
        public void AttackerDamageLessThantEnemyHPShouldDecreaseEnemyHpToZero()
        {
            Warrior warrior = new Warrior("warrior1", 35, 35);
            Warrior enemy = new Warrior("warrior2", 30, 40);

            warrior.Attack(enemy);

            Assert.AreEqual(5, enemy.HP);
        }
    }
}