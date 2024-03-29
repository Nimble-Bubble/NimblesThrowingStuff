using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class AquarianLeisterProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Aquarian Leister");
		}
		private bool hasBubbled;
		public override void SetDefaults()
		{
            Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = 19;
			Projectile.penetrate = -1;
			Projectile.scale = 1.25f;
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
					if (!hasBubbled)
					{
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(20)),
										 405, Projectile.damage / 4, 0.5f, Projectile.owner, 0.0f, (float)1);
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity,
									   405, Projectile.damage / 2, 0.5f, Projectile.owner, 0.0f, (float)1);
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(340)),
									   405, Projectile.damage / 4, 0.5f, Projectile.owner, 0.0f, (float)1);
						hasBubbled = true;
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
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 33,
					Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
				dust.velocity += Projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(4)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 33,
					0, 0, 254, Scale: 0.3f);
				dust.velocity += Projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			}
			}

		}
	}
}