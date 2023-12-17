using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Tiles.Furniture;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class ProcellariteKnife : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 120;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = 1;
			Item.knockBack = 4f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("ProcellariteKnifeProj").Type;
			Item.shootSpeed = 20f;
            Item.mana = 12;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
			Projectile.NewProjectile(Item.GetSource_FromThis(), position, perturbedSpeed, type, damage, Item.knockBack, player.whoAmI);
		}
		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("ProcellariteBar").Type, 10);
			recipe.AddTile(ModContent.TileType<ProcellaritePressTile>());
			recipe.Register();
		}
	}
}