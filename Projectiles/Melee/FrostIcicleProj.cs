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

    public class FrostIcicleProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = 19;
            Projectile.timeLeft = 40;
            Projectile.extraUpdates = 0;
            Projectile.scale = 1.1f;
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
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 137,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);

            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    movementFactor = 3f;
                    Projectile.netUpdate = true;
                }
                if (projOwner.itemAnimation > projOwner.itemAnimationMax / 2)
                {
                    float bole = 0.3f;
                    // bole /= 2;
                    movementFactor += bole;
                }
                //else 
                //{
                //    movementFactor += 1f;
                //}
            }
            else
            {
                projOwner.immune = true;
            }

            Projectile.position += Projectile.velocity * movementFactor;

            if (projOwner.itemAnimation == 0)
            {
                Projectile.Kill();
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation -= MathHelper.ToRadians(90f);
            }
            if (Main.myPlayer == Projectile.owner)
            {
                if (Main.player[Projectile.owner].channel)
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
                Projectile.Kill();
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(4))
            {
                target.AddBuff(BuffID.Frostburn, 300);
            }
        }
    }
}