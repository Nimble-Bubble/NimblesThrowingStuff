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
    public class DemonClaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A strange demonic appendage that increases your throwing speed and velocity by 15%");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.value = Item.buyPrice(0, 7, 50, 0);
            Item.rare = 3;
            Item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.15f;
            player.thrownVelocity += 0.15f;
        }
    }
}
