using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Ranged
{
	public class ShroomiteBulletProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Bullet");
        }
        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.usesLocalNPCImmunity = false;
            Projectile.tileCollide = true;
            Projectile.penetrate = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.arrow = false;
            Projectile.aiStyle = 0;
            Projectile.extraUpdates = 2;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.penetrate <= 0) { Projectile.Kill(); }
            else
            {
                Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
                if (Projectile.velocity.X != oldVelocity.X) { Projectile.velocity.X = -oldVelocity.X; }
                if (Projectile.velocity.Y != oldVelocity.Y) { Projectile.velocity.Y = -oldVelocity.Y; }
                --Projectile.penetrate;
            }
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 41, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 1f);
            return false;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            int dust1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 135,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 100, new Color(), 1f);
            if (Main.rand.Next(3) != 0)
            {
                Main.dust[dust1].noGravity = true;
                Main.dust[dust1].scale *= 2f;
            }
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            if (Projectile.penetrate <= 0) 
            { 
                Projectile.Kill(); 
            }
            else
            {
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
                Projectile.velocity.X -= Projectile.velocity.X * 2;
                Projectile.velocity.Y -= Projectile.velocity.Y * 2;
            }
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 41, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 1f);
        }
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 41,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}