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
	public class GolemFireProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golem's Fire");
        }
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.maxPenetrate = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 8;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            AIType = 15;
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Throwing/GolemFireProj_Glow").Value;
            Main.EntitySpriteDraw(texture, Projectile.position, new Rectangle(0, 0, texture.Width, texture.Height), Color.Yellow, Projectile.rotation, texture.Size() * 0.5f, Projectile.scale, SpriteEffects.None, 0);
		}
    }
}