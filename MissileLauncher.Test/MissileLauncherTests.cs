using NUnit.Framework;
using MissileLauncherTests.TestDoubles;
using FluentAssertions;
using MissileLauncher.Core;


namespace MissileLauncherTests
{
    [TestFixture]
    public class MissileLauncherTestsUsingMissileSpy
    {
        private MissileLauncher.Core.MissileLauncher _missileLauncher;
        private SpyMissile _missile;
        private ExpiredLaunchCode _code;
        private FakeUsedLaunchCodes _usedCodes;

        [SetUp]
        public void Setup()
        {
            _missile = new SpyMissile();
            _code = new ExpiredLaunchCode();
            _usedCodes = new FakeUsedLaunchCodes();
            _missileLauncher = new MissileLauncher.Core.MissileLauncher();

        }

        [Test]
        public void GivenExpiredLaunchCodes_TheMissileIsNotLaunched()
        {
            _missileLauncher.Launch(_missile, _code, _usedCodes);
            _missile.LaunchWasCalled.Should().BeFalse();
            _missile.DisableWasCalled.Should().BeTrue();
        }
        
        [Test]
        public void GivenUnsignedLaunchCodes_TheMissileIsNotLaunched()
        {
            _missileLauncher.Launch(_missile, _code, _usedCodes);
            _missile.LaunchWasCalled.Should().BeFalse();
            _missile.DisableWasCalled.Should().BeTrue();
        }
    }

    [TestFixture]
    public class MissileLauncherTestsUsingMissileMock
    {
        private MissileLauncher.Core.MissileLauncher _missileLauncher;
        private MockMissile _missile;
        private ExpiredLaunchCode _code;
        private FakeUsedLaunchCodes _usedCodes;

        [SetUp]
        public void Setup()
        {
            _missile = new MockMissile();
            _code = new ExpiredLaunchCode();
            _usedCodes = new FakeUsedLaunchCodes();
            _missileLauncher = new MissileLauncher.Core.MissileLauncher();

        }

        [Test]
        public void GivenExpiredLaunchCodes_MissileCodeRedAbort()
        {
            _missileLauncher.Launch(_missile, _code, _usedCodes);
            _missile.VerifyCodeRedAbort();
        }

        [Test]
        public void GivenUnsignedLaunchCodes_MissileCodeRedAbort()
        {
            _missileLauncher.Launch(_missile, _code, _usedCodes);
            _missile.VerifyCodeRedAbort();
        }
        
        [Test]
        public void GivenUsedCodes_MissileCodeRedAbort()
        {
            var code = new LaunchCode();
            var missileOne = new Missile();
            _missileLauncher.Launch(missileOne, code, _usedCodes);
            var missileTwo = new MockMissile();
            _missileLauncher.Launch(missileTwo, code, _usedCodes);
            missileTwo.VerifyCodeRedAbort();
        }
    }
}