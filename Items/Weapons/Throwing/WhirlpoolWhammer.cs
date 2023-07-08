using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class WhirlpoolWhammer : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("Designed to mimic the whirlpools that Lagiacri use to hunt their prey"
				+"\nHas a chance to electrify targets"); */
		}
		public override void SetDefaults() 
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 7, 50, 0);
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("WhirlpoolWhammerProj").Type;
			Item.shootSpeed = 12f;
			Item.mana = 12;
		}
		public override bool CanUseItem(Player player)
        {
			if (player.ownedProjectileCounts[Item.shoot] >= 1)
            {
				return false;
            }
			return true;
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("LagiacrusShell").Type, 12);
			recipe.AddIngredient(ItemID.BeeWax, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("LagiacrusShell").Type, 12);
			recipe.AddIngredient(ItemID.BeeWax, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}