using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Throwing;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class LogicBomb : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("Can confuse enemies with its explosion");   
        }
		public override void SetDefaults() 
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 30;
			Item.height = 34;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<LogicBombProj>();
			Item.shootSpeed = 10f;
            Item.mana = 10;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe.AddIngredient(ItemID.TissueSample, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}