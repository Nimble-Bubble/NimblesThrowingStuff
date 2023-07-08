using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class RathFireball : ModProjectile
    {
        /* public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("a wee rathwyvern's fireball");
        } */

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 8;
            Projectile.hostile = true;
            Projectile.maxPenetrate = 2;
            Projectile.light = 1f;
            Projectile.timeLeft = 300;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
}
