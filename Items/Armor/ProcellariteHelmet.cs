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
    public class ProcellariteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
                Tooltip.SetDefault("Increases melee damage and critical strike chance by 30%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 500000;
            Item.rare = 11;
            Item.defense = 36; 
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.Find<ModItem>("ProcellariteChestplate").Type && legs.type == Mod.Find<ModItem>("ProcellariteLeggings").Type;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Damage reduction and melee speed increased by 25%";
            player.GetAttackSpeed(DamageClass.Melee) += 0.25f;
            player.endurance += 0.25f;
        }
        public override void UpdateEquip(Player player)
        {
             player.GetDamage(DamageClass.Melee) += 0.3f;
            player.GetCritChance(DamageClass.Melee) += 30;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}