using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class MartianMiracle : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("A miracle of Martian technology, this remote dagger can tear throught the night sky"
				+"\nUpon hitting an enemy, there is a chance for a sword beam to appear"
				+"\nHold right click to ignore tile collision");
		}
		public override void SetDefaults() 
		{
			Item.damage = 78;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.knockBack = 8f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 75, 0, 0);
			Item.rare = 9;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.shoot = Mod.Find<ModProjectile>("MartianMiracleProj").Type;
			Item.shootSpeed = 25f;
            Item.mana = 60;
            Item.channel = true;
		}
	}
}