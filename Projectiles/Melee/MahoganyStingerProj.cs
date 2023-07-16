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
	public class MahoganyStingerProj: ModProjectile
    {
        private int zamboni;
        private int mahoganyStingerPower;
        private bool hasLaunched;
        private bool autoPoison;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mahogany Stinger");
        }
        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 28;
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
            hasLaunched = false;
            autoPoison = false;
            zamboni = 1;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (autoPoison)
            {
                target.AddBuff(BuffID.Poisoned, 480);
            }
            else if (Main.rand.NextBool(5))
            {
                target.AddBuff(BuffID.Poisoned, 240);
            }
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
                    float bole = 0.2f;
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
            --mahoganyStingerPower;
            if (mahoganyStingerPower < 0)
            {
                mahoganyStingerPower = 0;
                autoPoison = false;
            }
            if (mahoganyStingerPower >= 20)
            {
                autoPoison = true;
                Main.player[Projectile.owner].immune = true;
            }
            if (Main.mouseRight)
            {
                if (mahoganyStingerPower == 0 && !hasLaunched)
                {
                    for (int sdu = 0; sdu < 20; sdu++)
                    {
                        int doSporeDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 40, Projectile.velocity.RotatedByRandom(MathHelper.ToDegrees(60)).X * -0.5f, Projectile.velocity.RotatedByRandom(MathHelper.ToDegrees(60)).Y * -0.5f, 0, default(Color), 1.25f);
                    }
                    hasLaunched = true;
                    Main.player[Projectile.owner].velocity = Projectile.velocity;
                    SoundEngine.PlaySound(SoundID.Item60);
                    mahoganyStingerPower += 60;
                }
                else
                {
                    //Main.PlaySound(SoundID.Item16);
                }
            }
        }
    }
}