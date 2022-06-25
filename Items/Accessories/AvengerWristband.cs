using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Accessories;

namespace NimblesThrowingStuff.Items.Accessories
{
    public class AvengerWristband : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Thrown critical strikes cause holy stars to fall down"
                              +"\n25% increased throwing velocity and 12% increased thrown damage");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.buyPrice(0, 25, 0, 0);
            Item.rare = 6;
            Item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<NimblesPlayer>().sacredWrist = true;
            player.ThrownVelocity += 0.25f;
            player.GetDamage(DamageClass.Throwing) += 0.12f;
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SacredWristband>()); 
            recipe.AddIngredient(935, 1);
			recipe.AddTile(114);
			recipe.Register();
		}
    }
}
