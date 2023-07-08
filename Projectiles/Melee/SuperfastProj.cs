using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class SuperfastProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Superfast");
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 1000f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 50f;
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 5;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.alpha = 0;
            Projectile.aiStyle = 99;
            // projectile.extraUpdates = 2;
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Melee/SuperfastProj_Glow").Value;
            Main.EntitySpriteDraw
            (
				texture,
				Projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.LightBlue,
				Projectile.rotation,
				texture.Size() * 0.5f,
				Projectile.scale,
				SpriteEffects.None,
				0
			);
		}
    }
}