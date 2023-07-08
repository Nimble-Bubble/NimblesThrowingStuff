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
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aquarrow");
        }
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
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 33,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 33, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}