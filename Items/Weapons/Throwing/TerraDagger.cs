using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class TerraDagger : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 64;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 7f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.shoot = Mod.Find<ModProjectile>("TerraDaggerProj").Type;
			Item.shootSpeed = 22.5f;
            Item.mana = 50;
            Item.channel = true;
		}
		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("TrueHallowedWaraxe").Type);
            recipe.AddIngredient(Mod.Find<ModItem>("TrueNightPiercer").Type);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}