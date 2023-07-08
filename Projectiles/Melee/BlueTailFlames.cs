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
	public class BlueTailFlames: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 5;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.light = 0.5f;
            Projectile.alpha = 255;
            Projectile.aiStyle = -1;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 300;
        }
        public override void AI() 
        {
            //Can't seem to modify vanilla aiStyle 23 dust, so this is kind of a bootleg of aiStyle 23
            int dust1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 135,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 100, new Color(), 1f);
            if (Main.rand.Next(3) != 0)
            {
                Main.dust[dust1].noGravity = true;
                Main.dust[dust1].scale *= 3f;
                Dust lungado = Main.dust[dust1];
                lungado.velocity.X = lungado.velocity.X * 2f;
                Dust gadolun = Main.dust[dust1];
                gadolun.velocity.Y = gadolun.velocity.Y * 2f;
            }
            else
            {
                Main.dust[dust1].scale *= 1.25f;
            }
            if (Main.rand.NextBool(4))
            {
                int dust2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 135,
                            0f, 0f, 0, new Color(), 1f);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity *= 0.5f;
                Main.dust[dust2].scale *= 0.9f;
            }
        }
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Frostburn2, 150);
        }
    }
}