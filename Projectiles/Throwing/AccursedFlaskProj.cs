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
	public class AccursedFlaskProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 2;
            projectile.extraUpdates = 0;
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(SoundID.Item107, projectile.position);
                Gore.NewGore(projectile.Center, -projectile.oldVelocity * 0.2f, 704, 1f);
                Gore.NewGore(projectile.Center, -projectile.oldVelocity * 0.2f, 705, 1f);
                if (projectile.owner == Main.myPlayer)
                {
                    var num = Main.rand.Next(20, 31);
                    for (var index = 0; index < num; ++index)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 201) * 0.01f;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X, vector2.Y,
                            mod.ProjectileType("CursedCloud1"), projectile.damage / 5, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                    }
                }
        }
    }
}