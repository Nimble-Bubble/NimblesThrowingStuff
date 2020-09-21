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
    public class AvengerWristband : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Thrown critical strikes cause holy stars to fall down"
                              +"\n25% increased throwing velocity and 15% increased thrown damage");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = 6;
            item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<NimblesPlayer>().sacredWrist = true;
            player.thrownVelocity += 0.25f;
            player.thrownDamage += 0.15f;
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SacredWristband")); //modded materials
            recipe.AddIngredient(935, 1);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
