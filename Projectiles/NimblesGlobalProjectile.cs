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
            if (crit == true && player.GetModPlayer<NimblesPlayer>().sacredWrist == true && projectile.thrown == true)
            {
                int star = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 250, 0, 20,
                            92, projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                Main.projectile[star].thrown = true;
                Main.projectile[star].ranged = false;
            }
        }
    }
}