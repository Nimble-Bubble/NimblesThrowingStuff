using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Projectiles.Summoning
{
	public class MythrilTackShooterProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mythril Tack Shooter");
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
		}
        private int mythriltackcd;

		public sealed override void SetDefaults() {
			projectile.width = 40;
			projectile.height = 40;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return false;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];

			#region Active check

			if (player.dead || !player.active) {
				player.ClearBuff(mod.BuffType("MythrilTackShooterBuff"));
			}
			if (player.HasBuff(mod.BuffType("MythrilTackShooterBuff"))) {
				projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f; 
			float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX; 
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f) {
				projectile.position = idlePosition;
				projectile.velocity *= 0.25f;
				projectile.netUpdate = true;
			}
			float overlapVelocity = 0.1f;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				// Fix overlap with other minions
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width) {
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;

					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			float distanceFromTarget = 700f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;
			if (player.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				if (between < 2000f) {
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}

			projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 0.1f;
			float inertia = 5f;

			if (foundTarget) {
				mythriltackcd += 1;
                if (mythriltackcd >= 60)
                {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -20,
                            mod.ProjectileType("MythrilTack"), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 20, -20,
                            mod.ProjectileType("MythrilTack"), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 20, 0,
                            mod.ProjectileType("MythrilTack"), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 20, 20,
                            mod.ProjectileType("MythrilTack"), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 20,
                            mod.ProjectileType("MythrilTack"), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -20, 20,
                            mod.ProjectileType("MythrilTack"), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -20, 0,
                            mod.ProjectileType("MythrilTack"), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -20, -20,
                            mod.ProjectileType("MythrilTack"), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                mythriltackcd = 0;
                }
			}
			else {
            mythriltackcd = 0;
				// Minion doesn't have a target: return to player and idle
				if (distanceToIdlePosition > 600f) {
					// Speed up the minion if it's away from the player
					speed = 100f;
					inertia = 5f;
				}
				else {
					// Slow down the minion if closer to the player
					speed = 0.05f;
					inertia = 5f;
				}
				if (distanceToIdlePosition > 20f) {
					// The immediate range around the player (when it passively floats about)

					// This is a simple movement formula using the two parameters and its desired direction to create a "homing" movement
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (projectile.velocity == Vector2.Zero) {
					// If there is a case where it's not moving at all, give it a little "poke"
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
			}
			#endregion

			#region Animation and visuals
			Lighting.AddLight(projectile.Center, Color.SeaGreen.ToVector3() * 0.5f);
			#endregion
		}
	}
}