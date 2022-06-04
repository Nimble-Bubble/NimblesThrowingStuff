using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class MorilusMask : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 37500;
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }
    }
}