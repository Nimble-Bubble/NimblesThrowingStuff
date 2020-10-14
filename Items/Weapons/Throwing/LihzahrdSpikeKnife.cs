using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class LihzahrdSpikeKnife : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 65;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 1;
			item.knockBack = 4.5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LihzahrdSpikeKnifeProj");
			item.shootSpeed = 10f;
            item.consumable = true;
            item.maxStack = 999;
		}
	}
}