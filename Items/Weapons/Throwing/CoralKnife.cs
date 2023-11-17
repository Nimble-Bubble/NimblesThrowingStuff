using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class CoralKnife : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			// Tooltip.SetDefault("These knives stick to enemies");   
        }
		public override void SetDefaults() 
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.height = 26;
			Item.useTime = 29;
			Item.useAnimation = 29;
			Item.useStyle = 1;
			Item.knockBack = 4f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 1, 50);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("CoralKnifeProj").Type;
			Item.shootSpeed = 8f;
            Item.consumable = true;
            Item.maxStack = 9999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(100);
			recipe.AddIngredient(275, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}