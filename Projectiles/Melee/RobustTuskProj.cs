using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class RobustTuskProj: ModProjectile
    {
        private int robustTuskPower;
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.aiStyle = 19;
            projectile.timeLeft = 18000;
            projectile.extraUpdates = 0;
            projectile.scale = 1f;
        }
        public float movementFactor
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }
        public override void AI()
        {
            Player projOwner = Main.player[projectile.owner];

            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);

            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    movementFactor = 3f;
                    projectile.netUpdate = true;
                }
                if (projOwner.itemAnimation > projOwner.itemAnimationMax / 2)
                {
                    float bole = 0.2f;
                    // bole /= 2;
                    movementFactor += bole;
                }
                //else 
                //{
                //    movementFactor += 1f;
                //}
            }

            projectile.position += projectile.velocity * movementFactor;

            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }

            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
            ++robustTuskPower;
            if (robustTuskPower > 300)
            {
                robustTuskPower = 300;
            }
            if (Main.mouseRight)
            {
                if (robustTuskPower >= 300)
                {
                    Main.player[projectile.owner].velocity.X += projectile.velocity.X * 1.5f;
                    Main.player[projectile.owner].velocity.Y += projectile.velocity.Y * 1.5f; 
                    Main.PlaySound(SoundID.Item60);
                    robustTuskPower -= 300;
                }
                else
                {
                    //Main.PlaySound(SoundID.Item16);
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            robustTuskPower += damage;
        }
    }
}