using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class MorilusBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oceanus Bolt");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 0;
            Projectile.hostile = true;
            Projectile.maxPenetrate = 10;
            Projectile.light = 1f;
            Projectile.alpha = 255;
            Projectile.timeLeft = 200;
            //Projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            //This is pretty much just BlueTailFlames dust code with some numbers changed around to make it a bit less extreme. Sorry for that.
            int dust1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ProcellariteBrightWaterDust>(),
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 100, new Color(), 1f);
            if (Main.rand.Next(3) != 0)
            {
                Main.dust[dust1].noGravity = true;
                Main.dust[dust1].scale *= 2f;
                Dust lungado = Main.dust[dust1];
                lungado.velocity.X = lungado.velocity.X * 1.5f;
                Dust gadolun = Main.dust[dust1];
                gadolun.velocity.Y = gadolun.velocity.Y * 1.5f;
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
            //Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ProcellariteWaterDust>(), Main.rand.Next(-3, 2), Main.rand.Next(-3, 2), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
    }
}
