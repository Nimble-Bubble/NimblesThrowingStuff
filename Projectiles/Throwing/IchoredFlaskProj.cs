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
	public class IchoredFlaskProj: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 2;
            Projectile.extraUpdates = 0;
        }
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
                Gore.NewGore(Projectile.Center, -Projectile.oldVelocity * 0.2f, 704, 1f);
                Gore.NewGore(Projectile.Center, -Projectile.oldVelocity * 0.2f, 705, 1f);
                if (Projectile.owner == Main.myPlayer)
                {
                    var num = Main.rand.Next(20, 31);
                    for (var index = 0; index < num; ++index)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 201) * 0.01f;
                        Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, vector2.X, vector2.Y,
                            Mod.Find<ModProjectile>("IchorCloud1").Type, Projectile.damage / 5, 1f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                    }
                }
        }
    }
}