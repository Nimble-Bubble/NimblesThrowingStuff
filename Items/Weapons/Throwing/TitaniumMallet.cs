using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class TitaniumMallet : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}
		public override void SetDefaults() 
		{
			Item.damage = 46;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 1;
			Item.knockBack = 6f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 17, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("TitaniumMalletProj").Type;
			Item.shootSpeed = 12f;
            Item.consumable = true;
            Item.maxStack = 9999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(1198, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}