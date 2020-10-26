using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Projectiles.Summoning;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff.Buffs
{
    public class OrichalcumTackShooterBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Tack Shooter");
			Description.SetDefault("The 'pew-pew'-ers of Plato's plates will shoot a short range volley of tacks in 8 directions");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ProjectileType<OrichalcumTackShooterProj>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
