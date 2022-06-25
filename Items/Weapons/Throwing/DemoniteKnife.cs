using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class DemoniteKnife : ModItem
	{

		public override void SetDefaults() 
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 1;
			Item.knockBack = 5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 6, 25);
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("DemoniteKnifeProj").Type;
			Item.shootSpeed = 10f;
            Item.consumable = true;
            Item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(this.Type, 50);
			recipe.AddIngredient(ItemID.DemoniteBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}