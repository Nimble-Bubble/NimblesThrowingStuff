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
	public class MeteorSpearProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 5;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 1;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 120;
        }
        public override void AI()
        {
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 35,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
         if (projectile.penetrate <= 1 || projectile.timeLeft <= 3)
         {
            projectile.aiStyle = 16;
            projectile.npcProj = true;   
             projectile.position = projectile.Center;
            projectile.width = 250;
            projectile.height = 250;
             projectile.Center = projectile.position;
             projectile.timeLeft -= 50;
         }
        }
        public override void Kill(int timeLeft) 
        {
                        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0,
                            mod.ProjectileType("MeteorSpearExplosion"), projectile.damage, 10f, projectile.owner, 0.0f, 0.0f);
            projectile.position = projectile.Center;
            projectile.width = 250;
            projectile.height = 250;
             projectile.Center = projectile.position;
            
            projectile.aiStyle = 16;
            Main.PlaySound(2, (int) projectile.position.X, (int) projectile.position.Y, 14, 1f, 0.0f);
            for (int s = 0; s < 50; s++) {
				int smokeIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[smokeIndex].velocity *= 1.4f;
			}
            for (int f = 0; f < 80; f++) {
				int fireIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[fireIndex].velocity *= 4f;
			}
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/Throwing/MeteorSpearProj_Glow");
			spriteBatch.Draw
			(
				texture,
				projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Yellow,
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.None,
				0f
			);
		}
    }
}