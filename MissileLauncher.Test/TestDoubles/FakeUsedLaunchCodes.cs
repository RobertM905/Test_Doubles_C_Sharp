using System.Collections.Generic;
using MissileLauncher.Core;

namespace MissileLauncherTests.TestDoubles
{
    public class FakeUsedLaunchCodes : UsedLaunchCodes
    {
        private HashSet<LaunchCode> set = new HashSet<LaunchCode>();

        public override bool Contains(LaunchCode launchCode)
        {
            return set.Contains(launchCode);
        }

        public override void Add(LaunchCode launchCode)
        {
            set.Add(launchCode);
        }
    }
}