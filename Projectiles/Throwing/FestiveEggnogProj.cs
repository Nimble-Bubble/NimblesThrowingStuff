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
	public class FestiveEggnogProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 68;
            projectile.penetrate = 1;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Frostburn, 240);
        }
        public override void AI()
        {
            var vector2 = new Vector2(20f, 20f);
            Dust.NewDust(projectile.Center - vector2 / 2f, (int) vector2.X, (int) vector2.Y, 102, 0.0f, 0.0f, 0,
                        Color.Tan, 1f);
            Lighting.AddLight(projectile.Center, Color.Tan.ToVector3() * 0.5f);
        }
        public override void Kill(int timeLeft) 
        {
                Main.PlaySound(13, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
                var vector2 = new Vector2(20f, 20f);
                for (int index = 0; index < 5; ++index)
                    Dust.NewDust(projectile.Center - vector2 / 2f, (int) vector2.X, (int) vector2.Y, 102, 0.0f, 0.0f, 0,
                        Color.Tan, 1f);
                for (int index1 = 0; index1 < 10; ++index1)
                {
                    int index2 = Dust.NewDust(projectile.Center - vector2 / 2f, (int) vector2.X, (int) vector2.Y, 31, 0.0f,
                        0.0f, 100, new Color(), 1.5f);
                    Main.dust[index2].velocity *= 1.4f;
                }

                for (int index1 = 0; index1 < 20; ++index1)
                {
                    int index2 = Dust.NewDust(projectile.Center - vector2 / 2f, (int) vector2.X, (int) vector2.Y, 102, 0.0f,
                        0.0f, 100, new Color(), 2.5f);
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].velocity *= 5f;
                    int index3 = Dust.NewDust(projectile.Center - vector2 / 2f, (int) vector2.X, (int) vector2.Y, 102, 0.0f,
                        0.0f, 100, new Color(), 1.5f);
                    Main.dust[index3].velocity *= 3f;
                }

                if (Main.myPlayer == projectile.owner)
                {
                    int type = mod.ProjectileType("DropONog");
                    for (int index = 0; index < 6; ++index)
                    {
                        var SpeedX =
                            (float) (-(double) projectile.velocity.X * (double) Main.rand.Next(20, 50) * 0.00999999977648258 +
                                     (double) Main.rand.Next(-20, 21) * 0.400000005960464);
                        var SpeedY =
                            (float) (-(double) Math.Abs(projectile.velocity.Y) * (double) Main.rand.Next(30, 50) *
                                     0.00999999977648258 + (double) Main.rand.Next(-20, 5) * 0.400000005960464);
                        Projectile.NewProjectile(projectile.Center.X + SpeedX, projectile.Center.Y + SpeedY, SpeedX, SpeedY,
                            type, (int) ((double) projectile.damage * 0.5), 0.0f, projectile.owner, 0.0f, 0.0f);
                    }
                }
            }
    }
}