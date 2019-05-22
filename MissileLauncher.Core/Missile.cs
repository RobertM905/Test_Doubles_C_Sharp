using System;

namespace MissileLauncher.Core
{
    public class Missile
    {
        public virtual void Launch()
        {
            Console.WriteLine("Missile Launched");
        }

        public virtual void Disable()
        {
            Console.WriteLine("Missile Disabled");
        }
    }
}