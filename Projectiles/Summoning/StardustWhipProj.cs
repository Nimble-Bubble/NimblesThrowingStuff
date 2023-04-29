using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Summoning;
using NimblesThrowingStuff.Buffs;

namespace NimblesThrowingStuff.Projectiles.Summoning
{
	public class StardustWhipProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Milkyway Cleaver");
			Main.projFrames[Projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.IsAWhip[Type] = true;
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}

		public sealed override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.aiStyle = 165;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 1;
			Projectile.WhipSettings.Segments = 20;
			Projectile.WhipSettings.RangeMultiplier = 2f;
		}

		/* public override void AI() 
        {
			Player player = Main.player[Projectile.owner];

			#region Active check
                int num1 = Projectile.type == ModContent.ProjectileType<MiniMossHornetProj>() ? 1 : 0;
			if (!player.active) {
				player.ClearBuff(Mod.Find<ModBuff>("MossHornetBuff").Type);
			}
			if (player.HasBuff(Mod.Find<ModBuff>("MossHornetBuff").Type)) {
				Projectile.timeLeft = 2;
			}
             if (num1 == 0)
             {
        return;
             }
            player.AddBuff(ModContent.BuffType<MossHornetBuff>(), 18000, true);
			#endregion
                
			#region Animation and visuals
			Lighting.AddLight(Projectile.Center, Color.Green.ToVector3() * 0.75f);
			#endregion
		} */
	}
}