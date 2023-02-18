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
	public class BlueTailProj: ModProjectile
    {
        private int redTailPower;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Tail");
        }
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
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
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (Main.rand.NextBool(4))
            {
                target.AddBuff(BuffID.Frostburn2, 300);
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
                    float bole = 0.45f;
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
            --redTailPower;
            if (redTailPower < 0)
            {
                redTailPower = 0;
            }
            if (Main.mouseRight)
            {
                if (redTailPower == 0)
                {
                    int throwFlames = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X / 3, Projectile.velocity.Y / 3, Mod.Find<ModProjectile>("BlueTailFlames").Type, Projectile.damage / 2, Projectile.knockBack / 2, Projectile.owner);
                   SoundEngine.PlaySound(SoundID.Item34);
                    int throwFlames2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X / 5, Projectile.velocity.Y / 5, Mod.Find<ModProjectile>("BlueTailFlames").Type, Projectile.damage / 2, Projectile.knockBack / 2, Projectile.owner);
                    SoundEngine.PlaySound(SoundID.Item34);
                    Main.projectile[throwFlames2].velocity.RotatedBy(MathHelper.ToRadians(5));
                    int throwFlames3 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X / 5, Projectile.velocity.Y / 5, Mod.Find<ModProjectile>("BlueTailFlames").Type, Projectile.damage / 2, Projectile.knockBack / 2, Projectile.owner);
                    SoundEngine.PlaySound(SoundID.Item34);
                    Main.projectile[throwFlames3].velocity.RotatedBy(MathHelper.ToRadians(-5));
                    redTailPower += 60;
                }
                else
                {
                    //Main.PlaySound(SoundID.Item16);
                }
            }
        }
    }
}