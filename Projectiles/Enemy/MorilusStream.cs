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
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 12;
            projectile.hostile = true;
            projectile.magic = false;
            projectile.maxPenetrate = 10;
            projectile.light = 1f;
            projectile.alpha = 255;
            aiType = 22;
            projectile.timeLeft = 300;
        }
    }
}
