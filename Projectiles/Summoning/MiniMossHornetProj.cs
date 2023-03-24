using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Summoning;
using NimblesThrowingStuff.Buffs;

namespace NimblesThrowingStuff.Projectiles.Summoning
{
	public class MiniMossHornetProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Moss Hornet");
			Main.projFrames[Projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}

		public sealed override void SetDefaults() {
			Projectile.width = 44;
			Projectile.height = 38;
			Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.alpha = 0;
            Projectile.aiStyle = 62;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
            AIType = 373;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return true;
		}

		public override void AI() 
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
		}
	}
}