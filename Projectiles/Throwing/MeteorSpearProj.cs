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
	public class MeteorSpearProj: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 5;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 120;
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
             Projectile.timeLeft -= 50;
         }
        }
        public override void Kill(int timeLeft) 
        {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0,
                            Mod.Find<ModProjectile>("MeteorSpearExplosion").Type, Projectile.damage, 10f, Projectile.owner, 0.0f, 0.0f);
            Projectile.position = Projectile.Center;
            Projectile.width = 250;
            Projectile.height = 250;
             Projectile.Center = Projectile.position;
            
            Projectile.aiStyle = 16;
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            for (int s = 0; s < 50; s++) {
				int smokeIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[smokeIndex].velocity *= 1.4f;
			}
            for (int f = 0; f < 80; f++) {
				int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[fireIndex].velocity *= 4f;
			}
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Throwing/MeteorSpearProj_Glow").Value;
			Main.EntitySpriteDraw
			(
				texture,
				Projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Yellow,
				Projectile.rotation,
				texture.Size() * 0.5f,
				Projectile.scale,
				SpriteEffects.None,
				0
			);
		}
    }
}