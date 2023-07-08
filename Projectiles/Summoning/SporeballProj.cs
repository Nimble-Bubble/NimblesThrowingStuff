using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Projectiles.Summoning
{
	public class SporeballProj : ModProjectile
	{
		private int shootSporeCounter;
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Spore Ball");
			Main.projFrames[Projectile.type] = 4;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}

		public sealed override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.tileCollide = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return true;
		}

		public override void AI() {
			++shootSporeCounter;
			Player player = Main.player[Projectile.owner];

			#region Active check
			if (player.dead || !player.active) {
				player.ClearBuff(Mod.Find<ModBuff>("SporeballBuff").Type);
			}
			if (player.HasBuff(Mod.Find<ModBuff>("SporeballBuff").Type)) {
				Projectile.timeLeft = 2;
			}
			#endregion
			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f; 
			float minionPositionOffsetX = (10 + Projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player
			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f) {
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.25f;
				Projectile.netUpdate = true;
			}
			float overlapVelocity = 0.1f;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				Projectile other = Main.projectile[i];
				if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width) {
					if (Projectile.position.X < other.position.X) Projectile.velocity.X -= overlapVelocity;
					else Projectile.velocity.X += overlapVelocity;

					if (Projectile.position.Y < other.position.Y) Projectile.velocity.Y -= overlapVelocity;
					else Projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion
			#region Find target
			float distanceFromTarget = 700f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;
			if (player.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
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
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool closeThroughWall = between < 100f;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			#endregion
			#region Movement
			float speed = 8f;
			float inertia = 20f;
			if (shootSporeCounter > 150)
            {
				for (int m = 0; m < 5; m++)
                {
						Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 44, Projectile.velocity.RotatedByRandom(MathHelper.ToDegrees(90)).X * -0.5f, Projectile.velocity.RotatedByRandom(MathHelper.ToDegrees(90)).Y * -0.5f, 0, default(Color), 0.5f);
				}
				int shootSpore = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, Main.rand.Next(0, 5), ModContent.ProjectileType<SporeballSpore>(), Projectile.damage * (3 / 4), 2f, Projectile.owner);
				Main.projectile[shootSpore].velocity.RotatedByRandom(MathHelper.ToRadians(360));
				shootSporeCounter -= Main.rand.Next(120, 150);
			}
			if (foundTarget) {
				if (distanceFromTarget > 40f) {
					Vector2 direction = targetCenter - Projectile.Center;
					direction.Normalize();
					direction *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else {
				if (distanceToIdlePosition > 600f) {
					speed = 12f;
					inertia = 60f;
				}
				else {
					speed = 4f;
					inertia = 80f;
				}
				if (distanceToIdlePosition > 20f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (Projectile.velocity == Vector2.Zero) {
					Projectile.velocity.X = -0.15f;
					Projectile.velocity.Y = -0.05f;
				}
			}
			#endregion

			#region Animation and visuals
			Projectile.rotation = Projectile.velocity.ToRotation();
			int frameSpeed = 30;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= frameSpeed) {
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}
			Lighting.AddLight(Projectile.Center, Color.Lime.ToVector3() * 0.5f);
			#endregion
            if (Main.rand.NextBool(20))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 44, Projectile.velocity.RotatedByRandom(MathHelper.ToDegrees(120)).X * 0.5f, Projectile.velocity.RotatedByRandom(MathHelper.ToDegrees(120)).Y * 0.5f, 0, default(Color), 0.5f);
            }
		}
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
			for (int m = 0; m < 5; m++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 44, Projectile.velocity.RotatedByRandom(MathHelper.ToDegrees(120)).X, Projectile.velocity.RotatedByRandom(MathHelper.ToDegrees(120)).Y, 0, default(Color), 0.5f);
			}
			target.AddBuff(BuffID.Poisoned, 120);
        }
	}
}