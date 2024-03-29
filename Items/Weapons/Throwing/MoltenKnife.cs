using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class MoltenKnife : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}
		public override void SetDefaults() 
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = 1;
			Item.knockBack = 6f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 8, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("MoltenKnifeProj").Type;
			Item.shootSpeed = 11f;
            Item.consumable = true;
            Item.maxStack = 9999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}