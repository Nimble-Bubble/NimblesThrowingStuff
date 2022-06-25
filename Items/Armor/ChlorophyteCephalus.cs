using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteCephalus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Cephalus");
                Tooltip.SetDefault("Increases minion damage by 15% and minion slots by 1");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 300000;
            Item.rare = 7;
            Item.defense = 3; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 1004 && legs.type == 1005;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased minion damage and slots, plus a crystal";
            player.GetDamage(DamageClass.Summon) += 0.16f;
            player.maxMinions += 2;
            player.AddBuff(60, 18000);
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.15f;
            player.maxMinions += 1;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(1006, 12);
            r.AddTile(134);
            r.Register();
        }
    }
}