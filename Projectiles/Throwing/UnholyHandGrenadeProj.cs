using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class UnholyHandGrenadeProj: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 28;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 16;
            Projectile.extraUpdates = 2;
            Projectile.timeLeft = 600;
            AIType = 30;
        }
        public override void Kill(int timeLeft) 
        {
            for (int s = 0; s < 30; s++) {
				int smokeIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width * 2, Projectile.height * 2, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[smokeIndex].velocity *= 1.4f;
			}
            for (int f = 0; f < 40; f++) {
				int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width * 2, Projectile.height * 2, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[fireIndex].velocity *= 4f;
			}
            SoundEngine.PlaySound(2, (int) Projectile.position.X, (int) Projectile.position.Y, 14, 1f, 0.0f);
                    var num = Main.rand.Next(8, 13);
                    for (var index = 0; index < num; ++index)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 201) * 0.025f;
                        int fire = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, vector2.X, vector2.Y,
                            Mod.Find<ModProjectile>("GreekFireballProj").Type, Projectile.damage / 4, 3f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                }
        }
    }
}