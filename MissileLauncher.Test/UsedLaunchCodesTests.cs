using NUnit.Framework;
using MissileLauncherTests.TestDoubles;
using FluentAssertions;
using MissileLauncher.Core;


namespace MissileLauncherTests
{
    [TestFixture]
    public class UsedLaunchCodesTests
    {
        

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Contains()
        {
            LaunchCode launchCode = new LaunchCode();
            UsedLaunchCodes usedLaunchCodes = new FakeUsedLaunchCodes();
            usedLaunchCodes.Contains(launchCode).Should().BeFalse();
            usedLaunchCodes.Add(launchCode);
            usedLaunchCodes.Contains(launchCode).Should().BeTrue();

            
        }
    }
}