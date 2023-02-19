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
	public class LogicBombProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Logic Bomb");
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.maxPenetrate = 2;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 16;
            Projectile.timeLeft = 60;
            AIType = 30;
        }
        public override void Kill(int timeLeft) 
        {
            for (int s = 0; s < 30; s++)
            {
                int smokeIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width * 2, Projectile.height * 2, 31, 0f, 0f, 100, default(Color), 2f);
                Main.dust[smokeIndex].velocity *= 1.4f;
            }
            for (int f = 0; f < 40; f++)
            {
                int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width * 2, Projectile.height * 2, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[fireIndex].velocity *= 4f;
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, Mod.Find<ModProjectile>("LogicBombExplosion").Type, Projectile.damage, 10f, Projectile.owner, 0.0f, 0.0f);
        }
    }
}