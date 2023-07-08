using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class MorilusRain : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Oceanus Rain");
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.hostile = true;
            Projectile.maxPenetrate = 10;
            Projectile.light = 1f;
            Projectile.alpha = 0;
            AIType = 27;
            Projectile.scale = 0.5f;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
        }
    }
}
