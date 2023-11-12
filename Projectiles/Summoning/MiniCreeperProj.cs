using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Projectiles.Summoning
{
	public class MiniCreeperProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public sealed override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 40;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
		}
		public override bool? CanCutTiles() {
			return true;
		}
		public override bool MinionContactDamage() {
			return true;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];

			#region Active check
			if (player.dead || !player.active) {
				player.ClearBuff(Mod.Find<ModBuff>("MiniCreeperBuff").Type);
			}
			if (player.HasBuff(Mod.Find<ModBuff>("MiniCreeperBuff").Type)) {
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 24f;
			float minionPositionOffsetX = (10 + Projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX;
			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 1000f) {
				SoundEngine.PlaySound(SoundID.NPCDeath13, Projectile.position);
				for (int z = 0; z < 10; z++)
				{
                    Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 5, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
                }
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.25f;
				Projectile.netUpdate = true;
				Projectile.ai[0] = 0f;
				for (int zedilla = 0; zedilla < 10; zedilla++)
				{
                    Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 5, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
                }
                SoundEngine.PlaySound(SoundID.NPCDeath13, Projectile.position);
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
			float distanceFromTarget = 1900f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;
			if (player.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 5000f) {
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
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			Projectile.friendly = true;
			#endregion

			#region Movement
			if (Projectile.ai[0] == 0f)
			{
				Vector2 vector107 = new Vector2(Projectile.Center.X, Projectile.Center.Y);
				float num862 = player.Center.X - vector107.X;
				float num863 = player.Center.Y - vector107.Y;
				float num864 = (float)Math.Sqrt((double)(num862 * num862 + num863 * num863));
				if (num864 > 90f)
				{
					num864 = 8f / num864;
					num862 *= num864;
					num863 *= num864;
					Projectile.velocity.X = (Projectile.velocity.X * 15f + num862) / 16f;
					Projectile.velocity.Y = (Projectile.velocity.Y * 15f + num863) / 16f;
					return;
				}
				if (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) < 8f)
				{
					Projectile.velocity.Y = Projectile.velocity.Y * 1.05f;
					Projectile.velocity.X = Projectile.velocity.X * 1.05f;
				}
				if (Main.rand.NextBool(200) && foundTarget)
				{
					vector107 = new Vector2(Projectile.Center.X, Projectile.Center.Y);
					num862 = targetCenter.X - vector107.X;
					num863 = targetCenter.Y - vector107.Y;
					num864 = (float)Math.Sqrt((double)(num862 * num862 + num863 * num863));
					num864 = 8f / num864;
					Projectile.velocity.X = num862 * num864;
					Projectile.velocity.Y = num863 * num864;
					Projectile.ai[0] = 1f;
					Projectile.netUpdate = true;
				}
			}
			else
			{
				float num865 = player.Center.X - Projectile.Center.X;
				float num866 = player.Center.Y - Projectile.Center.Y;
				float num867 = (float)Math.Sqrt((double)(num865 * num865 + num866 * num866));
			}
                    /*float speed = 12f;
                    float inertia = 20f;

                    if (foundTarget) {
                        if (distanceFromTarget > 100f) {
                            Vector2 direction = targetCenter - Projectile.Center;
                            direction.Normalize();
                            direction *= speed;
                            Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
                        }
                    }
                    else {
                        if (distanceToIdlePosition > 100f) {
                            speed = 18f;
                            inertia = 60f;
                        }
                        else {
                            speed = 8f;
                            inertia = 80f;
                        }
                        if (distanceToIdlePosition > 20f) {
                            vectorToIdlePosition.Normalize();
                            vectorToIdlePosition *= speed;
                            Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
                        }
                        else if (Projectile.velocity == Vector2.Zero) {
                            Projectile.velocity.X = -0.3f;
                            Projectile.velocity.Y = -0.1f;
                        }
                    } */
                    #endregion

                    #region Animation and visuals
                    Projectile.rotation = Projectile.velocity.ToRotation();
			Lighting.AddLight(Projectile.Center, Color.DarkRed.ToVector3() * 1f);
			#endregion
		}
	}
}