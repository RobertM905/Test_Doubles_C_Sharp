using MissileLauncher.Core;

namespace MissileLauncherTests.TestDoubles
{
    public class ExpiredLaunchCode : LaunchCode
    {
        public override bool isExpired()
        {
            return true;
        }

        public override bool isSigned()
        {
            return true;
        }
    }
}