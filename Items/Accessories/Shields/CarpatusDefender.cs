using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Accessories.Shields
{
    public class CarpatusDefender : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Grants a powerful dash"
                              +"\n20% increased damage reduction");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.value = Item.buyPrice(1, 50, 0, 0);
            Item.rare = 10;
            Item.defense = 10;
            Item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.dash = 3;
            player.endurance += 0.2f;
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.whichShield = 3;
        }
    }
}
