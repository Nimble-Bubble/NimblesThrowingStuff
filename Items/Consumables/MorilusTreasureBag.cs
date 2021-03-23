using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.NPCs.Morilus;
using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Placeables.Blocks;

namespace NimblesThrowingStuff.Items.Consumables
{
    public class MorilusTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 32;
            item.height = 32;
            item.rare = 9;
            item.expert = true;
        }
        public override int BossBagNPC => ModContent.NPCType<MorilusMain>();

        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            player.TryGettingDevArmor();
            player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(50, 76));
            player.QuickSpawnItem(ModContent.ItemType<CarpatusDefender>());
            player.QuickSpawnItem(ModContent.ItemType<ProcellariteOre>(), Main.rand.Next(40, 61));
        }
    }
}
