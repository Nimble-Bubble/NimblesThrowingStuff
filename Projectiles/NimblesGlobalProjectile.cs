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
        public int maxShells;
        public override void SetDefaults(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (crit && player.GetModPlayer<NimblesPlayer>().sacredWrist && projectile.CountsAsClass(DamageClass.Throwing) && projectile.type != 92 && !projectile.npcProj)
            {
                int star = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y - 250, 0, 20,
                            92, projectile.damage / 2, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                Main.projectile[star].DamageType = DamageClass.Throwing;
                Main.projectile[star].usesLocalNPCImmunity = true;
            Main.projectile[star].localNPCHitCooldown = 10;
            }
            if (crit == true && player.GetModPlayer<NimblesPlayer>().thrownHeal && projectile.CountsAsClass(DamageClass.Throwing) && Main.rand.NextBool(10) && !projectile.npcProj)
            {
                player.HealEffect(damage / 100);
                player.statLife += damage / 100;
            }
            if (player.GetModPlayer<NimblesPlayer>().chloroThrow && projectile.CountsAsClass(DamageClass.Throwing) && !projectile.npcProj)
            {
                target.AddBuff(70, 300);
                target.AddBuff(20, 300);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniPoison && projectile.minion && Main.rand.NextBool(5))
            {
                target.AddBuff(20, 150);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniFire && projectile.minion && Main.rand.NextBool(5))
            {
                target.AddBuff(24, 250);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniFrost && projectile.minion && Main.rand.NextBool(5))
            {
                target.AddBuff(44, 300);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniEvil && projectile.minion && Main.rand.NextBool(5))
            {
                target.AddBuff(40, 450);
                target.AddBuff(69, 450);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniVenom && projectile.minion && Main.rand.NextBool(5))
            {
                target.AddBuff(70, 750);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniMove && projectile.minion && Main.rand.NextBool(5))
            {
                target.AddBuff(31, 450);
            }
            if (player.GetModPlayer<NimblesPlayer>().miniLocal && projectile.minion)
            {
                projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = 10;
            }
        }
    }
}