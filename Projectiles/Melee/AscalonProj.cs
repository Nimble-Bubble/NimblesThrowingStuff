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
using NimblesThrowingStuff.Projectiles.Throwing;

namespace NimblesThrowingStuff.Projectiles.Melee
{
    public class AscalonProj : ModProjectile
    {
        private bool hasShelled;
        private int currentShellsLocal;
        private int zamboni;
        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ascalon");
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
            Projectile.scale = 1.2f;
            Projectile.ownerHitCheck = true;
            hasShelled = false;
            zamboni = 1;
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
            Projectile.GetGlobalProjectile<NimblesGlobalProjectile>().maxShells = 5 + projOwner.GetModPlayer<NimblesPlayer>().bonusShells;
            if (projOwner.GetModPlayer<NimblesPlayer>().currentShells > 5)
            {
                Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, Mod.Find<ModGore>("ShellFlying").Type, 1f);
                SoundEngine.PlaySound(SoundID.Item14);
                projOwner.GetModPlayer<NimblesPlayer>().currentShells = 5;
            }

            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    Projectile.netUpdate = true;
                }
                if (projOwner.itemAnimation > projOwner.itemAnimationMax / 2)
                {
                    float bole = 0.35f;
                    movementFactor += bole;
                }
                ++zamboni;
                Projectile.position += Projectile.velocity * ((movementFactor * 6) / zamboni);
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
            if (Main.myPlayer != Projectile.owner)
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
                        int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 72, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[fireIndex].velocity *= 4f;
                    }
                    SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GunlanceReload"));
                    hasShelled = true;
                }
                else
                {
                    if (projOwner.GetModPlayer<NimblesPlayer>().currentShells > 0)
                    {
                        int holylaser = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ProjectileID.PurpleLaser, Projectile.damage / 2 * 3, 1.5f, Projectile.owner);
                        Main.projectile[holylaser].DamageType = DamageClass.Melee;
                           SoundEngine.PlaySound(SoundID.Item33);
                        for (int f = 0; f < 20; f++)
                        {
                            int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 72, 0f, 0f, 100, default(Color), 2f);
                            Main.dust[fireIndex].velocity *= 4f;
                        }
                        hasShelled = true;
                        projOwner.GetModPlayer<NimblesPlayer>().currentShells -= 2;
                    }
                    else
                    {
                        SoundEngine.PlaySound(SoundID.Item16);
                        hasShelled = true;
                    }
                    for (int s = 0; s < 5; s++)
                    {
                        int smokeIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 71, 0f, 0f, 100, default(Color), 1.5f);
                        Main.dust[smokeIndex].velocity *= 1.4f;
                    }
                }
            }
        }
    }
}