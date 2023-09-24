using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class FireballBrewProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fireball Brew");
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 34;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 2;
            Projectile.penetrate = 1;
        }
        public override void AI()
        {
            var vector2 = new Vector2(20f, 20f);
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            Lighting.AddLight(Projectile.Center, Color.Orange.ToVector3() * 0.5f);
        }
        public override void OnKill(int timeLeft) 
        {
            for (int f = 0; f < 30; f++)
            {
                int KindarathDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width * 2, Projectile.height * 2, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[KindarathDust].velocity *= 2f;
            }
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
                var vector2 = new Vector2(20f, 20f);
                for (int index = 0; index < 5; ++index)
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6,
                        Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            for (int index1 = 0; index1 < 10; ++index1)
                {
                    int index2 = Dust.NewDust(Projectile.Center - vector2 / 2f, (int) vector2.X, (int) vector2.Y, 31, 0.0f,
                        0.0f, 100, new Color(), 1.5f);
                    Main.dust[index2].velocity *= 1.4f;
                }

                for (int index1 = 0; index1 < 20; ++index1)
                {
                    int index2 = Dust.NewDust(Projectile.Center - vector2 / 2f, (int) vector2.X, (int) vector2.Y, 102, 0.0f,
                        0.0f, 100, new Color(), 2.5f);
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].velocity *= 5f;
                    int index3 = Dust.NewDust(Projectile.Center - vector2 / 2f, (int) vector2.X, (int) vector2.Y, 102, 0.0f,
                        0.0f, 100, new Color(), 1.5f);
                    Main.dust[index3].velocity *= 3f;
                }

                if (Main.myPlayer == Projectile.owner)
                {
                    int type = Main.rand.Next(400, 403);
                    for (int index = 0; index < 6; ++index)
                    {
                        var SpeedX =
                            (float) (-(double) Projectile.velocity.X * (double) Main.rand.Next(20, 50) * 0.00999999977648258 +
                                     (double) Main.rand.Next(-20, 21) * 0.400000005960464);
                        var SpeedY =
                            (float) (-(double) Math.Abs(Projectile.velocity.Y) * (double) Main.rand.Next(30, 50) *
                                     0.00999999977648258 + (double) Main.rand.Next(-20, 5) * 0.400000005960464);
                        int dothething = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + SpeedX, Projectile.Center.Y + SpeedY, SpeedX, SpeedY,
                            type, (int) ((double) Projectile.damage * 0.5), 0.0f, Projectile.owner, 0.0f, 0.0f);
                    Main.projectile[dothething].DamageType = DamageClass.Throwing;
                }
                }
            }
    }
}