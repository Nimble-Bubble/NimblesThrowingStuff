using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Projectiles.Summoning;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff.Buffs
{
    public class GuardGate : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Guard");
			// Description.SetDefault("Defense boosted at the cost of reduced mobility");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<NimblesPlayer>().guardState = true;
		}
	}
}
