using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class ScavengedKunai : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("It's still a bit slimy");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = 1;
			Item.knockBack = 3.5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 3, 50, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("ScavengedKunaiProj").Type;
			Item.shootSpeed = 11f;
            Item.mana = 4;
		}
	}
}