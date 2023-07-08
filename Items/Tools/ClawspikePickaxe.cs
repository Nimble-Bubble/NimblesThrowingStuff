using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Tools
{
	public class ClawspikePickaxe : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("Made from Hermitaur materials, this pickaxe is a powerful tool for rapid mining.");
		}
		public override void SetDefaults() 
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 1;
			Item.knockBack = 2f;
			Item.value = Item.buyPrice(0, 2, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.pick = 60;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<HermitaurShell>(), 12);
			recipe.AddIngredient(ItemID.Leather, 4);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}