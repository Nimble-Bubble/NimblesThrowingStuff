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
	public class DecayedBloodySyringeProj: ModProjectile
    {
        private bool hasShelled;
        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decayed Bloody Syringe");
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
            Projectile.scale = 1.1f;
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
            if (Main.myPlayer != Projectile.owner)
            {
                Projectile.Kill();
            }
            if (Main.mouseRight && !hasShelled)
            {
                if (NimblesThrowingStuff.MIGuardKey.Current)
                {
                    Projectile.damage = 0;
                    projOwner.GetModPlayer<NimblesPlayer>().currentShells += 3;
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
                        var doTheIchorThing = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ProjectileID.GoldenShowerFriendly, Projectile.damage / 2, 1.5f, Projectile.owner);
                        Main.projectile[doTheIchorThing].DamageType = DamageClass.Melee;
                        SoundEngine.PlaySound(SoundID.Item38);
                        projOwner.velocity.X -= Projectile.velocity.X / 3;
                        projOwner.velocity.Y -= Projectile.velocity.Y / 3;
                        for (int f = 0; f < 20; f++)
                        {
                            int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 170, 0f, 0f, 100, default(Color), 1.5f);
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
            Lighting.AddLight(Projectile.Center, Color.Red.ToVector3() * 0.75f);
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 170, Projectile.velocity.X * 0.375f, Projectile.velocity.Y * 0.375f, 0, default(Color), 0.75f);
            }
        }
    }
}
