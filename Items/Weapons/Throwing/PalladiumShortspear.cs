using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class PalladiumShortspear : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}
		public override void SetDefaults() 
		{
			Item.damage = 36;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = 1;
			Item.knockBack = 5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 9, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("PalladiumShortspearProj").Type;
			Item.shootSpeed = 10f;
            Item.consumable = true;
            Item.maxStack = 9999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(1184, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}