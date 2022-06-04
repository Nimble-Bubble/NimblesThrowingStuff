using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class MorilusStream : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oceanus Stream");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 12;
            Projectile.hostile = true;
            Projectile.magic = false;
            Projectile.maxPenetrate = 10;
            Projectile.light = 1f;
            Projectile.alpha = 255;
            AIType = 22;
            Projectile.timeLeft = 300;
        }
    }
}
