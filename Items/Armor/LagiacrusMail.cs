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
    public class LagiacrusMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Increases attack speed by 5%"
                +"\nIncreases critical strike chance by 3%"); */
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 36000;
            Item.rare = 3;
            Item.defense = 8; 
        }
        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.universalSpeed += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 3;
        }
        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ItemID.BeeWax, 12);
            r.AddIngredient(ModContent.ItemType<LagiacrusShell>(), 10);
            r.AddTile(16);
            r.Register();
        }
    }
}