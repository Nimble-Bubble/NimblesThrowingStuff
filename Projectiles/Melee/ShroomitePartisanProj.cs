using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class ShroomitePartisanProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Shroomite Partisan");
		}
		private bool hasSpored;
		public override void SetDefaults()
		{
            Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = 19;
			Projectile.penetrate = -1;
			Projectile.scale = 1f;
			Projectile.alpha = 0;

			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
        }
		
		public float movementFactor 
		{
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		public override void AI() {
			Player projOwner = Main.player[Projectile.owner];
            
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			Projectile.direction = projOwner.direction;
			projOwner.heldProj = Projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			Projectile.position.X = ownerMountedCenter.X - (float)(Projectile.width / 2);
			Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2);
			 
			if (!projOwner.frozen) {
				if (movementFactor == 0f)  
				{
					movementFactor = 3f;  
					Projectile.netUpdate = true;  
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) 
				{
					movementFactor -= 2f;
			}
				else 
				{
					if (!hasSpored)
					{
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity,
									   ModContent.ProjectileType<ShroomiteSporeCloud>(), Projectile.damage, 3f, Projectile.owner, 0.0f, (float)1);
						hasSpored = true;
					}
					movementFactor += 1f;
				}
			}
			 
			Projectile.position += Projectile.velocity * movementFactor;
			 
			if (projOwner.itemAnimation == 0) {
				Projectile.Kill();
			}
			 
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			 
			if (Projectile.spriteDirection == -1) {
				Projectile.rotation -= MathHelper.ToRadians(90f);
			}

			 if (!Main.dedServ)
			{
			if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 41,
					Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
				dust.velocity += Projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			}

		}
	}
}