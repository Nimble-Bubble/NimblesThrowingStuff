using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Tiles.Furniture;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ProcellariteChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // DisplayName.SetDefault("Procellarite Chestplate");
                // Tooltip.SetDefault("Increases damage and critical strike chance by 10% and maximum life by 100");
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 26;
            Item.value = 1000000;
            Item.rare = ItemRarityID.Red;
            Item.defense = 30; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.guardBonus += 20;
            player.GetDamage(DamageClass.Generic) += 0.1f;
            player.GetCritChance(DamageClass.Generic) += 10;
            player.statLifeMax2 += 100;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 24);
            recipe.AddTile(ModContent.TileType<ProcellaritePressTile>());
            recipe.Register();
        }
    }
}