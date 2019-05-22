using MissileLauncher.Core;

namespace MissileLauncherTests.TestDoubles
{
    public class SpyMissile : Missile
    {
        public bool LaunchWasCalled { get; private set; }
        public bool DisableWasCalled { get; private set; }

        public SpyMissile()
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
    }
}