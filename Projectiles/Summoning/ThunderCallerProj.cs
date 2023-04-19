using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Summoning
{
	public class ThunderCallerProj: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.aiStyle = 140;
            Projectile.timeLeft = 3600;
            Projectile.ignoreWater = true;
            AIType = 697;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            for (int f = 0; f < 3; f++)
            {
                int zapIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 226, 0f, 0f, 100, default(Color), 1f);
                Main.dust[zapIndex].velocity *= 6f;
            }
            if (Main.rand.NextBool(10) && !target.buffImmune[BuffID.Electrified])
            {
                for (int f = 0; f < 12; f++)
                {
                    int zapIndex2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 226, 0f, 0f, 100, default(Color), 1.25f);
                    Main.dust[zapIndex2].velocity *= 8f;
                }
                SoundEngine.PlaySound(SoundID.Item94);
                target.AddBuff(BuffID.Electrified, 450);
            }
        }
    }
}