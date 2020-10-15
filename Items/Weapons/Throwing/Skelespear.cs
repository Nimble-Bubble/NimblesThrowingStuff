using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class Skelespear : ModItem
	{
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Enchanted Yari");
         Tooltip.SetDefault("Turns into a stream of water");   
        }

		public override void SetDefaults() 
		{
			item.damage = 21;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.knockBack = 4.5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 8, 75, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SkelespearProj");
			item.shootSpeed = 8f;
            item.mana = 11;
		}
	}
}