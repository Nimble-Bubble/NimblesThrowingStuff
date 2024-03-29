using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Tiles.Furniture;

namespace NimblesThrowingStuff.Items.Tools
{
	public class ProcellariteHamaxe : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Melee;
			Item.width = 54;
			Item.height = 52;
			Item.useTime = 5;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 8f;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.axe = 250;
            Item.hammer = 125;
            Item.tileBoost += 6;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 15);
			recipe.AddTile(ModContent.TileType<ProcellaritePressTile>());
			recipe.Register();
		}
	}
}