using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class WhirlpoolWhammerProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Whirlpool Whammer");
        }
        public override void SetDefaults()
        {
            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.tileCollide = true;
            Projectile.maxPenetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 3;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 0;
        }
        public override void AI()
        {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width / 2, Projectile.height / 2, 226, 0f, 0f, 100, default(Color), 0.5f);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int il = 0; il < 10; il++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 226, 0f, 0f, 100, default(Color), 0.5f);
            }
            if (Main.rand.NextBool(3))
            {
                for (int il = 0; il < 15; il++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width * 2, Projectile.height * 2, 226, 0f, 0f, 100, default(Color), 1f);
            }
                SoundEngine.PlaySound(SoundID.DD2_LightningBugZap);
                target.AddBuff(BuffID.Electrified, 150);
            }
        }
    }
}