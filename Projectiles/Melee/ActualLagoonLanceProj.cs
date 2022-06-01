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
	public class ActualLagoonLanceProj: ModProjectile
    {
        private bool hasWatered;
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.aiStyle = 19;
            projectile.timeLeft = 20;
            projectile.extraUpdates = 0;
            projectile.scale = 1.1f;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
        }
        public float movementFactor
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }
        public override void AI()
        {
            Player projOwner = Main.player[projectile.owner];

            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.timeLeft = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);

            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    movementFactor = 3f;
                    projectile.netUpdate = true;
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

            projectile.position += projectile.velocity * movementFactor;

            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }

            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
            if (Main.mouseRight && !hasWatered)
            {
                    int neatostream = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X / 2, projectile.velocity.Y / 2, ProjectileID.WaterStream, projectile.damage / 2, 1.5f, projectile.owner);
                    Main.projectile[neatostream].magic = false;
                    Main.projectile[neatostream].melee = true;
                    Main.projectile[neatostream].usesLocalNPCImmunity = true;
                    Main.projectile[neatostream].localNPCHitCooldown = 10;
                    Main.PlaySound(SoundID.Item21);
                hasWatered = true;
            }
        }
        //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        //{
            //Texture2D texture = Main.projectileTexture[projectile.type];
            //Vector2 moreNormalPosition = projectile.position + new Vector2(projectile.width, projectile.height) / 2f - Main.screenPosition;
            //Vector2 moreNormalOrigin = new Vector2(projectile.width, projectile.height) / 2f;
            //spriteBatch.Draw(texture, projectile.Center, Color.White);
            //return true;
        //}
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