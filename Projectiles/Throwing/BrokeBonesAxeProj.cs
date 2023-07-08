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
	public class BrokeBonesAxeProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Broke Bones Axe");
        }
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
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(5))
            {
			target.AddBuff(203, 120);
                }
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0) {
				Projectile.Kill();
			}
			else {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 26,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            if (Main.rand.NextBool(5))
            {
                Item.NewItem(Projectile.GetSource_FromThis(), Projectile.getRect(), ModContent.ItemType<BrokeBonesAxe>());
            }
        }
    }
}