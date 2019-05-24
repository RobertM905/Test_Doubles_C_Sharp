using FluentAssertions;
using MissileLauncher.Core;

namespace MissileLauncherTests.TestDoubles
{
    public class MockMissile : Missile
    {
        public bool LaunchWasCalled { get; private set; }
        public bool DisableWasCalled { get; private set; }

        public MockMissile()
        {
            LaunchWasCalled = false;
            DisableWasCalled = false;
        }
      
        public override void Launch()
        {
            LaunchWasCalled = true;
        }

        public override void Disable()
        {
            DisableWasCalled = true;
        }

        public void VerifyCodeRedAbort()
        {
            LaunchWasCalled.Should().BeFalse();
            DisableWasCalled.Should().BeTrue();
        }
    }
}