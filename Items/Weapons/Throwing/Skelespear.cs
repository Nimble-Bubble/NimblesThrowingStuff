using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Throwing;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class Skelespear : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//DisplayName.SetDefault("Enchanted Yari");
			// Tooltip.SetDefault("Turns into a stream of water");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = 1;
			Item.knockBack = 4.5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 8, 75, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SkelespearProj>();
			Item.shootSpeed = 8f;
            Item.mana = 11;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}