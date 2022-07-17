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
	public class TrueHallowedWaraxeProj: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 62;
            Projectile.height = 62;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.maxPenetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 3;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 3;
        }
        public override void AI() 
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 57,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            int g = 0; 
            g++;
            if (g % 30 == 0)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity.RotatedBy(MathHelper.ToRadians(-30)), ModContent.ProjectileType<WaraxeEcho>(), Projectile.damage / 4, Projectile.knockBack / 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, ModContent.ProjectileType<WaraxeEcho>(), Projectile.damage / 3, Projectile.knockBack / 2);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity.RotatedBy(MathHelper.ToRadians(30)), ModContent.ProjectileType<WaraxeEcho>(), Projectile.damage / 4, Projectile.knockBack / 2);
            }
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.GetTexture("Projectiles/Throwing/TrueHallowedWaraxeProj_Glow");
            Main.EntitySpriteDraw
            (
				texture,
				Projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Blue,
				Projectile.rotation,
				texture.Size() * 0.5f,
				Projectile.scale,
				SpriteEffects.None,
				0
			);
		}
    }
}