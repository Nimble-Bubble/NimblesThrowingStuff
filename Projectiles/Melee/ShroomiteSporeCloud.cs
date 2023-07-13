using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Melee
{
    public class ShroomiteSporeCloud : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = 29;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
            Projectile.penetrate = 200;
            Projectile.maxPenetrate = 200;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.alpha = 0;
            Projectile.timeLeft = 255;
        }
        public override void AI()
        {
            Projectile.rotation += 0.05f * (float)Projectile.direction;
            Projectile.alpha++;
            Projectile.scale *= 0.98f;
            Projectile.velocity.X *= 0.98f;
            Projectile.velocity.Y *= 0.98f;
            int frameSpeed = 20;
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }
        }
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
			if (hit.Crit)
            {
                if (damageDone < 50)
                {
                    damageDone = 50;
                }
                Main.player[Projectile.owner].HealEffect(damageDone / 50);
                Main.player[Projectile.owner].statLife += damageDone / 50;
            }
        }
    }
}
