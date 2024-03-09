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
    [AutoloadEquip(EquipType.Head)]
    public class AzureRathalosHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Increases damage by 10%"
                +"\nGrants lava immunity"); */
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 26;
            Item.value = 48000;
            Item.rare = ItemRarityID.Lime;
            Item.defense = 12; 
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.10f;
            player.lavaImmune = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RathalosHelm>());
            recipe.AddIngredient(ItemID.SpectreBar, 8);
			recipe.AddIngredient(ItemID.ShroomiteBar, 8);
			recipe.AddIngredient(ItemID.LargeSapphire);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}