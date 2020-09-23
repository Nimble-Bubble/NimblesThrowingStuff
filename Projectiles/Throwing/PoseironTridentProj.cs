using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Projectiles.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class PoseironTridentProj: ModProjectile
    {
        private int bub = 0;
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = 10;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 1;
            projectile.extraUpdates = 2;
            projectile.timeLeft = 150;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(209, 300);
            target.AddBuff(44, 450);
        }
        public override void AI()
        {
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 206,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
         bub++;
         if (bub >= 30)
         {
           int ble1 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 20,
                            ModContent.ProjectileType<PoseironBubble>(), projectile.damage / 5, 1f, projectile.owner, 0.0f, (float) 1);
                Main.projectile[ble1].thrown = true;
                Main.projectile[ble1].magic = false;
             int ble2 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 20, 20,
                            ModContent.ProjectileType<PoseironBubble>(), projectile.damage / 5, 1f, projectile.owner, 0.0f, (float) 1);
                Main.projectile[ble2].thrown = true;
                Main.projectile[ble2].magic = false;
             int ble3 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -20, 20,
                            ModContent.ProjectileType<PoseironBubble>(), projectile.damage / 5, 1f, projectile.owner, 0.0f, (float) 1);
                Main.projectile[ble3].thrown = true;
                Main.projectile[ble3].magic = false;
             bub = 0;
         }
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
        }
    }
}