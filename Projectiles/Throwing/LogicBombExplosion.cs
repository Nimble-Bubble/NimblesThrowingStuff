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
	public class LogicBombExplosion: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Logicsplosion");
        }
        public override void SetDefaults()
        {
            Projectile.width = 100;
            Projectile.height = 100;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = 9999;
            Projectile.friendly = true;
            Projectile.timeLeft = 1;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.light = 0.5f;
            Projectile.aiStyle = 1;
            Projectile.alpha = 255;
        }
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(31, 750);
        }
    }
}