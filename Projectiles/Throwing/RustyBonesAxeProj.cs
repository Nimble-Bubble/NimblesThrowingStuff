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
	public class RustyBonesAxeProj: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 2;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			Projectile.extraUpdates += 1;
            target.AddBuff(70, 450);
        }
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 26,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 8, new Color(), 0.75f);
            if (Main.rand.NextBool(5))
            {
                Item.NewItem(Projectile.getRect(), ModContent.ItemType<RustyBonesAxe>());
            }
        }
    }
}