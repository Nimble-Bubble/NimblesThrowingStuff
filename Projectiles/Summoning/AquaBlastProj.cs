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
			DisplayName.SetDefault("Aqua Blaster");
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
		}
        private int aquablastcd; 

		public sealed override void SetDefaults() {
			projectile.width = 28;
			projectile.height = 28;
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
			// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
			if (player.dead || !player.active) {
				player.ClearBuff(ModContent.BuffType<AquaBlastBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<AquaBlastBuff>())) {
				projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f; // Go up 48 coordinates (three tiles from the center of the player)

			// If your minion doesn't aimlessly move around when it's idle, you need to "put" it into the line of other summoned minions
			// The index is projectile.minionPos
			float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player

			// All of this code below this line is adapted from Spazmamini code (ID 388, aiStyle 66)

			// Teleport to player if distance is too big
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f) {
				// Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
				// and then set netUpdate to true
				projectile.position = idlePosition;
				projectile.velocity *= 0.25f;
				projectile.netUpdate = true;
			}

			// If your minion is flying, you want to do this independently of any conditions
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
			// Starting search distance
			float distanceFromTarget = 700f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

			// This code is required if your minion weapon has the targeting feature
			if (player.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				// Reasonable distance away so it doesn't target across multiple screens
				if (between < 2000f) {
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget) {
				// This code is required either way, used for finding a target
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						// Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
						// The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}

			// friendly needs to be set to true so the minion can deal contact damage
			// friendly needs to be set to false so it doesn't damage things like target dummies while idling
			// Both things depend on if it has a target or not, so it's just one assignment here
			// You don't need this assignment if your minion is shooting things instead of dealing contact damage
			projectile.friendly = foundTarget;
			#endregion
            
			#region Movement

			float speed = 10f;
			float inertia = 5f;
			if (foundTarget) {
            aquablastcd += 1;
            if (aquablastcd >= 40)
                {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("AquaBlast"), projectile.damage, 3f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                aquablastcd = 0;
                }
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
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (projectile.velocity == Vector2.Zero) {
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
//aqua blasters fire water bolts, why would they need to fly towards the enemy
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
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (projectile.velocity == Vector2.Zero) {
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
			}
			#endregion
            
            //#region Water Gun
            //if (foundTarget) {
				//aquablastcd += 1;
                //if (aquablastcd >= 40)
                //{
                //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0,
                            //27, projectile.damage, 3f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                //aquablastcd = 0;
                //}
			//}
			//else {
            //aquablastcd = 0;
            //}
            //#endregion

			#region Animation and visuals
            projectile.rotation += 0.1f;
			Lighting.AddLight(projectile.Center, Color.Blue.ToVector3() * 0.5f);
			#endregion
		}
        //public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		//{
			//Texture2D texture = mod.GetTexture("Projectiles/Throwing/AquaBlastProj_Glow");
			//spriteBatch.Draw
			//(
				//texture,
				//projectile.position,
				//new Rectangle(0, 0, texture.Width, texture.Height),
				//Color.Blue,
				//projectile.rotation,
				//texture.Size() * 0.5f,
				//projectile.scale,
				//SpriteEffects.None,
				//0f
			//);
		//}
	}
}