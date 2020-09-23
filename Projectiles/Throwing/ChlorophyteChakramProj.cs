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
	public class ChlorophyteChakramProj: ModProjectile
    {
        private int index = 0; 
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.maxPenetrate = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 3;
            projectile.penetrate = -1;
            projectile.extraUpdates = 2;
        }
        public override void AI() 
        {
            ++index;
                    if (index > 30)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 11) * 1f;
                        int spore = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X, vector2.Y,
                            228, projectile.damage / 2, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                        index = 0;
                        Main.projectile[spore].thrown = true;
                Main.projectile[spore].melee = false;
                    }
        }
    }
}