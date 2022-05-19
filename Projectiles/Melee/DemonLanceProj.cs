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
	public class DemonLanceProj: ModProjectile
    {
        public float movementFactor
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.aiStyle = 0;
            projectile.timeLeft = 18000;
            projectile.extraUpdates = 0;
            projectile.scale = 1.1f;
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
                    float bole = 0.1f;
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
            if (Main.myPlayer == projectile.owner)
            {
                if (Main.player[projectile.owner].channel)
                {
                    //float num1 = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].shootSpeed * projectile.scale;
                    //Vector2 vector2_2 = ownerMountedCenter;
                    //float num2 = (float)((float)Main.mouseX + Main.screenPosition.X - vector2_2.X);
                    //float num3 = (float)((float)Main.mouseY + Main.screenPosition.Y - vector2_2.Y);
                    //if ((float)Main.player[projectile.owner].gravDir == -1.0)
                    //    num3 = (float)((float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector2_2.Y);
                    //float num4 = (float)Math.Sqrt((float)num2 * (float)num2 + (float)num3 * (float)num3);
                    //float num5 = (float)Math.Sqrt((float)num2 * (float)num2 + (float)num3 * (float)num3);
                    //float num6 = num1 / num5;
                    // float num7 = num2 * num6;
                    //float num8 = num3 * num6;
                    //if ((float)num7 != projectile.velocity.X || (float)num8 != projectile.velocity.Y)
                    //    projectile.netUpdate = true;
                    //projectile.velocity.X = (float)num7;
                    //projectile.velocity.Y = (float)num8;
                }
            }
            else
            {
                projectile.Kill();
            }
        }
        //public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        //{
            //if (Main.player[projectile.owner].velocity.X < 0)
            //{
            //    damage -= (int)Main.player[projectile.owner].velocity.X;
            //}
            //else
            //{
            //    damage += (int)Main.player[projectile.owner].velocity.X;
            //}
            //if (Main.player[projectile.owner].velocity.Y < 0)
            //{
            //    damage -= (int)Main.player[projectile.owner].velocity.Y;
            //}
            //else
            //{
            //    damage += (int)Main.player[projectile.owner].velocity.Y;
            //}
        //}
    }
}