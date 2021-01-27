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
            DisplayName.SetDefault("Oceanus Rain");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 1;
            projectile.hostile = true;
            projectile.magic = false;
            projectile.maxPenetrate = 10;
            projectile.light = 1f;
            projectile.alpha = 0;
            aiType = 27;
            projectile.scale = 1.5f;
            projectile.extraUpdates = 1;
            projectile.timeLeft = 300;
            projectile.tileCollide = false;
        }
    }
}
