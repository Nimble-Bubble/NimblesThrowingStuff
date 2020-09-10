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
    public class ThrowerEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("15% increased thrown damage");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 4;
            item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.15f;
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this); //modded materials
            recipe.AddIngredient(547, 5);
			recipe.AddIngredient(548, 5);
            recipe.AddIngredient(549, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(935, 1);
			recipe.AddRecipe();
		}
    }
}
