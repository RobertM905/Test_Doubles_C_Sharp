using MissileLauncher.Core;

namespace MissileLauncherTests.TestDoubles
{
    public class UnsignedLaunchCode : LaunchCode
    {
        public override bool isExpired()
        {
            return false;
        }

        public override bool isSigned()
        {
            return false;
        }
    }
}