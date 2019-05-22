namespace MissileLauncher.Core
{
    public class MissileLauncher
    {
        public void Launch(Missile missile, LaunchCode code, UsedLaunchCodes usedCodes)
        {
            if(code.isValidCode() && !usedCodes.Contains(code))
            {
                missile.Launch();
                usedCodes.Add(code);
            }
            else
            {
                missile.Disable();
            }
        }
    }
}