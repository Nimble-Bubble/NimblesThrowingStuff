using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HallowedCap : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // DisplayName.SetDefault("Hallowed Cap");
                // Tooltip.SetDefault("Increases thrown damage by 23% and thrown critical strike chance by 10%");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 250000;
            Item.rare = ItemRarityID.Pink;;
            Item.defense = 12; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 551 && legs.type == 552;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Become immune after striking an enemy";
            player.onHitDodge = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.23f;
            player.GetCritChance(DamageClass.Throwing) += 10;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(1225, 12);
            recipe.AddTile(134);
            recipe.Register();
        }
    }
}