using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class FestiveJavelin : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Explodes into snowflakes");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 62;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = 1;
			Item.knockBack = 6f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 25, 0, 0);
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("FestiveJavelinProj").Type;
			Item.shootSpeed = 15f;
            Item.mana = 13;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("FestiveCloth").Type, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}