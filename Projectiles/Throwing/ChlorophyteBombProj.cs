using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class ChlorophyteBombProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 16;
            projectile.extraUpdates = 1;
            projectile.timeLeft = 600;
            aiType = 30;
        }
        public override void Kill(int timeLeft) 
        {
            for (int s = 0; s < 30; s++) {
				int smokeIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width * 2, projectile.height * 2, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[smokeIndex].velocity *= 1.4f;
			}
            for (int f = 0; f < 40; f++)
            {
                int fireIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width * 2, projectile.height * 2, 128, 0f, 0f, 100, default(Color), 3f);
                Main.dust[fireIndex].velocity *= 4f;
            }
            Main.PlaySound(2, (int) projectile.position.X, (int) projectile.position.Y, 14, 1f, 0.0f);
                    var num = Main.rand.Next(8, 13);
                    for (var index = 0; index < num; ++index)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 201) * 0.025f;
                        int spore = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X, vector2.Y,
                            228, projectile.damage / 5, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                        Main.projectile[spore].thrown = true;
                Main.projectile[spore].usesLocalNPCImmunity = true;
                Main.projectile[spore].localNPCHitCooldown = 30;
                }
        }
    }
}