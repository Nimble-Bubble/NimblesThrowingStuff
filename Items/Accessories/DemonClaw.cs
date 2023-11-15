using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Accessories
{
    public class DemonClaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("A demonic appendage with curious properties"
                +"\nIncreases throwing speed (both use time and velocity) by 15%"); */
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 22;
            Item.height = 24;
            Item.value = Item.value = Item.buyPrice(0, 7, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.15f;
            player.ThrownVelocity += 0.15f;
        }
    }
}
