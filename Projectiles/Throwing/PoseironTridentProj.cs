using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Projectiles.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class PoseironTridentProj: ModProjectile
    {
        private int bub = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poseiron's Trident");
        }
        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 38;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 2;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 150;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(209, 300);
            target.AddBuff(44, 450);
        }
        public override void AI()
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 206,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
         bub++;
         if (bub >= 45)
         {
           int ble1 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(170)),
                            ModContent.ProjectileType<PoseironBubble>(), Projectile.damage / 3, 0.5f, Projectile.owner, 0.0f, (float) 1);
                Main.projectile[ble1].DamageType = DamageClass.Throwing;
             int ble2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(180)),
                            ModContent.ProjectileType<PoseironBubble>(), Projectile.damage / 3, 0.5f, Projectile.owner, 0.0f, (float) 1);
                Main.projectile[ble2].DamageType = DamageClass.Throwing;
             int ble3 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(190)),
                            ModContent.ProjectileType<PoseironBubble>(), Projectile.damage / 3, 0.5f, Projectile.owner, 0.0f, (float) 1);
                Main.projectile[ble3].DamageType = DamageClass.Throwing;
             bub = 0;
         }
        }
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }
    }
}