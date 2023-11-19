using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class TrueHallowedWaraxe : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 60;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 62;
			Item.height = 62;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = 1;
			Item.knockBack = 8f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("TrueHallowedWaraxeProj").Type;
			Item.shootSpeed = 15f;
            Item.mana = 10;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("HallowedWaraxe").Type);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}