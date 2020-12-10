using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class TheToothpickProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Toothpick");
		}

		public override void SetDefaults()
		{
            projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 19;
			projectile.penetrate = -1;
			projectile.scale = 1.3f;
			projectile.alpha = 0;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
        }
		
		public float movementFactor 
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}

		public override void AI() {
			Player projOwner = Main.player[projectile.owner];
            
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			 
			if (!projOwner.frozen) {
				if (movementFactor == 0f)  
				{
					movementFactor = 3f;  
					projectile.netUpdate = true;  
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
				{
					movementFactor -= 2f;
				}
				else // Otherwise, increase the movement factor
				{
					movementFactor += 1f;
				}
			}
			 
			projectile.position += projectile.velocity * movementFactor;
			 
			if (projOwner.itemAnimation == 0) {
				projectile.Kill();
			}
			 
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			 
			if (projectile.spriteDirection == -1) {
				projectile.rotation -= MathHelper.ToRadians(90f);
			}

			 
			if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 14,
					projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
				dust.velocity += projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(4)) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 0,
					0, 0, 254, Scale: 0.3f);
				dust.velocity += projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			}
		}
	}
}