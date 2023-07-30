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
    [AutoloadEquip(EquipType.Legs)]
    public class RathalosGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Increases damage by 5%"
                +"\nGrants 2 seconds of lava immunity"); */
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 30000;
            Item.rare = 3;
            Item.defense = 7; 
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.lavaMax += 120;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == Mod.Find<ModItem>("RathalosHelm").Type && body.type == Mod.Find<ModItem>("RathalosMail").Type;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Projectile attacks will light targets on fire"
                +"\nAdditionally, lava will no longer hurt you";
            player.lavaImmune = true;
            player.GetModPlayer<NimblesPlayer>().rathalosOnFire = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 10);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}