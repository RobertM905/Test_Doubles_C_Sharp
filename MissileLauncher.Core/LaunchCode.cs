namespace MissileLauncher.Core
{
    public class LaunchCode
    {
        public bool isValidCode()
        {
            return isExpired() == false && isSigned();
        }

        public virtual bool isExpired()
        {
            return false;
        }

        public virtual bool isSigned()
        {
            return true;
        }
    }
}