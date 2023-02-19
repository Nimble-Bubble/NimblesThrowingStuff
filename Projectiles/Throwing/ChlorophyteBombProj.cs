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
	public class ChlorophyteBombProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Bomb");
        }
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 16;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 600;
            AIType = 30;
        }
        public override void Kill(int timeLeft) 
        {
            for (int s = 0; s < 30; s++) {
				int smokeIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width * 2, Projectile.height * 2, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[smokeIndex].velocity *= 1.4f;
			}
            for (int f = 0; f < 40; f++)
            {
                int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width * 2, Projectile.height * 2, 128, 0f, 0f, 100, default(Color), 3f);
                Main.dust[fireIndex].velocity *= 4f;
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
                    var num = Main.rand.Next(8, 13);
                    for (var index = 0; index < num; ++index)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 201) * 0.025f;
                        int spore = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vector2.X, vector2.Y,
                            228, Projectile.damage / 5, 1f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                        Main.projectile[spore].DamageType = DamageClass.Throwing;
                Main.projectile[spore].usesLocalNPCImmunity = true;
                Main.projectile[spore].localNPCHitCooldown = 30;
                }
        }
    }
}