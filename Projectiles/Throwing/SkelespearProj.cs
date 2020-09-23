using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class SkelespearProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 1;
            projectile.extraUpdates = 1;
            projectile.timeLeft = 150;
        }
        public override void AI()
        {
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 33,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
        public override void Kill(int timeLeft)
        {
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 33,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
                int stream = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y,
                            22, projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                Main.projectile[stream].thrown = true;
                Main.projectile[stream].magic = false;
            Main.projectile[stream].usesLocalNPCImmunity = true;
                Main.projectile[stream].localNPCHitCooldown = 10;
            Main.projectile[stream].penetrate = 5;
        }
    }
}