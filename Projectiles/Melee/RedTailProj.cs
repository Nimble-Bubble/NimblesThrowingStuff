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
	public class RedTailProj: ModProjectile
    {
        private bool flamesThrown;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Tail");
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
            Projectile.timeLeft = 40;
            Projectile.extraUpdates = 0;
            Projectile.scale = 1.2f;
            flamesThrown = false;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            for (int f = 0; f < 3; f++)
            {
                int fireIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 100, default(Color), 2f);
                Main.dust[fireIndex].velocity *= 6f;
            }
            if (Main.rand.NextBool(4) && !target.buffImmune[BuffID.OnFire])
            {
                for (int f = 0; f < 12; f++)
                {
                    int fireIndex2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 100, default(Color), 3f);
                    Main.dust[fireIndex2].velocity *= 8f;
                }
                SoundEngine.PlaySound(SoundID.Item88);
                target.AddBuff(BuffID.OnFire, 300);
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
            if (Main.mouseRight)
            {
                if (!flamesThrown)
                {
                    int throwFlames = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X / 3, Projectile.velocity.Y / 3, ProjectileID.Flames, Projectile.damage / 2, Projectile.knockBack / 2, Projectile.owner);
                    Main.projectile[throwFlames].DamageType = DamageClass.Melee;
                   SoundEngine.PlaySound(SoundID.Item34);
                    for (int f = 0; f < 12; f++)
                    {
                        int fireIndex3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[fireIndex3].velocity *= 6f;
                    }
                    flamesThrown = true;
                }
            }
        }
    }
}