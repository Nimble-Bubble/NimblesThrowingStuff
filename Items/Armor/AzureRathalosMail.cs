using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class AzureRathalosMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Increases damage by 5%"
                +"\nGrants 3 seconds of lava immunity"); */
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;
            Item.value = 72000;
            Item.rare = ItemRarityID.Lime;
            Item.defense = 16; 
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.17f;
            player.lavaImmune = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RathalosMail>());
            recipe.AddIngredient(ItemID.SpectreBar, 16);
			recipe.AddIngredient(ItemID.ShroomiteBar, 16);
			recipe.AddIngredient(ItemID.Sapphire, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}