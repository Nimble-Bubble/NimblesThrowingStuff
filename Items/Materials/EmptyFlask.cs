using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Projectiles.Throwing;

namespace NimblesThrowingStuff.Items.Materials
{
	public class EmptyFlask : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
        {
			Item.damage = 32;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 0, 2, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<EmptyFlaskProj>();
			Item.shootSpeed = 12f;
            Item.consumable = true;
        }
		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(10);
			recipe.AddIngredient(ItemID.Glass, 2);
			recipe.AddIngredient(ItemID.Bone, 1);
			recipe.AddTile(TileID.GlassKiln);
			recipe.Register();
		}
	}
}
