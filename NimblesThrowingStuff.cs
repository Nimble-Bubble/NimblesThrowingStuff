using System;
using Terraria;
using Terraria.ModLoader;

namespace NimblesThrowingStuff
{
	public class NimblesThrowingStuff : Mod
	{
        public static NimblesThrowingStuff instance;

        public NimblesThrowingStuff()
        {
            Properties = new ModProperties()
            {
                Autoload = true
            };
        }
        public override void Load()
        {
            instance = this;
        }
        public override void Unload()
        {
            instance = null;
        }
	}
}