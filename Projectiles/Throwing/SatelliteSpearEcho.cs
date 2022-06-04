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
	public class SatelliteSpearEcho: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = 2;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 600;
        }
        public override void AI()
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 35,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
         if (Projectile.penetrate <= 1 || Projectile.timeLeft <= 3)
         {
            Projectile.aiStyle = 16;
            Projectile.npcProj = true;   
             Projectile.position = Projectile.Center;
            Projectile.width = 250;
            Projectile.height = 250;
             Projectile.Center = Projectile.position;
             Projectile.timeLeft -= 500;
         }
        }
        public override void Kill(int timeLeft) 
        {
                        Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, 0, 0,
                            Mod.Find<ModProjectile>("SatelliteSpearEchosplosion").Type, Projectile.damage, 10f, Projectile.owner, 0.0f, 0.0f);
            Projectile.position = Projectile.Center;
            Projectile.width = 250;
            Projectile.height = 250;
             Projectile.Center = Projectile.position;
            
            Projectile.aiStyle = 16;
            SoundEngine.PlaySound(2, (int) Projectile.position.X, (int) Projectile.position.Y, 14, 1f, 0.0f);
            for (int s = 0; s < 10; s++) {
				int smokeIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[smokeIndex].velocity *= 1.4f;
			}
            for (int f = 0; f < 20; f++) {
				int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 229, 0f, 0f, 100, default(Color), 3f);
				Main.dust[fireIndex].velocity *= 4f;
			}
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.GetTexture("Projectiles/Throwing/SatelliteSpearEcho_Glow");
			spriteBatch.Draw
			(
				texture,
				Projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.SeaGreen,
				Projectile.rotation,
				texture.Size() * 0.5f,
				Projectile.scale,
				SpriteEffects.None,
				0f
			);
		}
    }
}