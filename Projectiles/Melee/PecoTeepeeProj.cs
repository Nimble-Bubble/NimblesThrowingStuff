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
    public class PecoTeepeeProj : ModProjectile
    {
        private int zamboni;
        private bool hasShelled;
        private int currentShellsLocal;
        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Peco Teepee");
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
                SoundEngine.PlaySound(SoundID.Item42);
                projOwner.GetModPlayer<NimblesPlayer>().currentShells = 5;
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
            if (Main.myPlayer != Projectile.owner)
            {
                Projectile.Kill();
            }
            if (Main.mouseRight && !hasShelled)
            {
                if (NimblesThrowingStuff.MIGuardKey.Current)
                {
                    Projectile.damage = 0;
                    projOwner.GetModPlayer<NimblesPlayer>().currentShells += 5;
                    if (projOwner.GetModPlayer<NimblesPlayer>().currentShells <= 0)
                    {
                        projOwner.GetModPlayer<NimblesPlayer>().currentShells = 1;
                    }
                    for (int f = 0; f < 5; f++)
                    {
                        int smokeIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[smokeIndex].velocity *= 1.4f;
                    }
                    SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GunlanceReload"));
                    hasShelled = true;
                }
                else
                {
                    if (projOwner.GetModPlayer<NimblesPlayer>().currentShells > 0)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<PecoTeepeeShell>(), Projectile.damage / 3, 5f, Projectile.owner);
                        SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GunlanceShellPeco"));
                        projOwner.velocity.X -= Projectile.velocity.X / 5;
                        projOwner.velocity.Y -= Projectile.velocity.Y / 5;
                        for (int f = 0; f < 20; f++)
                        {
                            int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
                            Main.dust[fireIndex].velocity *= 6f;
                        }
                        for (int s = 0; s < 5; s++)
                        {
                            int smokeIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
                            Main.dust[smokeIndex].velocity *= 2f;
                        }
                        hasShelled = true;
                        projOwner.GetModPlayer<NimblesPlayer>().currentShells -= 1;
                    }
                    else
                    {
                        SoundEngine.PlaySound(SoundID.Item16);
                        hasShelled = true;
                    }
                    for (int s = 0; s < 5; s++)
                    {
                        int smokeIndex2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[smokeIndex2].velocity *= 1.4f;
                    }
                }
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hit.Crit)
            {
                for (int fi = 0; fi < 10; fi++)
                {
                    int fireIndex2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
                }
                target.AddBuff(BuffID.OnFire, 120);
            }
        }
    }
}