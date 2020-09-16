using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

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
        public override void PostSetupContent()
        {
         Mod censusMod = ModLoader.GetMod("Census");
            if(censusMod != null)
            {
             censusMod.Call("TownNPCCondition", NPCType("Living Relic"), "Defeat the Eye of Cthulhu");   
            }
        }
	}
}