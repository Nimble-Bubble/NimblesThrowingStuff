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
    public class LagiacrusHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Increases attack speed by 5%"
                +"\nIncreases critical strike chance by 3%"); */
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 28;
            Item.value = 24000;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 6; 
        }
        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.universalSpeed += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 3;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BeeWax, 8);
            recipe.AddIngredient(ModContent.ItemType<LagiacrusShell>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}