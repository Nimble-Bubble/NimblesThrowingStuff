using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class Tritifier : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("Fires a bolt of trite that wears out enemies' defenses");
            Item.staff[Item.type] = true;
		}
		public override void SetDefaults() 
		{
			Item.damage = 113;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 5;
			Item.knockBack = 4f;
            Item.noMelee = true;
			Item.value = Item.buyPrice(0, 40, 0, 0);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item66;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<TritifyingShot>();
			Item.shootSpeed = 7f;
            Item.mana = 11;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SoulOfTrite>(), 12);
			recipe.AddIngredient(ItemID.SpellTome);
			recipe.AddTile(TileID.Bookcases);
			recipe.Register();
		}
	}
}