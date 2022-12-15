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
	public class VoidRocket4: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Rocket IV");
            Main.projFrames[Projectile.type] = 2;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = false;
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.usesLocalNPCImmunity = false;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.arrow = false;
            Projectile.aiStyle = 16;
            AIType = 341;
        }
        public override void AI()
        {
            int frameSpeed = 6;
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }
        }
        public override void Kill(int timeLeft) 
        {
            /* SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 5,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            if (Main.rand.NextBool(10))
            {
                Item.NewItem(Projectile.GetSource_FromThis(), Projectile.getRect(), ModContent.ItemType<HealingArrow>());
            } */
        }
    }
}