using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class ActualLagoonLanceProj: ModProjectile
    {
        private bool hasWatered;
        private int zamboni;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Laguna Lance");
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = 19;
            Projectile.timeLeft = 20;
            Projectile.extraUpdates = 0;
            Projectile.scale = 1.1f;
            Projectile.ownerHitCheck = true;
            zamboni = 1;
        }
        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public override void AI()
        {
            Player projOwner = Main.player[Projectile.owner];

            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            Projectile.direction = projOwner.direction;
            projOwner.heldProj = Projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            Projectile.timeLeft = projOwner.itemAnimation;
            Projectile.position.X = ownerMountedCenter.X - (float)(Projectile.width / 2);
            Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2);

            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    movementFactor = 3f;
                    Projectile.netUpdate = true;
                }
                if (projOwner.itemAnimation > projOwner.itemAnimationMax / 2)
                {
                    float bole = 0.25f;
                    movementFactor += bole;
                }
            }

            ++zamboni;
            Projectile.position += Projectile.velocity * ((movementFactor * 6) / zamboni);

            if (projOwner.itemAnimation == 0)
            {
                Projectile.Kill();
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation -= MathHelper.ToRadians(90f);
            }
            if (Main.mouseRight && !hasWatered)
            {
                    int neatostream = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, ProjectileID.WaterStream, Projectile.damage / 2, 1.5f, Projectile.owner);
                    Main.projectile[neatostream].DamageType = DamageClass.Melee;
                    Main.projectile[neatostream].usesLocalNPCImmunity = true;
                    Main.projectile[neatostream].localNPCHitCooldown = 10;
                    SoundEngine.PlaySound(SoundID.Item21);
                hasWatered = true;
            }
        }
    }
}