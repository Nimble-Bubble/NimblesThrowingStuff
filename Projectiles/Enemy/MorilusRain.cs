using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Dusts;

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
            Projectile.extraUpdates = 0;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            int dust1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ProcellariteBrightWaterDust>(),
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 100, new Color(), 1f);
            if (!Main.rand.NextBool(3))
            {
                Main.dust[dust1].noGravity = true;
                Main.dust[dust1].scale *= 2f;
                Dust lungado = Main.dust[dust1];
                lungado.velocity.X *= 1.5f;
                Dust gadolun = Main.dust[dust1];
                gadolun.velocity.Y *= 1.5f;
            }
            else
            {
                Main.dust[dust1].scale *= 1.25f;
            }
            if (Main.rand.NextBool(4))
            {
                int dust2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ProcellariteWaterDust>(),
                            0f, 0f, 0, new Color(), 1f);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity *= 0.5f;
                Main.dust[dust2].scale *= 0.9f;
            }
            Projectile.rotation += 10;
            Projectile.velocity.X *= 0.975f;
            Projectile.velocity.Y *= 1.025f;
        }
    }
}
