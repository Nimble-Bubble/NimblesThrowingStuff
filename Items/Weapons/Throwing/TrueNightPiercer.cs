using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class TrueNightPiercer : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("True Night's Piercer");
         // Tooltip.SetDefault("'Find your own way to the Knife'");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 64;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 32;
			Item.height = 38;
			Item.useTime = 27;
			Item.useAnimation = 27;
			Item.useStyle = 1;
			Item.knockBack = 7f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("TrueNightPiercerProj").Type;
			Item.shootSpeed = 20f;
            Item.mana = 20;
            Item.channel = true;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("NightPiercer").Type);
			recipe.AddIngredient(547, 12);
			recipe.AddIngredient(548, 12);
			recipe.AddIngredient(549, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}