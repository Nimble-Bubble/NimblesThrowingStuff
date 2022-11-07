using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class DraconicRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dorado's Flight");
            Tooltip.SetDefault("Allows flight and slow fall"
            + "\nStellar membrane gives these wings powerful flight.");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 22;
            Item.height = 22;
            Item.value = Item.value = Item.buyPrice(0, 50, 0, 0);
            Item.rare = 10;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 150;
        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 2f;
			maxAscentMultiplier = 2.5f;
			constantAscend = 0.2f;
		}
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 10f;
			acceleration *= 5f;
		}
        public override void AddRecipes() 
        {
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DoradoFragment>(), 14);
            recipe.AddIngredient(3467, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
    }
}