using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace NimblesThrowingStuff.Projectiles.Magic
{
    public class GlidingBlazeProj : ModProjectile
    {
        private float GlidingBlazeMultiplier;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gliding Blaze");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 29;
            Projectile.friendly = true;
            Projectile.maxPenetrate = 1;
            Projectile.light = 1f;
            Projectile.timeLeft = 300;
            Projectile.DamageType = DamageClass.Magic;
        }
        public override void AI()
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 1f);
            GlidingBlazeMultiplier += 0.5f;
            if (GlidingBlazeMultiplier > 10)
            {
                GlidingBlazeMultiplier -= 0.25f;
            }
            Projectile.rotation += MathHelper.ToRadians(18 + GlidingBlazeMultiplier * 2);
            Projectile.velocity *= new Vector2((GlidingBlazeMultiplier + 90) / 100, (GlidingBlazeMultiplier + 90) / 100);
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14);
            for (int kfd = 0; kfd < 15; kfd++)
            {
                int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[fireIndex].velocity *= 3f;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            damageDone += (int)(GlidingBlazeMultiplier / 2);
            for (int fd = 0; fd < 10; fd++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 0, new Color(), 0.75f);
            }
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
}
