using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class SpaceSpinnerProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16f;
            DisplayName.SetDefault("Space Spinner");
        }
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.alpha = 0;
            Projectile.aiStyle = 99;
            Projectile.extraUpdates = 1;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            if (crit)
                {
                    int meteorstrike = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + Main.rand.Next(-1, 2), Projectile.position.Y - 1000, Main.rand.Next(-1, 2), Main.rand.Next(5, 9), 424 + Main.rand.Next(3), Projectile.damage, Projectile.knockBack * 2, Projectile.owner);
                    Main.projectile[meteorstrike].DamageType = DamageClass.Melee;
                }
            }
    }
}