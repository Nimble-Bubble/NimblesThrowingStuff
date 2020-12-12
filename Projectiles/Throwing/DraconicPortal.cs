using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class DraconicPortal: ModProjectile
    {
        private int index = 0; 
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.maxPenetrate = -1;
            projectile.thrown = true;
            projectile.tileCollide = false;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.extraUpdates = 0;
            projectile.timeLeft = 99;
            projectile.light = 0.5f;
        }
        public override void AI() 
        {
        projectile.rotation += 0.1f;
        projectile.alpha += 3;
            ++index;
                    if (index > 20)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 11) * 1f;
                        int spore = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X, vector2.Y,
                            mod.ProjectileType("DragonShrapnel"), projectile.damage / 2, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                        index = 0;
                    }
        }
    }
}