using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Placeables.Walls
{
	public class HadalShellstoneWall : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}
		public override void SetDefaults() 
		{
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 7;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 0, 0, 12);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.createWall = Mod.Find<ModWall>("HadalShellstoneWallTile").Type;
            Item.consumable = true;
            Item.maxStack = 9999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(4);
			recipe.AddIngredient(Mod.Find<ModItem>("HadalShellstone").Type, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
            recipe = Recipe.Create(Mod.Find<ModItem>("HadalShellstone").Type, 1);
			recipe.AddIngredient(this, 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}