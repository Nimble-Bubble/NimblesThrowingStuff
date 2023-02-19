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
	public class SnowflakeShurikenProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowflake Shuriken");
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 2;
            Projectile.timeLeft = 80;
            Projectile.scale = 0.75f;
        }
        public override void AI()
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 92, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn2, 450);
        }
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 67,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}