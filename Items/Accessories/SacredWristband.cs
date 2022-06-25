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
    public class SacredWristband : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Thrown critical strikes cause holy stars to fall down"
                              +"\n25% increased throwing velocity");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.value = Item.buyPrice(0, 40, 0, 0);
            Item.rare = 5;
            Item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<NimblesPlayer>().sacredWrist = true;
            player.ThrownVelocity += 0.25f;
        }
    }
}
