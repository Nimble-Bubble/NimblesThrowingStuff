using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class ProcellariteTridentProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Procellarite Trident");
		}

		public override void SetDefaults()
		{
            Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = 19;
			Projectile.penetrate = -1;
			Projectile.scale = 1.15f;
			Projectile.alpha = 0;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
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
		/* I don't believe this weapon will apply a debuff on hit
		 * public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (Main.rand.NextBool(3))
			{
				target.AddBuff(BuffID.Poisoned, 150);
			}
		} */
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
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
				{
					movementFactor -= 2f;
				}
				else // Otherwise, increase the movement factor
				{
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

			/* Not sure we really need dust, considering that Procellarite is a (somewhat unusual) metal and most ore spears don't have dust
			 * if (!Main.dedServ)
			{
			if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, DustID.JungleSpore,
					Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
				dust.velocity += Projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(4)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, DustID.JungleGrass,
					0, 0, 254, Scale: 0.3f);
				dust.velocity += Projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			} */
			}

		}
	}