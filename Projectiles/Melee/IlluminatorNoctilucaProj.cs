using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items;

namespace NimblesThrowingStuff.Projectiles.Melee
{
    public class IlluminatorNoctilucaProj : ModProjectile
    {
        private bool hasShelled;
        private int currentShellsLocal;
        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
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
            Projectile.timeLeft = 18000;
            Projectile.extraUpdates = 0;
            Projectile.scale = 1f;
            Projectile.ownerHitCheck = true;
            hasShelled = false;
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
            Projectile.GetGlobalProjectile<NimblesGlobalProjectile>().maxShells = 25 + projOwner.GetModPlayer<NimblesPlayer>().bonusShells;
            if (projOwner.GetModPlayer<NimblesPlayer>().currentShells > 25)
            {
                Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, Mod.Find<ModGore>("ShellFlying").Type, 1f);
                SoundEngine.PlaySound(SoundID.Item150);
                projOwner.GetModPlayer<NimblesPlayer>().currentShells = 25;
            }

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
            if (Main.mouseRight && !hasShelled)
            {
                if (NimblesThrowingStuff.MIGuardKey.Current)
                {
                    Projectile.damage = 0;
                    projOwner.GetModPlayer<NimblesPlayer>().currentShells += 1;
                    if (projOwner.GetModPlayer<NimblesPlayer>().currentShells <= 0)
                    {
                        projOwner.GetModPlayer<NimblesPlayer>().currentShells = 1;
                    }
                    for (int f = 0; f < 5; f++)
                    {
                        int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 229, 0f, 0f, 100, default(Color), 3f);
                        Main.dust[fireIndex].velocity *= 4f;
                    }
                    SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GunlanceReload"));
                    hasShelled = true;
                }
                else
                {
                    if (projOwner.GetModPlayer<NimblesPlayer>().currentShells >= 20)
                    {
                        if (!hasShelled)
                        {
                            int thelaser = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ProjectileID.PhantasmalDeathray, Projectile.damage * 4 + Projectile.damage / 2, Projectile.knockBack * 2, Projectile.owner);
                        SoundEngine.PlaySound(SoundID.Item11);
                            Main.projectile[thelaser].friendly = true;
                            Main.projectile[thelaser].hostile = false;
                            Main.projectile[thelaser].DamageType = DamageClass.Melee;
                            projOwner.velocity.X -= Projectile.velocity.X / 2;
                        projOwner.velocity.Y -= Projectile.velocity.Y / 2;
                        for (int f = 0; f < 20; f++)
                        {
                            int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 229, 0f, 0f, 100, default(Color), 3f);
                            Main.dust[fireIndex].velocity *= 4f;
                        }
                        
                            projOwner.GetModPlayer<NimblesPlayer>().currentShells -= 20;
                        }
                        hasShelled = true;
                        
                    }
                    else
                    {
                        SoundEngine.PlaySound(SoundID.Item16);
                        hasShelled = true;
                    }
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (crit)
            {
                Main.player[Projectile.owner].GetModPlayer<NimblesPlayer>().currentShells += 2;
            }
        }
    }
}