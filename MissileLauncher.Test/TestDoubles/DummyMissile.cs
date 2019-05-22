using System;
using MissileLauncher.Core;

namespace MissileLauncherTests.TestDoubles
{
    public class DummyMissile : Missile
    {
        public override void Launch()
        {
            throw new NotImplementedException();
        }
    }
}