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

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MakluvaHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Tooltip.SetDefault("Increases throwing damage by 10%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 11750;
            Item.rare = 2;
            Item.defense = 5; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.gills = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Salmon, 3);
            recipe.AddIngredient(ItemID.RedSnapper, 6);
            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Salmon, 3);
            recipe.AddIngredient(ItemID.RedSnapper, 6);
            recipe.AddIngredient(ItemID.TissueSample, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}