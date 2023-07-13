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
            if (projectile.type >= 390 || projectile.type <= 392)
            {
                projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = 24;
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[projectile.owner];
            if (hit.Crit && player.GetModPlayer<NimblesPlayer>().sacredWrist && projectile.CountsAsClass(DamageClass.Throwing) && projectile.type != 92 && !projectile.npcProj)
            {
                int star = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center - new Vector2 (0, 1000), new Vector2 (0 + Main.rand.Next(-2, 3), 20),
                            92, projectile.damage / 2, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                Main.projectile[star].DamageType = DamageClass.Throwing;
                Main.projectile[star].usesLocalNPCImmunity = true;
            Main.projectile[star].localNPCHitCooldown = 10;
            }
            if (hit.Crit == true && player.GetModPlayer<NimblesPlayer>().thrownHeal && projectile.CountsAsClass(DamageClass.Throwing) && Main.rand.NextBool(10) && !projectile.npcProj)
            {
                player.HealEffect(damageDone / 100);
                player.statLife += damageDone / 100;
            }
            if (player.GetModPlayer<NimblesPlayer>().chloroThrow && projectile.CountsAsClass(DamageClass.Throwing) && !projectile.npcProj)
            {
                target.AddBuff(70, 300);
                target.AddBuff(20, 300);
            }
            if (player.GetModPlayer<NimblesPlayer>().rathalosOnFire && projectile.owner == Main.myPlayer && Main.rand.NextBool(5))
            {
                target.AddBuff(BuffID.OnFire, 300);
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
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (projectile.type >= 404 && projectile.type <= 410 && projectile.type != 406 || projectile.type == 239 || projectile.type == 22 || projectile.type == 26 || projectile.type == 27)
            {
                target.AddBuff(BuffID.Wet, 300);
            }
            if (projectile.type == 451 || projectile.type == 459 || projectile.type == 440)
            {
                target.AddBuff(BuffID.Electrified, 240);
            }
            if (projectile.type == 461 || projectile.type == 443)
            {
                target.AddBuff(BuffID.Electrified, 450);
            }
        }
    }
}