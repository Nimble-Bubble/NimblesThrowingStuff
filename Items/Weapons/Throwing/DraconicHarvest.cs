using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class DraconicHarvest : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Spawns draconic portals that release shrapnel.");   
        }

		public override void SetDefaults() 
		{
			item.damage = 87;
			item.thrown = true;
			item.width = 7;
			item.height = 31;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 13f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 50, 0, 0);
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DraconicHarvestProj");
			item.shootSpeed = 25f;
            item.mana = 13;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DoradoFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}