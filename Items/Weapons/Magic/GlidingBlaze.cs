using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class GlidingBlaze : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() 
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Magic;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 5;
			Item.knockBack = 6f;
            Item.noMelee = true;
			Item.value = Item.buyPrice(0, 5, 40, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item45;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<GlidingBlazeProj>();
			Item.shootSpeed = 6f;
            Item.mana = 12;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}