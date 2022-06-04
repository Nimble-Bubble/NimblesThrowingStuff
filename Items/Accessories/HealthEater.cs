using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Accessories
{
    public class HealthEater : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows your minions to poison enemies");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.value = Item.buyPrice(0, 2, 50, 0);
            Item.rare = 2;
            Item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.miniPoison = true;
        }
    }
}
