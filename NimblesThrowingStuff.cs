using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.WorldBuilding;
using NimblesThrowingStuff.NPCs.Morilus;
using NimblesThrowingStuff.Items.Consumables;
using NimblesThrowingStuff.Items.Vanity;
using NimblesThrowingStuff.Items.Weapons.Melee;
using NimblesThrowingStuff.Items.Weapons.Ranged;
using NimblesThrowingStuff.Items.Weapons.Magic;
using NimblesThrowingStuff.Items.Weapons.Summoning;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using NimblesThrowingStuff.Items.Placeables.Furniture;
using NimblesThrowingStuff.NPCs.Town;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff
{
	public class NimblesThrowingStuff : Mod
	{
        public static NimblesThrowingStuff instance;

        public static ModKeybind MIGuardKey;
        
        public bool youCanEnchant;

        public NimblesThrowingStuff()
        {
            GoreAutoloadingEnabled = true;
            ContentAutoloadingEnabled = true;
        }
        public override void Load()
        {
            instance = this;
            MIGuardKey = KeybindLoader.RegisterKeybind(this, "Guard", "Z");
            ModLoader.TryGetMod("Wikithis", out Mod wikithis);
            if (wikithis != null && !Main.dedServ)
            {
                wikithis.Call("AddModURL", this, "https://terrariamods.wiki.gg/wiki/Magnumiactus/{}");
            }
        }
        public override void Unload()
        {
            instance = null;
            MIGuardKey = null;
        }
        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("Census", out Mod censusMod);
            ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist);
            ModLoader.TryGetMod("FargosSoulsMod", out Mod FargosSouls);
            if (FargosSouls != null)
            {
                youCanEnchant = true;
            }
            if (censusMod != null)
                {
                    censusMod.Call("TownNPCCondition", Find<ModNPC>("LivingRelic").Type, "Defeat the Eye of Cthulhu"); 
                    censusMod.Call("TownNPCCondition", Find<ModNPC>("Lotteryboy").Type, "Defeat the Moon Lord");     
                }
            if(bossChecklist != null)
            {
                bossChecklist.Call(
                "LogBoss",
                this,
                "Morilus",
                19f,
                () => NimblesWorld.downedMorilus,
                ModContent.NPCType<MorilusMain>(),
                new Dictionary<string, object>() { 
                    ["spawnItems"] = ModContent.ItemType<DeceptiveArtifact>(),
                    ["collectibles"] = new List<int>() { ModContent.ItemType<MorilusMask>(), ModContent.ItemType<MorilusTrophy>() }
                }
                );
            }

        }
        //private static ModRecipe GetNewRecipe() => new ModRecipe(ModContent.GetInstance<NimblesThrowingStuff>());
	}
}