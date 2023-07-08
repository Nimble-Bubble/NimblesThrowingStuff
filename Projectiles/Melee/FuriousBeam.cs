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
	public class FuriousBeam: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Furious Beam");
        }
        public override void SetDefaults()
        {
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.light = 0.5f;
            Projectile.alpha = 100;
            Projectile.aiStyle = 27;
            Projectile.extraUpdates = 1;
        }
        public override void AI() 
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 174, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Melee/FuriousBeam_Glow").Value;
			Main.EntitySpriteDraw(texture, Projectile.position, new Rectangle(0, 0, texture.Width, texture.Height), Color.Orange, Projectile.rotation, texture.Size() * 0.5f, Projectile.scale, SpriteEffects.None, 0);
		}
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(189, 750);
            int splode = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
            612, Projectile.damage, 6f, Projectile.owner, 0, (float) Main.rand.Next(-1, 1));
            Main.projectile[splode].usesLocalNPCImmunity = true;
            Main.projectile[splode].localNPCHitCooldown = 10;
        }
    }
}