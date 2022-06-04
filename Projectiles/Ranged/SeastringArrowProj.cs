using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Ranged;

namespace NimblesThrowingStuff.Projectiles.Ranged
{
	public class SeastringArrowProj: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.usesLocalNPCImmunity = false;
            Projectile.tileCollide = true;
            Projectile.penetrate = 5;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.arrow = true;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 1;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 33,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(0, (int) Projectile.position.X, (int) Projectile.position.Y, 1, 1f, 0.0f);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 33,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}