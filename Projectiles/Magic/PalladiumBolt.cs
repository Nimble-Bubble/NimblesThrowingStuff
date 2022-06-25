using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Magic
{
    public class PalladiumBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.aiStyle = 0;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.maxPenetrate = 1;
            Projectile.light = 0.5f;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Projectile.velocity.X *= 1.02f;
            Projectile.velocity.Y *= 1.02f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 144, (float)Projectile.velocity.X / 5, (float)Projectile.velocity.Y  / 5, 0, default(Color), 0.75f);
            }
        }
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 144,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}
