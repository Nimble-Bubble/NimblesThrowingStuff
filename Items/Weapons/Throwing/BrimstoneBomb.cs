using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Throwing;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class BrimstoneBomb : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Explodes into hellish shrapnel");   
        }
		public override void SetDefaults() 
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 9f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 2, 70, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BrimstoneBombProj>();
			Item.shootSpeed = 8.5f;
            Item.mana = 13;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}