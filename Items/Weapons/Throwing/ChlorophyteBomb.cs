using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class ChlorophyteBomb : ModItem
	{

		public override void SetDefaults() 
		{
			Item.damage = 65;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.knockBack = 10f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 20, 0, 0);
			Item.rare = 7;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("ChlorophyteBombProj").Type;
			Item.shootSpeed = 12f;
            Item.mana = 23;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}