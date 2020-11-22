using NimblesThrowingStuff.Items.Accessories;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff.Items
{
    public class NimblesGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (crit == true && player.GetModPlayer<NimblesPlayer>().sacredWrist == true && projectile.thrown == true && projectile.type != 92)
            {
                int star = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 250, 0, 20,
                            92, projectile.damage / 2, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                Main.projectile[star].thrown = true;
                Main.projectile[star].ranged = false;
                Main.projectile[star].usesLocalNPCImmunity = true;
            Main.projectile[star].localNPCHitCooldown = 10;
            }
            if (crit == true && player.GetModPlayer<NimblesPlayer>().thrownHeal == true && projectile.thrown)
            {
                player.HealEffect(damage / 100);
                player.statLife += damage / 100;
            }
            if (player.GetModPlayer<NimblesPlayer>().chloroThrow == true && projectile.thrown == true)
            {
                target.AddBuff(70, 300);
                target.AddBuff(20, 300);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniPoison == true && projectile.minion == true && Main.rand.NextBool(5))
            {
                target.AddBuff(20, 150);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniFire == true && projectile.minion == true && Main.rand.NextBool(5))
            {
                target.AddBuff(24, 250);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniFrost == true && projectile.minion == true && Main.rand.NextBool(5))
            {
                target.AddBuff(44, 300);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniEvil == true && projectile.minion == true && Main.rand.NextBool(5))
            {
                target.AddBuff(40, 450);
                target.AddBuff(69, 450);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniVenom == true && projectile.minion == true && Main.rand.NextBool(5))
            {
                target.AddBuff(70, 750);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniMove == true && projectile.minion == true && Main.rand.NextBool(5))
            {
                target.AddBuff(31, 450);
            }
        }
    }
}