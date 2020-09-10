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
    public class OrichalcumHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Hat");
                Tooltip.SetDefault("Increases thrown damage by 8% and critical strike chance by 15%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 112500;
            item.rare = 4;
            item.defense = 9; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Attacks spawn petals from the sides of the screen";
            player.onHitPetal = true;
            player.thrownVelocity += 0.25f;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.08f;
            player.thrownCrit += 15;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(1191, 12);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}