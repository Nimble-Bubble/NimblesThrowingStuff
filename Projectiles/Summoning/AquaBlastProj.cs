using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Buffs;

namespace NimblesThrowingStuff.Projectiles.Summoning
{
	public class AquaBlastProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Aqua Blaster");
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}
        private int aquablastcd; 

		public sealed override void SetDefaults() {
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return false;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];

			#region Active check
			if (player.dead || !player.active) {
				player.ClearBuff(ModContent.BuffType<AquaBlastBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<AquaBlastBuff>())) {
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f; 
			float minionPositionOffsetX = (10 + Projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX; 
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
			Projectile.friendly = foundTarget;
			#endregion
            
			#region Movement

			float speed = 10f;
			float inertia = 5f;
			if (foundTarget) {
				//aquablastcd += 1;
				//if (aquablastcd >= 40)
				//    {
				//    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, Mod.Find<ModProjectile>("AquaBlast").Type, Projectile.damage, 3f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
				//    aquablastcd = 0;
				//    }
				if (distanceToIdlePosition > 600f) {
					speed = 12f;
					inertia = 6f;
				}
				else {
					speed = 4f;
					inertia = 8f;
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
			else {
            aquablastcd = 0;
				if (distanceToIdlePosition > 600f) {
					speed = 12f;
					inertia = 6f;
				}
				else {
					speed = 4f;
					inertia = 8f;
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
            
            #region Water Gun
            if (foundTarget) {
				aquablastcd += 1;
                if (aquablastcd >= 40)
                {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, 27, Projectile.damage, 3f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                aquablastcd = 0;
                }
			}
			else {
            aquablastcd = 0;
            }
            #endregion

			#region Animation and visuals
            Projectile.rotation += 0.1f;
			Lighting.AddLight(Projectile.Center, Color.Blue.ToVector3() * 0.5f);
			#endregion
		}
       public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Throwing/AquaBlastProj_Glow").Value;
			Main.EntitySpriteDraw
			(
				texture,
				Projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Blue,
				Projectile.rotation,
				texture.Size() * 0.5f,
				Projectile.scale,
				SpriteEffects.None,
				0
			);
		}
	}
}