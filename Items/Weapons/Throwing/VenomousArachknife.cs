using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class VenomousArachknife : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("This knife sticks to enemies");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 48;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 36;
			Item.height = 36;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = 1;
			Item.knockBack = 8f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 16, 0, 0);
			Item.rare = ItemRarityID.LightPurple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("VenomousArachknifeProj").Type;
			Item.shootSpeed = 12f;
            Item.mana = 12;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("Arachknife").Type);
            recipe.AddIngredient(1006, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}