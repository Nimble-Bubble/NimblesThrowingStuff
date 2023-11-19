using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class MeteorSpear : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			// Tooltip.SetDefault("An extremely agile exploding javelin");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 1;
			Item.knockBack = 7f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 2, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("MeteorSpearProj").Type;
			Item.shootSpeed = 9f;
            Item.consumable = true;
            Item.maxStack = 9999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(117, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}