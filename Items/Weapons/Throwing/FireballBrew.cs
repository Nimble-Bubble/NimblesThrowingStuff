using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class FireballBrew : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("When it breaks, it bursts into brilliant flames");
		}
		public override void SetDefaults() 
		{
			Item.damage = 31;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = 1;
			Item.knockBack = 4f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 7, 50, 0);
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("FireballBrewProj").Type;
			Item.shootSpeed = 11f;
			Item.mana = 8;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("RedRathScale").Type, 12);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 16);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}