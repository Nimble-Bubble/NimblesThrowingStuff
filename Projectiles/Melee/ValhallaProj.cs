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
	public class ValhallaProj: ModProjectile
    {
        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Valhalla");
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = 19;
            Projectile.timeLeft = 18000;
            Projectile.extraUpdates = 0;
            Projectile.scale = 1f;
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
                    int dust1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 68,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 100, new Color(), 1f);
                    if (Main.rand.Next(3) != 0)
                    {
                        Main.dust[dust1].noGravity = true;
                        Main.dust[dust1].scale *= 2f;
                        Dust lungado = Main.dust[dust1];
                        lungado.velocity.X = lungado.velocity.X * 2f;
                        Dust gadolun = Main.dust[dust1];
                        gadolun.velocity.Y = gadolun.velocity.Y * 2f;
                    }
                    else
                    {
                        Main.dust[dust1].scale *= 1.25f;
                    }
                    if (Main.rand.NextBool(4))
                    {
                        int dust2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 69,
                                    0f, 0f, 0, new Color(), 1f);
                        Main.dust[dust2].noGravity = true;
                        Main.dust[dust2].velocity *= 0.5f;
                        Main.dust[dust2].scale *= 0.9f;
                    }
                    float bole = 0.3f;
                    movementFactor += bole;
                }
            }

            Projectile.position += Projectile.velocity * movementFactor;
            int dust5 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 69,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 100, new Color(), 1f);
            if (Main.rand.Next(3) != 0)
            {
                Main.dust[dust5].noGravity = true;
                Main.dust[dust5].scale *= 2f;
                Dust lungadi = Main.dust[dust5];
                lungadi.velocity.X = lungadi.velocity.X * 2f;
                Dust gadilun = Main.dust[dust5];
                gadilun.velocity.Y = gadilun.velocity.Y * 2f;
            }
            else
            {
                Main.dust[dust5].scale *= 1.25f;
            }
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
            target.AddBuff(344, 300);
            target.AddBuff(BuffID.Bleeding, 600);
            if (crit)
            {
                knockback *= 10;
            }
        }
    }
}