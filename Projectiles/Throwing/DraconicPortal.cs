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
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.maxPenetrate = -1;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.tileCollide = false;
            Projectile.aiStyle = 0;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 0;
            Projectile.timeLeft = 99;
            Projectile.light = 0.5f;
        }
        public override void AI() 
        {
        Projectile.rotation += 0.1f;
        Projectile.alpha += 3;
            ++index;
                    if (index > 20)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 11) * 1f;
                        int spore = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, vector2.X, vector2.Y,
                            Mod.Find<ModProjectile>("DragonShrapnel").Type, Projectile.damage / 2, 1f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                        index = 0;
                    }
        }
    }
}