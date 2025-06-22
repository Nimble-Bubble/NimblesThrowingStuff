using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Items.Accessories;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class PoseironTrident : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; 
        }

		public override void SetDefaults() 
		{
			Item.damage = 78;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 1;
			Item.knockBack = 7f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 25, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("PoseironTridentProj").Type;
			Item.shootSpeed = 10f;
            Item.mana = 20;
		}
		public override void AddRecipes()
		{
			//In case you don't get it as a drop or whatever
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RoyalFin>(), 12);
			recipe.AddIngredient(ModContent.ItemType<ThrowerEmblem>());
			recipe.AddIngredient(ItemID.Trident);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}