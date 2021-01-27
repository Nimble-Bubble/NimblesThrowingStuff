using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Accessories
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
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = item.value = Item.buyPrice(1, 50, 0, 0);
            item.rare = 11;
            item.defense = 10;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.dash = 3;
            player.endurance += 0.2f;
        }
    }
}
