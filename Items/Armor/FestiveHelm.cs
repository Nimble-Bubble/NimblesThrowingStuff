using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FestiveHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
                Tooltip.SetDefault("Increases mana by 100 and throwing velocity by 40%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 500000;
            item.rare = 8;
            item.defense = 12; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("FestiveShirt") && legs.type == mod.ItemType("FestivePants");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You drop spike balls when hit, and your throwing damage is increased by 20%";
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.canSanta = true;
            player.thrownDamage += 0.2f;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.4f;
            player.statManaMax2 += 100;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<FestiveCloth>(), 12);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}