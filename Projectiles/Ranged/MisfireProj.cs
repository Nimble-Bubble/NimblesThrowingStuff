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
	public class MisfireProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Misfire");
        }
        public override void SetDefaults()
        {
            Projectile.width = 200;
            Projectile.height = 200;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 255;
            Projectile.aiStyle = 1;
            Projectile.timeLeft = 1;
        }
        public override void Kill(int timeLeft) 
        {
            for (int s = 0; s < 10; s++)
            {
                int smokeIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
                Main.dust[smokeIndex].velocity *= 1.4f;
            }
            for (int f = 0; f < 20; f++)
            {
                int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 127, 0f, 0f, 100, default(Color), 3f);
                Main.dust[fireIndex].velocity *= 4f;
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Main.player[Projectile.owner].velocity.X -= Projectile.velocity.X * 1;
            Main.player[Projectile.owner].velocity.Y -= Projectile.velocity.Y * 1;

        }
    }
}