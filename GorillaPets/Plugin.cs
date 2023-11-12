using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Utilla;

namespace GorillaPets
{
    [ModdedGamemode]
    [BepInDependency("dev.auros.bepinex.bepinject")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public GameObject asset;
        public GameObject jump;
        public GameObject sit;
        public GameObject feed;
        public GameObject run;
        public static Material pet_m;
        public static Material pet1;
        public static Material pet2;
        public static Material pet3;
        public static Material pet4;
        public static Material pet5;
        public static Material pet6;
        public static GameObject screen;

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }

        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
        }

        void Setup()
        {
            var bundle = LoadAssetBundle("GorillaPets.Resources.gpets2");
            asset = Instantiate(bundle.LoadAsset<GameObject>("gorillapets2"));

            asset.transform.position = new Vector3(-63f, 12.4f, -82.7098f);
            asset.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            asset.transform.localEulerAngles = new Vector3(0f, 0f, 5f);

            asset.GetComponentInChildren<Text>().font = GorillaTagger.Instance.offlineVRRig.playerText.font;

            screen = asset.transform.Find("screen").gameObject;
            screen.GetComponent<BoxCollider>().enabled = false;

            jump = asset.transform.Find("jump").gameObject;
            sit = asset.transform.Find("sit").gameObject;
            feed = asset.transform.Find("feed").gameObject;
            run = asset.transform.Find("run").gameObject;

            jump.GetComponentInChildren<Text>().font = GorillaTagger.Instance.offlineVRRig.playerText.font;
            sit.GetComponentInChildren<Text>().font = GorillaTagger.Instance.offlineVRRig.playerText.font;
            feed.GetComponentInChildren<Text>().font = GorillaTagger.Instance.offlineVRRig.playerText.font;
            run.GetComponentInChildren<Text>().font = GorillaTagger.Instance.offlineVRRig.playerText.font;

            jump.layer = 18;
            sit.layer = 18;
            feed.layer = 18;
            run.layer = 18;

            jump.AddComponent<Buttons>();
            sit.AddComponent<Buttons>();
            feed.AddComponent<Buttons>();
            run.AddComponent<Buttons>();

            pet_m = bundle.LoadAsset<Material>("pet");
            pet1 = bundle.LoadAsset<Material>("pet 1");
            pet2 = bundle.LoadAsset<Material>("pet 2");
            pet3 = bundle.LoadAsset<Material>("pet 3");
            pet4 = bundle.LoadAsset<Material>("pet 4");
            pet5 = bundle.LoadAsset<Material>("pet 5");
            pet6 = bundle.LoadAsset<Material>("pet 6");
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            Setup();
        }

        void Update()
        {
        }
    }
}
