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
            projectile.width = 100;
            projectile.height = 100;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 20;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.aiStyle = 0;
            projectile.timeLeft = 18000;
            projectile.extraUpdates = 0;
            projectile.scale = 1f;
        }
        public override void AI()
        {
            Vector2 vector2_1 = Main.player[projectile.owner].RotatedRelativePoint(Main.player[projectile.owner].MountedCenter, true);
            if (Main.myPlayer == projectile.owner)
            {
                if (Main.player[projectile.owner].channel)
                {
                    float num1 = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].shootSpeed * projectile.scale;
                    Vector2 vector2_2 = vector2_1;
                    float num2 = (float)((float)Main.mouseX + Main.screenPosition.X - vector2_2.X);
                    float num3 = (float)((float)Main.mouseY + Main.screenPosition.Y - vector2_2.Y);
                    if ((float)Main.player[projectile.owner].gravDir == -1.0)
                        num3 = (float)((float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector2_2.Y);
                    float num4 = (float)Math.Sqrt((float)num2 * (float)num2 + (float)num3 * (float)num3);
                    float num5 = (float)Math.Sqrt((float)num2 * (float)num2 + (float)num3 * (float)num3);
                    float num6 = num1 / num5;
                    float num7 = num2 * num6;
                    float num8 = num3 * num6;
                    if ((float)num7 != projectile.velocity.X || (float)num8 != projectile.velocity.Y)
                        projectile.netUpdate = true;
                    projectile.velocity.X = (float)num7;
                    projectile.velocity.Y = (float)num8;
                }
                else
                    projectile.Kill();
            }
            if (projectile.velocity.X > 0.0)
                Main.player[projectile.owner].ChangeDir(1);
            else if (projectile.velocity.X < 0.0)
                Main.player[projectile.owner].ChangeDir(-1);
            projectile.spriteDirection = projectile.direction;
            Main.player[projectile.owner].ChangeDir(projectile.direction);
            Main.player[projectile.owner].heldProj = projectile.whoAmI;
            Main.player[projectile.owner].itemTime = 2;
            Main.player[projectile.owner].itemAnimation = 2;
            projectile.position.X = (vector2_1.X - 50);
            projectile.position.Y = (vector2_1.Y - 50);
            //projectile.position = projectile.Center;
            //projectile.width = projectile.height = 64;
            projectile.rotation = (float)(Math.Atan2((float)projectile.velocity.Y, (float)projectile.velocity.X) + 1.57000005245209);
            Main.player[projectile.owner].itemRotation = Main.player[projectile.owner].direction != 1 ? (float)Math.Atan2(projectile.velocity.Y * (float)projectile.direction, projectile.velocity.X * (float)projectile.direction) : (float)Math.Atan2(projectile.velocity.Y * (float)projectile.direction, projectile.velocity.X * (float)projectile.direction);
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