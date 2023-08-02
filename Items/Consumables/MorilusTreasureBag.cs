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
using NimblesThrowingStuff.Items.Accessories.Shields;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using NimblesThrowingStuff.Items.Placeables.Furniture;
using NimblesThrowingStuff.Items.Vanity;
using NimblesThrowingStuff.Items.Weapons.Melee;
using NimblesThrowingStuff.Items.Weapons.Ranged;
using NimblesThrowingStuff.Items.Weapons.Magic;
using NimblesThrowingStuff.Items.Weapons.Summoning;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Consumables
{
    public class MorilusTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
            // DisplayName.SetDefault("Treasure Bag");
            // Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            ItemID.Sets.BossBag[Type] = true;
            Item.ResearchUnlockCount = 3;
        }
        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Cyan;
            Item.expert = true;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<MorilusMain>()));
            itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CarpatusDefender").Type, 3));
            itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("ProcellariteScope").Type, 1));
            itemLoot.Add(ItemDropRule.OneFromOptions(1, Mod.Find<ModItem>("SkyseaSpinner").Type, Mod.Find<ModItem>("ProcellariteLongbow").Type, Mod.Find<ModItem>("GuardianStaff").Type, Mod.Find<ModItem>("StormShot").Type, Mod.Find<ModItem>("LacusDecapitator").Type));
            itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("SoulOfTrite").Type, 1, 16, 25));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<MorilusMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("MorilusTrophy").Type, 5));
        }
    }
}
