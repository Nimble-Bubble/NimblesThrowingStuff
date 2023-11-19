using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class OrichalcumHatchet : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}
		public override void SetDefaults() 
		{
			Item.damage = 41;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 36;
			Item.height = 30;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.useStyle = 1;
			Item.knockBack = 5.5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 13, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("OrichalcumHatchetProj").Type;
			Item.shootSpeed = 11f;
            Item.consumable = true;
            Item.maxStack = 9999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(1191, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}