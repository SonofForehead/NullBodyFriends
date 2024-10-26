using BoneLib.BoneMenu;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(NullBodyFriends.Core), "NullBodyFriends", "1.0.0", "SonofForehead", null)]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]

namespace NullBodyFriends
{
    public class Core : MelonMod
    {
        public static bool toggleMod;

        public static bool avatarIsNullBody;

        public override void OnInitializeMelon()
        {
            CreateBonemenu();
        }

        public static void CreateBonemenu()
        {
            Page mainPage = Page.Root.CreatePage("NullBody Friends", Color.yellow);
            mainPage.CreateBool("Mod Toggle", Color.white, true, ModToggle);
        }

        public static void ModToggle(bool toggle)
        {
            toggleMod = toggle;

            if (toggleMod)
            {
                MelonLogger.Msg("Mod Enabled");
            }
            else
            {
                MelonLogger.Msg("Mod Disabled");
            }
        }
        public override void OnUpdate()
        {
            if (BoneLib.Player.RigManager && BoneLib.Player.RigManager.AvatarCrate.Crate.Title.ToLower().Contains("null"))
            {
                avatarIsNullBody = true;

            }
            else
            {
                avatarIsNullBody = false;
            }
        }
    }
}