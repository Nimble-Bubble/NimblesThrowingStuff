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
using NimblesThrowingStuff.Items.Accessories.Shields;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using NimblesThrowingStuff.Items.Placeables.Furniture;
using NimblesThrowingStuff.Items.Vanity;
using NimblesThrowingStuff.Items.Weapons.Melee;
using NimblesThrowingStuff.Items.Weapons.Ranged;
using NimblesThrowingStuff.Items.Weapons.Magic;
using NimblesThrowingStuff.Items.Weapons.Summoning;
using NimblesThrowingStuff.Items.Weapons.Throwing;

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
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 32;
            Item.rare = 9;
            Item.expert = true;
        }
        public override int BossBagNPC => ModContent.NPCType<MorilusMain>();

        public override bool CanRightClick()
        {
            return true;
        }
        public override void OpenBossBag(Player player)
        {
            player.TryGettingDevArmor();
            player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(50, 76));
            player.QuickSpawnItem(ModContent.ItemType<CarpatusDefender>());
            player.QuickSpawnItem(ModContent.ItemType<ProcellariteOre>(), Main.rand.Next(40, 61));
            int MorileTreasure = Main.rand.Next(5);
            switch (MorileTreasure)
            {
                case 0:
                    player.QuickSpawnItem(ModContent.ItemType<SkyseaSpinner>());
                    break;
                case 1:
                    player.QuickSpawnItem(ModContent.ItemType<ProcellariteLongbow>());
                    break;
                case 2:
                    player.QuickSpawnItem(ModContent.ItemType<GuardianStaff>());
                    break;
                case 3:
                    player.QuickSpawnItem(ModContent.ItemType<StormShot>());
                    break;
                case 4:
                    player.QuickSpawnItem(ModContent.ItemType<LacusDecapitator>());
                    break;
            }
            if (Main.rand.NextBool(7))
            {
                player.QuickSpawnItem(ModContent.ItemType<MorilusMask>());
            }
            if (Main.rand.NextBool(5))
            {
                player.QuickSpawnItem(ModContent.ItemType<MorilusTrophy>());
            }
        }
    }
}
