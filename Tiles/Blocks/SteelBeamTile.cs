using NimblesThrowingStuff.Items.Placeables.Blocks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace NimblesThrowingStuff.Tiles.Blocks
{
    public class SteelBeamTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = true;

            RegisterItemDrop(ModContent.ItemType<SteelBeam>());
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Steel Beam");
            AddMapEntry(new Color(122, 122, 142), name);
            MineResist = 2f;
            DustType = 11;
            HitSound = SoundID.Tink;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
