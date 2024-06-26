using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	
    public class CogSpearProj: ModProjectile
    {
        private int zamboni;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Knight Lance");
        }
        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = 19;
            Projectile.timeLeft = 40;
            Projectile.extraUpdates = 0;
            Projectile.scale = 1f;
            zamboni = 1;
        }
        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int fi = 0; fi < 5; fi++)
                {
                    int fireIndex2 = Dust.NewDust(new Vector2(Projectile.position.X / 2, Projectile.position.Y / 2), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
                }
            if (hit.Crit)
            {
                for (int fi = 0; fi < 10; fi++)
                {
                    int fireIndex2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
                }
                target.AddBuff(BuffID.OnFire, 450);
            }
        }
        public override void AI()
        {
            Player projOwner = Main.player[Projectile.owner];

            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            Projectile.direction = projOwner.direction;
            projOwner.heldProj = Projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            Projectile.timeLeft = projOwner.itemAnimation;
            Projectile.position.X = ownerMountedCenter.X - (float)(Projectile.width / 2);
            Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2);

            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    movementFactor = 3f;
                    Projectile.netUpdate = true;
                }
                if (projOwner.itemAnimation > projOwner.itemAnimationMax / 2)
                {
                    float bole = 0.25f;
                    // bole /= 2;
                    movementFactor += bole;
                }
                //else 
                //{
                //    movementFactor += 1f;
                //}
            }

            ++zamboni;
            Projectile.position += Projectile.velocity * ((movementFactor * 10) / zamboni);

            if (projOwner.itemAnimation == 0)
            {
                Projectile.Kill();
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation -= MathHelper.ToRadians(90f);
            }
            if (Main.myPlayer == Projectile.owner)
            {
                if (Main.player[Projectile.owner].channel)
                {
                    //float num1 = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].shootSpeed * projectile.scale;
                    //Vector2 vector2_2 = ownerMountedCenter;
                    //float num2 = (float)((float)Main.mouseX + Main.screenPosition.X - vector2_2.X);
                    //float num3 = (float)((float)Main.mouseY + Main.screenPosition.Y - vector2_2.Y);
                    //if ((float)Main.player[projectile.owner].gravDir == -1.0)
                    //    num3 = (float)((float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector2_2.Y);
                    //float num4 = (float)Math.Sqrt((float)num2 * (float)num2 + (float)num3 * (float)num3);
                    //float num5 = (float)Math.Sqrt((float)num2 * (float)num2 + (float)num3 * (float)num3);
                    //float num6 = num1 / num5;
                    // float num7 = num2 * num6;
                    //float num8 = num3 * num6;
                    //if ((float)num7 != projectile.velocity.X || (float)num8 != projectile.velocity.Y)
                    //    projectile.netUpdate = true;
                    //projectile.velocity.X = (float)num7;
                    //projectile.velocity.Y = (float)num8;
                }
            }
            else
            {
                Projectile.Kill();
            }
            Main.player[Projectile.owner].statDefense += 20;
            //Main.player[projectile.owner].endurance += 0.125f;

            //In case you're wondering why there's a statDefense boost in here, some lances along the default Ore line (Iron Lance > Paladin Lance > Growling Wyvern > Knight Lance > Ascalon > Spectra Lancea > Luminous Piercer) give flat stat boosts, especially defensive ones.
        }
        //public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        //{
            //if (Main.player[projectile.owner].velocity.X < 0)
            //{
            //    damage -= (int)Main.player[projectile.owner].velocity.X;
            //}
            //else
            //{
            //    damage += (int)Main.player[projectile.owner].velocity.X;
            //}
            //if (Main.player[projectile.owner].velocity.Y < 0)
            //{
            //    damage -= (int)Main.player[projectile.owner].velocity.Y;
            //}
            //else
            //{
            //    damage += (int)Main.player[projectile.owner].velocity.Y;
            //}
        //}
    }
}