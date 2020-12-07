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
			Main.projFrames[projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			// Denotes that this projectile is a pet or minion
			Main.projPet[projectile.type] = true;
			// This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			// Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public sealed override void SetDefaults() {
			projectile.width = 44;
			projectile.height = 38;
			projectile.tileCollide = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.alpha = 0;
            projectile.aiStyle = 62;

			// These below are needed for a minion weapon
			// Only controls if it deals damage to enemies on contact (more on that later)
			projectile.friendly = true;
			// Only determines the damage type
			projectile.minion = true;
			// Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
			projectile.minionSlots = 1f;
			// Needed so the minion doesn't despawn on collision with enemies or tiles
			projectile.penetrate = -1;
            aiType = 373;
		}

		// Here you can decide if your minion breaks things like grass or pots
		public override bool? CanCutTiles() {
			return false;
		}
		// This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
		public override bool MinionContactDamage() {
			return true;
		}

		public override void AI() 
        {
			Player player = Main.player[projectile.owner];

			#region Active check
                int num1 = projectile.type == ModContent.ProjectileType<MiniMossHornetProj>() ? 1 : 0;
			// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
			if (!player.active) {
				player.ClearBuff(mod.BuffType("MossHornetBuff"));
			}
			if (player.HasBuff(mod.BuffType("MossHornetBuff"))) {
				projectile.timeLeft = 2;
			}
             if (num1 == 0)
             {
        return;
             }
            player.AddBuff(ModContent.BuffType<MossHornetBuff>(), 18000, true);
			#endregion
                
			#region Animation and visuals
			Lighting.AddLight(projectile.Center, Color.Green.ToVector3() * 0.75f);
			#endregion
		}
	}
}