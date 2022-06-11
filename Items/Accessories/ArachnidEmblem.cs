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
    public class ArachnidEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows your minions, chelicerates or not, to envenom enemies");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.rare = 4;
            Item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.miniVenom = true;
        }
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(2607, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}
