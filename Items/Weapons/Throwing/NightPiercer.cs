using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class NightPiercer : ModItem
	{
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("Night's Piercer")
         Tooltip.SetDefault("A legendary knife with controlled flight");   
        }

		public override void SetDefaults() 
		{
			item.damage = 32;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 1;
			item.knockBack = 5.5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 5, 40, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("NightPiercerProj");
			item.shootSpeed = 15f;
            item.mana = 20;
            item.channel = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("VileHarvest"));
            recipe.AddIngredient(mod.ItemType("StingerDagger"));
            recipe.AddIngredient(mod.ItemType("BrimstoneBomb"));
            recipe.AddIngredient(mod.ItemType("Skelespear"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ViciousHarvest"));
            recipe.AddIngredient(mod.ItemType("StingerDagger"));
            recipe.AddIngredient(mod.ItemType("BrimstoneBomb"));
            recipe.AddIngredient(mod.ItemType("Skelespear"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}