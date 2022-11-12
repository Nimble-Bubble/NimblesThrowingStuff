using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class NightPiercer : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Night's Piercer");
         Tooltip.SetDefault("A legendary knife with controlled flight");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 27;
			Item.useAnimation = 27;
			Item.useStyle = 1;
			Item.knockBack = 5.5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 5, 40, 0);
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("NightPiercerProj").Type;
			Item.shootSpeed = 15f;
            Item.mana = 20;
            Item.channel = true;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("VileHarvest").Type);
            recipe.AddIngredient(Mod.Find<ModItem>("StingerDagger").Type);
            recipe.AddIngredient(Mod.Find<ModItem>("BrimstoneBomb").Type);
            recipe.AddIngredient(Mod.Find<ModItem>("Skelespear").Type);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
            recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("ViciousHarvest").Type);
            recipe.AddIngredient(Mod.Find<ModItem>("StingerDagger").Type);
            recipe.AddIngredient(Mod.Find<ModItem>("BrimstoneBomb").Type);
            recipe.AddIngredient(Mod.Find<ModItem>("Skelespear").Type);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}